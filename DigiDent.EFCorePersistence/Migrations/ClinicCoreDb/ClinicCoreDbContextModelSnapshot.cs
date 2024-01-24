﻿// <auto-generated />
using System;
using DigiDent.EFCorePersistence.ClinicCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DigiDent.EFCorePersistence.Migrations.ClinicCoreDb
{
    [DbContext(typeof(ClinicCoreDbContext))]
    partial class ClinicCoreDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("Clinic_Core")
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AppointmentProvidedService", b =>
                {
                    b.Property<Guid>("AppointmentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProvidedServicesId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("AppointmentId", "ProvidedServicesId");

                    b.HasIndex("ProvidedServicesId");

                    b.ToTable("AppointmentsProvidedServices", "Clinic_Core");
                });

            modelBuilder.Entity("DigiDent.Domain.ClinicCoreContext.Employees.Shared.Employee", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateOnly?>("DateOfBirth")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmployeeType")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Full Name");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Employees", "Clinic_Core");

                    b.HasDiscriminator<string>("EmployeeType").HasValue("Employee");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("DigiDent.Domain.ClinicCoreContext.Employees.Shared.SchedulePreference", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date");

                    b.Property<Guid>("EmployeeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsSetAsDayOff")
                        .HasColumnType("bit");

                    b.Property<string>("StartEndTime")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("SchedulePreferences", "Clinic_Core");
                });

            modelBuilder.Entity("DigiDent.Domain.ClinicCoreContext.Employees.Shared.WorkingDay", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date");

                    b.Property<Guid>("EmployeeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("StartEndTime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("WorkingDays", "Clinic_Core");
                });

            modelBuilder.Entity("DigiDent.Domain.ClinicCoreContext.Patients.Patient", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateOnly?>("DateOfBirth")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Full Name");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Patients", "Clinic_Core");
                });

            modelBuilder.Entity("DigiDent.Domain.ClinicCoreContext.Visits.Appointment", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DoctorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<TimeSpan>("Duration")
                        .HasColumnType("time");

                    b.Property<Guid>("PatientId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("TreatmentPlanId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("VisitDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.HasIndex("PatientId");

                    b.HasIndex("TreatmentPlanId");

                    b.ToTable("Appointments", "Clinic_Core");
                });

            modelBuilder.Entity("DigiDent.Domain.ClinicCoreContext.Visits.PastVisit", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DoctorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PatientId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("PricePaid")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ProceduresDone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<Guid?>("TreatmentPlanId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("VisitDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.HasIndex("PatientId");

                    b.HasIndex("TreatmentPlanId");

                    b.ToTable("PastVisits", "Clinic_Core");
                });

            modelBuilder.Entity("DigiDent.Domain.ClinicCoreContext.Visits.ProvidedService", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<TimeSpan>("UsualDuration")
                        .HasColumnType("time");

                    b.HasKey("Id");

                    b.ToTable("ProvidedServices", "Clinic_Core");
                });

            modelBuilder.Entity("DigiDent.Domain.ClinicCoreContext.Visits.TreatmentPlan", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateOnly?>("DateOfFinish")
                        .HasColumnType("date");

                    b.Property<DateOnly>("DateOfStart")
                        .HasColumnType("date");

                    b.Property<string>("Details")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("PatientId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PatientId");

                    b.ToTable("TreatmentPlans", "Clinic_Core");
                });

            modelBuilder.Entity("DoctorProvidedService", b =>
                {
                    b.Property<Guid>("DoctorsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProvidedServicesId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("DoctorsId", "ProvidedServicesId");

                    b.HasIndex("ProvidedServicesId");

                    b.ToTable("DoctorsProvidedServices", "Clinic_Core");
                });

            modelBuilder.Entity("DigiDent.Domain.ClinicCoreContext.Employees.Administrators.Administrator", b =>
                {
                    b.HasBaseType("DigiDent.Domain.ClinicCoreContext.Employees.Shared.Employee");

                    b.HasDiscriminator().HasValue("Administrator");
                });

            modelBuilder.Entity("DigiDent.Domain.ClinicCoreContext.Employees.Assistants.Assistant", b =>
                {
                    b.HasBaseType("DigiDent.Domain.ClinicCoreContext.Employees.Shared.Employee");

                    b.HasDiscriminator().HasValue("Assistant");
                });

            modelBuilder.Entity("DigiDent.Domain.ClinicCoreContext.Employees.Doctors.Doctor", b =>
                {
                    b.HasBaseType("DigiDent.Domain.ClinicCoreContext.Employees.Shared.Employee");

                    b.Property<string>("Biography")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Specialization")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Doctor");
                });

            modelBuilder.Entity("AppointmentProvidedService", b =>
                {
                    b.HasOne("DigiDent.Domain.ClinicCoreContext.Visits.Appointment", null)
                        .WithMany()
                        .HasForeignKey("AppointmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DigiDent.Domain.ClinicCoreContext.Visits.ProvidedService", null)
                        .WithMany()
                        .HasForeignKey("ProvidedServicesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DigiDent.Domain.ClinicCoreContext.Employees.Shared.SchedulePreference", b =>
                {
                    b.HasOne("DigiDent.Domain.ClinicCoreContext.Employees.Shared.Employee", "Employee")
                        .WithMany("SchedulePreferences")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("DigiDent.Domain.ClinicCoreContext.Employees.Shared.WorkingDay", b =>
                {
                    b.HasOne("DigiDent.Domain.ClinicCoreContext.Employees.Shared.Employee", "Employee")
                        .WithMany("WorkingDays")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("DigiDent.Domain.ClinicCoreContext.Visits.Appointment", b =>
                {
                    b.HasOne("DigiDent.Domain.ClinicCoreContext.Employees.Doctors.Doctor", "Doctor")
                        .WithMany("Appointments")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("DigiDent.Domain.ClinicCoreContext.Patients.Patient", "Patient")
                        .WithMany("Appointments")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("DigiDent.Domain.ClinicCoreContext.Visits.TreatmentPlan", "TreatmentPlan")
                        .WithMany("Appointments")
                        .HasForeignKey("TreatmentPlanId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Doctor");

                    b.Navigation("Patient");

                    b.Navigation("TreatmentPlan");
                });

            modelBuilder.Entity("DigiDent.Domain.ClinicCoreContext.Visits.PastVisit", b =>
                {
                    b.HasOne("DigiDent.Domain.ClinicCoreContext.Employees.Doctors.Doctor", "Doctor")
                        .WithMany("PastVisits")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("DigiDent.Domain.ClinicCoreContext.Patients.Patient", "Patient")
                        .WithMany("PastVisits")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("DigiDent.Domain.ClinicCoreContext.Visits.TreatmentPlan", "TreatmentPlan")
                        .WithMany("PastVisits")
                        .HasForeignKey("TreatmentPlanId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.OwnsOne("DigiDent.Domain.ClinicCoreContext.Visits.ValueObjects.Feedback", "Feedback", b1 =>
                        {
                            b1.Property<Guid>("PastVisitId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Comment")
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Feedback_Comment");

                            b1.Property<string>("Rating")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Feedback_Rating");

                            b1.HasKey("PastVisitId");

                            b1.ToTable("PastVisits", "Clinic_Core");

                            b1.WithOwner()
                                .HasForeignKey("PastVisitId");
                        });

                    b.Navigation("Doctor");

                    b.Navigation("Feedback");

                    b.Navigation("Patient");

                    b.Navigation("TreatmentPlan");
                });

            modelBuilder.Entity("DigiDent.Domain.ClinicCoreContext.Visits.ProvidedService", b =>
                {
                    b.OwnsOne("DigiDent.Domain.ClinicCoreContext.Visits.ValueObjects.ProvidedServiceDetails", "Details", b1 =>
                        {
                            b1.Property<Guid>("ProvidedServiceId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Description")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Description");

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Name");

                            b1.HasKey("ProvidedServiceId");

                            b1.ToTable("ProvidedServices", "Clinic_Core");

                            b1.WithOwner()
                                .HasForeignKey("ProvidedServiceId");
                        });

                    b.Navigation("Details")
                        .IsRequired();
                });

            modelBuilder.Entity("DigiDent.Domain.ClinicCoreContext.Visits.TreatmentPlan", b =>
                {
                    b.HasOne("DigiDent.Domain.ClinicCoreContext.Patients.Patient", "Patient")
                        .WithMany("TreatmentPlans")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("DoctorProvidedService", b =>
                {
                    b.HasOne("DigiDent.Domain.ClinicCoreContext.Employees.Doctors.Doctor", null)
                        .WithMany()
                        .HasForeignKey("DoctorsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DigiDent.Domain.ClinicCoreContext.Visits.ProvidedService", null)
                        .WithMany()
                        .HasForeignKey("ProvidedServicesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DigiDent.Domain.ClinicCoreContext.Employees.Shared.Employee", b =>
                {
                    b.Navigation("SchedulePreferences");

                    b.Navigation("WorkingDays");
                });

            modelBuilder.Entity("DigiDent.Domain.ClinicCoreContext.Patients.Patient", b =>
                {
                    b.Navigation("Appointments");

                    b.Navigation("PastVisits");

                    b.Navigation("TreatmentPlans");
                });

            modelBuilder.Entity("DigiDent.Domain.ClinicCoreContext.Visits.TreatmentPlan", b =>
                {
                    b.Navigation("Appointments");

                    b.Navigation("PastVisits");
                });

            modelBuilder.Entity("DigiDent.Domain.ClinicCoreContext.Employees.Doctors.Doctor", b =>
                {
                    b.Navigation("Appointments");

                    b.Navigation("PastVisits");
                });
#pragma warning restore 612, 618
        }
    }
}
