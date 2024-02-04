﻿using DigiDent.ClinicManagement.Application.Appointments.Commands.CloseAppointment;
using DigiDent.ClinicManagement.Application.Appointments.Commands.CreateAppointment;
using DigiDent.Shared.Infrastructure.Api;
using DigiDent.Shared.Kernel.Abstractions;
using DigiDent.Shared.Kernel.ReturnTypes;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace DigiDent.ClinicManagement.API.Endpoints;

internal static class AppointmentsEndpoints
{
    internal static IEndpointRouteBuilder MapAppointmentsEndpoints(
        this IEndpointRouteBuilder builder)
    {
        var appointmentsGroup = builder.MapGroup("/appointments");

        appointmentsGroup.MapPost("/", CreateAppointment);
        appointmentsGroup.MapPut("/{id}", CloseAppointment);
           
        return builder;
    }

    private static async Task<IResult> CreateAppointment(
        [FromBody]CreateAppointmentRequest request,
        [FromServices]ISender sender,
        [FromServices]IDateTimeProvider dateTimeProvider,
        CancellationToken cancellationToken)
    {
        Result<CreateAppointmentCommand> commandResult = CreateAppointmentCommand
            .CreateFromRequest(request, dateTimeProvider);
            
        if (commandResult.IsFailure)
            return commandResult.MapToIResult();
            
        Result<Guid> creationResult = await sender.Send(
            commandResult.Value!, cancellationToken);

        return creationResult.Match(
            onFailure: _ => creationResult.MapToIResult(),
            onSuccess: id => Results.Created(
                $"/appointments/{id}", id));
    }
    
    private static async Task<IResult> CloseAppointment(
        [FromRoute]Guid id,
        [FromBody]CloseAppointmentRequest request,
        [FromServices]ISender sender,
        CancellationToken cancellationToken)
    {
        Result<CloseAppointmentCommand> commandResult = CloseAppointmentCommand
            .CreateFromRequest(id, request);
        
        if (commandResult.IsFailure)
            return commandResult.MapToIResult();
            
        Result result = await sender.Send(
            commandResult.Value!, cancellationToken);

        return result.Match(
            onFailure: _ => result.MapToIResult(),
            onSuccess: () => Results.Ok());
    }
}