﻿using DigiDent.ClinicManagement.Application.Patients.Commands.CreateTreatmentPlan;
using DigiDent.ClinicManagement.Application.Patients.Queries.GetAllPatients;
using DigiDent.ClinicManagement.Application.Patients.Queries.GetPatientProfile;
using DigiDent.Shared.Infrastructure.Api;
using DigiDent.Shared.Kernel.ReturnTypes;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace DigiDent.ClinicManagement.API.Endpoints;

public static class PatientsEndpoints
{
    public static RouteGroupBuilder MapPatientsEndpoints(
        this RouteGroupBuilder groupBuilder)
    {
        var patientsGroup = groupBuilder.MapGroup("/patients");
        
        patientsGroup.MapGet("/", GetAllPatientsInfo);
        patientsGroup.MapGet("/{id}", GetPatientProfileInfo);
        patientsGroup.MapPost("/{id}/treatment-plans", CreateTreatmentPlan);

        return groupBuilder;
    }
    
    private static async Task<IResult> GetAllPatientsInfo(
        ISender sender,
        CancellationToken cancellationToken)
    {
        var patients = await sender.Send(
            new GetAllPatientsQuery(), cancellationToken);

        return Results.Ok(patients);
    }
    
    private static async Task<IResult> GetPatientProfileInfo(
        [FromRoute]Guid id,
        ISender sender,
        CancellationToken cancellationToken)
    {
        GetPatientProfileQuery query = new(id);
        
        PatientProfileDTO? patient = await sender.Send(
            query, cancellationToken);

        return patient is null
            ? Results.NotFound()
            : Results.Ok(patient);
    }
    
    private static async Task<IResult> CreateTreatmentPlan(
        [FromRoute]Guid id,
        [FromBody]CreateTreatmentPlanRequest request,
        ISender sender,
        CancellationToken cancellationToken)
    {
        Result<CreateTreatmentPlanCommand> commandResult = CreateTreatmentPlanCommand
            .CreateFromRequest(request, patientId: id);
        
        if (commandResult.IsFailure)
            return commandResult.MapToIResult();
        
        Result<Guid> creationResult = await sender.Send(
            commandResult.Value!, cancellationToken);

        return creationResult.Match(
            onFailure: _ => creationResult.MapToIResult(),
            onSuccess: planId => Results.Created(
                $"/patients/treatment-plans/{planId}", planId));
    }
}