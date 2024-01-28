﻿using DigiDent.Domain.ClinicCoreContext.Visits.Errors;
using DigiDent.Domain.SharedKernel.Abstractions;
using DigiDent.Domain.SharedKernel.ReturnTypes;

namespace DigiDent.Domain.ClinicCoreContext.Visits.ValueObjects;

public record VisitDateTime
{
    public DateTime Value { get; }

    internal VisitDateTime(DateTime value)
    {
        Value = value;
    }
    
    public static Result<VisitDateTime> Create(
        DateTime value, IDateTimeProvider dateTimeProvider)
    {
        if (value < dateTimeProvider.Now)
        {
            return Result.Fail<VisitDateTime>(VisitDateTimeErrors
                .VisitDateTimeIsInThePast);
        }

        return Result.Ok(new VisitDateTime(value));
    }
}