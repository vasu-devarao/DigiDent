﻿using System.Text;
using DigiDent.Application.UserAccess.Abstractions;
using DigiDent.Infrastructure.UserAccess.Authentication;
using DigiDent.Infrastructure.UserAccess.Authorization.RolesRequirement;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace DigiDent.Infrastructure.UserAccess;

public static class DependencyInjection
{
    /// <summary>
    /// Adds and configures infrastructure of the UserAccess bounded context.
    /// </summary>
    /// <returns></returns>
    public static IServiceCollection AddUserAccessInfrastructure(
        this IServiceCollection services, 
        IConfigurationSection configurationSection)
    {
        services
            .ConfigureJwt(configurationSection)
            .ConfigureAuthorizationServices(configurationSection)
            .AddAuthorization();
        return services;
    }
    
    private static IServiceCollection ConfigureJwt(
        this IServiceCollection services,
        IConfigurationSection configurationSection)
    {
        services.Configure<JwtOptions>(configurationSection);
        services.AddTransient<IJwtService, JwtService>();
        return services;
    }
    
    private static IServiceCollection ConfigureAuthorizationServices(
        this IServiceCollection services,
        IConfigurationSection configurationSection)
    {
        var tokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = configurationSection["Issuer"],
            ValidateAudience = true,
            ValidAudience = configurationSection["Audience"],
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(configurationSection["Secret"]!)),
            ValidateLifetime = true,
            LifetimeValidator = (
                notBefore, expires, securityToken, validationParameters) =>
            {
                if (expires != null)
                {
                    return expires > DateTime.UtcNow;
                }
                return false;
            }
        };
        
        services.AddSingleton(tokenValidationParameters);
        services.AddSingleton<IAuthorizationHandler, RolesAuthorizationHandler>();
        
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = tokenValidationParameters;
            });
        return services;
    }
}