﻿using DigiDent.Domain.ClinicCoreContext.Employees.Assistants;
using DigiDent.Domain.ClinicCoreContext.Employees.Assistants.ValueObjects;
using DigiDent.EFCorePersistence.ClinicCore.SharedConfigurations;

namespace DigiDent.EFCorePersistence.ClinicCore.Employees.Assistants;

[ClinicCoreEntityConfiguration]
public class AssistantConfiguration
    : EmployeeConfiguration<AssistantId, Guid, Assistant>
{
    
}