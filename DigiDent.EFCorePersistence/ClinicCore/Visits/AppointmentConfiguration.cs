﻿using DigiDent.Domain.ClinicCoreContext.Visits;
using DigiDent.Domain.ClinicCoreContext.Visits.Enumerations;
using DigiDent.Domain.ClinicCoreContext.Visits.ValueObjects.Ids;
using DigiDent.EFCorePersistence.ClinicCore.SharedConfigurations;
using DigiDent.EFCorePersistence.Shared;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DigiDent.EFCorePersistence.ClinicCore.Visits;

[ClinicCoreEntityConfiguration]
public class AppointmentConfiguration
    : AggregateRootConfiguration<AppointmentId, Guid, Appointment>
{
    protected override void ConfigureEntity(EntityTypeBuilder<Appointment> builder)
    {
        builder
            .Property(a => a.Duration)
            .HasConversion(SharedConverters.TimeDurationConverter);

        builder
            .Property(a => a.Status)
            .HasConversion(EnumerationsConverter
                .EnumToStringConverter<AppointmentStatus>());
    }

    protected override void ConfigureAggregateRoot(EntityTypeBuilder<Appointment> builder)
    {
    }
}