﻿using System.Text.Json;
using DigiDent.Domain.ClinicCoreContext.Employees.Shared.ValueObjects;
using DigiDent.Domain.ClinicCoreContext.Visits.ValueObjects;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DigiDent.EFCorePersistence.ClinicCore.SharedConfigurations;

public static class SharedConverters
{
    public static ValueConverter<Money, decimal> MoneyConverter =>
        new ValueConverter<Money, decimal>(
            money => money.Amount,
            value => new Money(value));
    
    public static ValueConverter<StartEndTime, string> StartEndTimeConverter =>
        new ValueConverter<StartEndTime, string>(
            se => JsonSerializer
                .Serialize(se, JsonSerializerOptions.Default),
            value => JsonSerializer
                .Deserialize<StartEndTime>(value, JsonSerializerOptions.Default)!);
}