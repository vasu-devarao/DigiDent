﻿using DigiDent.Shared.Kernel.Abstractions;

namespace DigiDent.ClinicManagement.Domain.Visits.Events;

public record PastVisitCreatedDomainEvent(
    DateTime TimeOfOccurrence,
    PastVisit PastVisit): IDomainEvent;