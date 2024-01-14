﻿using DigiDent.Domain.ClinicCoreContext.Shared.Abstractions;
using DigiDent.Domain.SharedKernel.Abstractions;

namespace DigiDent.Domain.ClinicCoreContext.Patients.ValueObjects;

public record PatientId(Guid Value)
    : TypedId<Guid>(Value), IPersonId<Guid>;