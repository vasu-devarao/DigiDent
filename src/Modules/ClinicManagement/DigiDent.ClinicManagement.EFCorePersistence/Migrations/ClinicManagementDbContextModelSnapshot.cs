﻿// <auto-generated />
using System;
using DigiDent.ClinicManagement.EFCorePersistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DigiDent.ClinicManagement.EFCorePersistence.Migrations
{
    [DbContext(typeof(ClinicManagementDbContext))]
    partial class ClinicManagementDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("clinic_management")
                .HasAnnotation("ProductVersion", "8.0.1")
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

                    b.ToTable("AppointmentsProvidedServices", "clinic_management");
                });

            modelBuilder.Entity("DigiDent.ClinicManagement.Domain.Employees.Shared.Employee", b =>
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

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Employees", "clinic_management");

                    b.HasDiscriminator<string>("EmployeeType").HasValue("Employee");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("DigiDent.ClinicManagement.Domain.Employees.Shared.SchedulePreference", b =>
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

                    b.ToTable("SchedulePreferences", "clinic_management");
                });

            modelBuilder.Entity("DigiDent.ClinicManagement.Domain.Employees.Shared.WorkingDay", b =>
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

                    b.ToTable("WorkingDays", "clinic_management");
                });

            modelBuilder.Entity("DigiDent.ClinicManagement.Domain.Patients.Patient", b =>
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

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Patients", "clinic_management");
                });

            modelBuilder.Entity("DigiDent.ClinicManagement.Domain.Patients.TreatmentPlan", b =>
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

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PatientId");

                    b.ToTable("TreatmentPlans", "clinic_management");
                });

            modelBuilder.Entity("DigiDent.ClinicManagement.Domain.Visits.Appointment", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DoctorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<TimeSpan>("Duration")
                        .HasColumnType("time");

                    b.Property<Guid>("PatientId")
                        .HasColumnType("uniqueidentifier");

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

                    b.ToTable("Appointments", "clinic_management");
                });

            modelBuilder.Entity("DigiDent.ClinicManagement.Domain.Visits.PastVisit", b =>
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

                    b.ToTable("PastVisits", "clinic_management");
                });

            modelBuilder.Entity("DigiDent.ClinicManagement.Domain.Visits.ProvidedService", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<TimeSpan>("UsualDuration")
                        .HasColumnType("time");

                    b.HasKey("Id");

                    b.ToTable("ProvidedServices", "clinic_management");
                });

            modelBuilder.Entity("DoctorProvidedService", b =>
                {
                    b.Property<Guid>("DoctorsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProvidedServicesId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("DoctorsId", "ProvidedServicesId");

                    b.HasIndex("ProvidedServicesId");

                    b.ToTable("DoctorsProvidedServices", "clinic_management");
                });

            modelBuilder.Entity("DigiDent.ClinicManagement.Domain.Employees.Administrators.Administrator", b =>
                {
                    b.HasBaseType("DigiDent.ClinicManagement.Domain.Employees.Shared.Employee");

                    b.HasDiscriminator().HasValue("Administrator");
                });

            modelBuilder.Entity("DigiDent.ClinicManagement.Domain.Employees.Assistants.Assistant", b =>
                {
                    b.HasBaseType("DigiDent.ClinicManagement.Domain.Employees.Shared.Employee");

                    b.HasDiscriminator().HasValue("Assistant");
                });

            modelBuilder.Entity("DigiDent.ClinicManagement.Domain.Employees.Doctors.Doctor", b =>
                {
                    b.HasBaseType("DigiDent.ClinicManagement.Domain.Employees.Shared.Employee");

                    b.Property<string>("Biography")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Specialization")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("Doctor");
                });

            modelBuilder.Entity("AppointmentProvidedService", b =>
                {
                    b.HasOne("DigiDent.ClinicManagement.Domain.Visits.Appointment", null)
                        .WithMany()
                        .HasForeignKey("AppointmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DigiDent.ClinicManagement.Domain.Visits.ProvidedService", null)
                        .WithMany()
                        .HasForeignKey("ProvidedServicesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DigiDent.ClinicManagement.Domain.Employees.Shared.SchedulePreference", b =>
                {
                    b.HasOne("DigiDent.ClinicManagement.Domain.Employees.Shared.Employee", "Employee")
                        .WithMany("SchedulePreferences")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("DigiDent.ClinicManagement.Domain.Employees.Shared.WorkingDay", b =>
                {
                    b.HasOne("DigiDent.ClinicManagement.Domain.Employees.Shared.Employee", "Employee")
                        .WithMany("WorkingDays")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("DigiDent.ClinicManagement.Domain.Patients.TreatmentPlan", b =>
                {
                    b.HasOne("DigiDent.ClinicManagement.Domain.Patients.Patient", "Patient")
                        .WithMany("TreatmentPlans")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("DigiDent.ClinicManagement.Domain.Visits.Appointment", b =>
                {
                    b.HasOne("DigiDent.ClinicManagement.Domain.Employees.Doctors.Doctor", "Doctor")
                        .WithMany("Appointments")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("DigiDent.ClinicManagement.Domain.Patients.Patient", "Patient")
                        .WithMany("Appointments")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("DigiDent.ClinicManagement.Domain.Patients.TreatmentPlan", "TreatmentPlan")
                        .WithMany("Appointments")
                        .HasForeignKey("TreatmentPlanId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Doctor");

                    b.Navigation("Patient");

                    b.Navigation("TreatmentPlan");
                });

            modelBuilder.Entity("DigiDent.ClinicManagement.Domain.Visits.PastVisit", b =>
                {
                    b.HasOne("DigiDent.ClinicManagement.Domain.Employees.Doctors.Doctor", "Doctor")
                        .WithMany("PastVisits")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("DigiDent.ClinicManagement.Domain.Patients.Patient", "Patient")
                        .WithMany("PastVisits")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("DigiDent.ClinicManagement.Domain.Patients.TreatmentPlan", "TreatmentPlan")
                        .WithMany("PastVisits")
                        .HasForeignKey("TreatmentPlanId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.OwnsOne("DigiDent.ClinicManagement.Domain.Visits.ValueObjects.Feedback", "Feedback", b1 =>
                        {
                            b1.Property<Guid>("PastVisitId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Comment")
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Feedback_Comment");

                            b1.Property<int>("Rating")
                                .HasColumnType("int")
                                .HasColumnName("Feedback_Rating");

                            b1.HasKey("PastVisitId");

                            b1.ToTable("PastVisits", "clinic_management");

                            b1.WithOwner()
                                .HasForeignKey("PastVisitId");
                        });

                    b.Navigation("Doctor");

                    b.Navigation("Feedback");

                    b.Navigation("Patient");

                    b.Navigation("TreatmentPlan");
                });

            modelBuilder.Entity("DigiDent.ClinicManagement.Domain.Visits.ProvidedService", b =>
                {
                    b.OwnsOne("DigiDent.ClinicManagement.Domain.Visits.ValueObjects.ProvidedServiceDetails", "Details", b1 =>
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

                            b1.ToTable("ProvidedServices", "clinic_management");

                            b1.WithOwner()
                                .HasForeignKey("ProvidedServiceId");
                        });

                    b.Navigation("Details")
                        .IsRequired();
                });

            modelBuilder.Entity("DoctorProvidedService", b =>
                {
                    b.HasOne("DigiDent.ClinicManagement.Domain.Employees.Doctors.Doctor", null)
                        .WithMany()
                        .HasForeignKey("DoctorsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DigiDent.ClinicManagement.Domain.Visits.ProvidedService", null)
                        .WithMany()
                        .HasForeignKey("ProvidedServicesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DigiDent.ClinicManagement.Domain.Employees.Shared.Employee", b =>
                {
                    b.Navigation("SchedulePreferences");

                    b.Navigation("WorkingDays");
                });

            modelBuilder.Entity("DigiDent.ClinicManagement.Domain.Patients.Patient", b =>
                {
                    b.Navigation("Appointments");

                    b.Navigation("PastVisits");

                    b.Navigation("TreatmentPlans");
                });

            modelBuilder.Entity("DigiDent.ClinicManagement.Domain.Patients.TreatmentPlan", b =>
                {
                    b.Navigation("Appointments");

                    b.Navigation("PastVisits");
                });

            modelBuilder.Entity("DigiDent.ClinicManagement.Domain.Employees.Doctors.Doctor", b =>
                {
                    b.Navigation("Appointments");

                    b.Navigation("PastVisits");
                });
#pragma warning restore 612, 618
        }
    }
}
