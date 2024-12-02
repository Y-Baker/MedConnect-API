﻿// <auto-generated />
using System;
using Medical.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Medical.Migrations
{
    [DbContext(typeof(MedicalContext))]
    [Migration("20241202141914_v4")]
    partial class v4
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Medical.Models.Appointment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date");

                    b.Property<string>("PatientId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Reason")
                        .HasColumnType("int");

                    b.Property<int>("RecordId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<TimeOnly>("Time")
                        .HasColumnType("time");

                    b.HasKey("Id");

                    b.HasIndex("PatientId");

                    b.HasIndex("ProviderId");

                    b.HasIndex("RecordId");

                    b.ToTable("Appointments");
                });

            modelBuilder.Entity("Medical.Models.Doctor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<DateOnly>("HireDate")
                        .HasColumnType("date");

                    b.Property<string>("ProviderId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Title")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<int>("YearExperience")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProviderId");

                    b.ToTable("Doctors");
                });

            modelBuilder.Entity("Medical.Models.Notification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AppointmentId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsSeen")
                        .HasColumnType("bit");

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AppointmentId");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("Medical.Models.Record", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("PatientId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Treatments")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("PatientId");

                    b.ToTable("Records");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "0",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "1",
                            Name = "Provider",
                            NormalizedName = "PROVIDER"
                        },
                        new
                        {
                            Id = "2",
                            Name = "Patient",
                            NormalizedName = "PATIENT"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasDiscriminator().HasValue("IdentityUser");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = "5afa67c0-043e-4276-a7bd-d0cdc560b6fa",
                            RoleId = "0"
                        },
                        new
                        {
                            UserId = "4d51a9eb-fc6f-413a-b802-f55e25ca9c38",
                            RoleId = "0"
                        },
                        new
                        {
                            UserId = "c3d14f98-f86f-4bfc-b9f5-630d39314000",
                            RoleId = "0"
                        },
                        new
                        {
                            UserId = "b0662161-3209-49a2-a9e8-19ccc5eccd8d",
                            RoleId = "0"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Medical.Models.AppUser", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasDiscriminator().HasValue("AppUser");
                });

            modelBuilder.Entity("Medical.Models.Admin", b =>
                {
                    b.HasBaseType("Medical.Models.AppUser");

                    b.HasDiscriminator().HasValue("Admin");

                    b.HasData(
                        new
                        {
                            Id = "5afa67c0-043e-4276-a7bd-d0cdc560b6fa",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "81f0e0ea-29ce-4a44-b238-cbd33a8b1f8d",
                            Email = "admin@joo.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMIN@JOO.COM",
                            NormalizedUserName = "ADMIN",
                            PasswordHash = "AQAAAAIAAYagAAAAEL6iEp5aoyk3tKoxDAfohFfny7oBdgU0mF8y7pwLQVOakAjWlrldfcs/3PM4a2cm4w==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "88bff881-0ed1-4361-a6e7-6e4415d199c6",
                            TwoFactorEnabled = false,
                            UserName = "admin",
                            CreatedAt = new DateTime(2024, 12, 2, 14, 19, 14, 220, DateTimeKind.Utc).AddTicks(226),
                            Name = "Admin"
                        },
                        new
                        {
                            Id = "4d51a9eb-fc6f-413a-b802-f55e25ca9c38",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "999361ec-951a-4602-bc33-842cc3eb2e37",
                            Email = "yuossefbakier@gmail.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "YUOSSEFBAKIER@GMAIL.COM",
                            NormalizedUserName = "YOUSEF",
                            PasswordHash = "AQAAAAIAAYagAAAAEMbN+qBoDAwsvgh3eK2sxytFu5aWbjE+q+oISuHaaksceYEr3gMJD+wb4+qJVuo90A==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "f5a01737-2685-4e4c-bc4f-58a42e9d8a9e",
                            TwoFactorEnabled = false,
                            UserName = "Yousef",
                            CreatedAt = new DateTime(2024, 12, 2, 14, 19, 14, 286, DateTimeKind.Utc).AddTicks(622),
                            Name = "Yousef Ahmed"
                        },
                        new
                        {
                            Id = "c3d14f98-f86f-4bfc-b9f5-630d39314000",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "00085640-1e58-40f2-a67c-4623a9d8b182",
                            Email = "gamalelbatawy@gmail.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "GAMALELBATAWY@GMAIL.COM",
                            NormalizedUserName = "GAMAL",
                            PasswordHash = "AQAAAAIAAYagAAAAELOrgqFxghR1UKAXjTTmCeKUYlQGsjnlCIPJda+6Fl03xMeiSV3NOxFgDhipZD4uEw==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "2b06f4a6-7a99-497b-adc1-43105b600f90",
                            TwoFactorEnabled = false,
                            UserName = "Gamal",
                            CreatedAt = new DateTime(2024, 12, 2, 14, 19, 14, 355, DateTimeKind.Utc).AddTicks(395),
                            Name = "Gamal Moemen"
                        },
                        new
                        {
                            Id = "b0662161-3209-49a2-a9e8-19ccc5eccd8d",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "abea342e-0669-4da1-9108-6bcdcae03616",
                            Email = "m.elbaadishy@gmail.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "M.ELBAADISHY@GMAIL.COM",
                            NormalizedUserName = "B3DSH",
                            PasswordHash = "AQAAAAIAAYagAAAAEO9MGD93YYIhvDAM0XJdeLUcvrG/h2S0jzIADWiFelGL6S9VwuLavFewMTA8IH+Z3g==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "b03cff07-0871-4d1b-b95a-1f7f0634d7e1",
                            TwoFactorEnabled = false,
                            UserName = "b3dsh",
                            CreatedAt = new DateTime(2024, 12, 2, 14, 19, 14, 420, DateTimeKind.Utc).AddTicks(6301),
                            Name = "Mahmoud Abdulmawlaa"
                        });
                });

            modelBuilder.Entity("Medical.Models.Patient", b =>
                {
                    b.HasBaseType("Medical.Models.AppUser");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly>("BirthDay")
                        .HasColumnType("date");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("Patient");
                });

            modelBuilder.Entity("Medical.Models.Provider", b =>
                {
                    b.HasBaseType("Medical.Models.AppUser");

                    b.Property<float>("Rate")
                        .HasColumnType("real");

                    b.Property<int>("Shift")
                        .HasColumnType("int");

                    b.Property<string>("bio")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Provider");
                });

            modelBuilder.Entity("Medical.Models.Appointment", b =>
                {
                    b.HasOne("Medical.Models.Patient", "Patient")
                        .WithMany("Appointments")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Medical.Models.Provider", "Provider")
                        .WithMany("Appointments")
                        .HasForeignKey("ProviderId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Medical.Models.Record", "Record")
                        .WithMany("Appointments")
                        .HasForeignKey("RecordId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Patient");

                    b.Navigation("Provider");

                    b.Navigation("Record");
                });

            modelBuilder.Entity("Medical.Models.Doctor", b =>
                {
                    b.HasOne("Medical.Models.Provider", "Provider")
                        .WithMany("Doctors")
                        .HasForeignKey("ProviderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Provider");
                });

            modelBuilder.Entity("Medical.Models.Notification", b =>
                {
                    b.HasOne("Medical.Models.Appointment", "Appointment")
                        .WithMany("Notification")
                        .HasForeignKey("AppointmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Appointment");
                });

            modelBuilder.Entity("Medical.Models.Record", b =>
                {
                    b.HasOne("Medical.Models.Patient", "Patient")
                        .WithMany("Records")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Medical.Models.Appointment", b =>
                {
                    b.Navigation("Notification");
                });

            modelBuilder.Entity("Medical.Models.Record", b =>
                {
                    b.Navigation("Appointments");
                });

            modelBuilder.Entity("Medical.Models.Patient", b =>
                {
                    b.Navigation("Appointments");

                    b.Navigation("Records");
                });

            modelBuilder.Entity("Medical.Models.Provider", b =>
                {
                    b.Navigation("Appointments");

                    b.Navigation("Doctors");
                });
#pragma warning restore 612, 618
        }
    }
}
