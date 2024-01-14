﻿using DigiDent.Domain.ClinicCoreContext.Visits.ValueObjects;
using DigiDent.Domain.SharedKernel.ReturnTypes;

namespace DigiDent.Domain.ClinicCoreContext.Visits.Errors;

public static class TimeErrors
{
    public static Error DurationIsNotPositive
        => new Error(
            ErrorType.Validation,
            nameof(TimeDuration),
            "The duration must be positive.");
}