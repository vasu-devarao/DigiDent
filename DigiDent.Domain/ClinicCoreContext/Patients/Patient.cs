﻿using DigiDent.Domain.ClinicCoreContext.Patients.ValueObjects;
using DigiDent.Domain.ClinicCoreContext.Shared.Abstractions;
using DigiDent.Domain.ClinicCoreContext.Shared.ValueObjects;
using DigiDent.Domain.ClinicCoreContext.Visits;
using DigiDent.Domain.SharedKernel.Abstractions;
using DigiDent.Domain.SharedKernel.ValueObjects;

namespace DigiDent.Domain.ClinicCoreContext.Patients;

public class Patient:
    AggregateRoot,
    IEntity<PatientId, Guid>,
    IPerson
{
    public PatientId Id { get; init; }
    public FullName FullName { get; private set; }
    public Email Email { get; private set; }
    public PhoneNumber PhoneNumber { get; private set; }
    
    public Gender Gender { get; set; }
    public DateTime? DateOfBirth { get; private set; }
    
    public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
    public ICollection<Visit> Visits { get; set; } = new List<Visit>();
    public ICollection<TreatmentPlan> TreatmentPlans { get; set; } = new List<TreatmentPlan>();
    
    internal Patient(
        PatientId id,
        FullName fullName,
        Email email,
        PhoneNumber phoneNumber)
    {
        Id = id;
        FullName = fullName;
        Email = email;
        PhoneNumber = phoneNumber;
    }
    
    public static Patient Create(
        FullName fullName,
        Email email,
        PhoneNumber phoneNumber)
    {
        var patientId = TypedId.New<PatientId>();
        return new Patient(
            patientId,
            fullName,
            email,
            phoneNumber);
    }
}