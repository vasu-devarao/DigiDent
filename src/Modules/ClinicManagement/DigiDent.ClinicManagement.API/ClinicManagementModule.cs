﻿using DigiDent.ClinicManagement.API.Endpoints;
using DigiDent.ClinicManagement.Application;
using DigiDent.ClinicManagement.EFCorePersistence;
using DigiDent.ClinicManagement.Infrastructure;
using DigiDent.Shared.Abstractions.Modules;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DigiDent.ClinicManagement.API;

/// <summary>
/// Marker and loader class for the ClinicManagement module
/// </summary>
public sealed class ClinicManagementModule: IModule
{
    public string Name => nameof(ClinicManagementModule);

    public void RegisterDependencies(
        IServiceCollection services,
        IConfiguration configuration,
        MediatRServiceConfiguration mediatrConfiguration)
    {
        services
            .AddApplication(mediatrConfiguration)
            .AddPersistence(configuration)
            .AddInfrastructure();
    }

    public void RegisterEndpoints(IEndpointRouteBuilder builder)
    {
        builder
            .MapAppointmentsEndpoints()
            .MapDoctorsEndpoints()
            .MapEmployeesScheduleEndpoints()
            .MapPatientsEndpoints()
            .MapProvidedServicesEndpoints();
    }
}