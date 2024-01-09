﻿using System.Security.Claims;
using DigiDent.Application.UserAccess.Commands.Refresh;
using DigiDent.Application.UserAccess.Commands.Shared;
using DigiDent.Application.UserAccess.Tokens;
using DigiDent.Domain.SharedKernel;
using DigiDent.Domain.UserAccessContext.Users;

namespace DigiDent.Application.UserAccess.Abstractions;

public interface IJwtService
{
    Task<AuthenticationResponse> GenerateAuthenticationResponseAsync(
        User user, CancellationToken cancellationToken); 
    
    Task<Result<AuthenticationResponse>> RefreshTokenAsync(
        RefreshCommand request, CancellationToken cancellationToken);
}