﻿// <auto-generated />
using System;
using BookingSystem.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BookingSystem.Migrations
{
    [DbContext(typeof(DoctorBookingContext))]
    [Migration("20200607130205_ddr")]
    partial class ddr
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BookingSystem.Models.Areas.Area", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CreatedBy");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("Description");

                    b.Property<bool>("IsActive");

                    b.Property<Guid>("ModifiedBy");

                    b.Property<DateTime>("ModifiedOn");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Areas");
                });

            modelBuilder.Entity("BookingSystem.Models.Areas.Region", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("AreaId");

                    b.Property<Guid>("CreatedBy");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("Description");

                    b.Property<bool>("IsActive");

                    b.Property<Guid>("ModifiedBy");

                    b.Property<DateTime>("ModifiedOn");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("AreaId");

                    b.ToTable("Regions");
                });

            modelBuilder.Entity("BookingSystem.Models.Booking.Booking", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CreatedBy");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<Guid>("DoctorId");

                    b.Property<bool>("IsActive");

                    b.Property<Guid>("ModifiedBy");

                    b.Property<DateTime>("ModifiedOn");

                    b.Property<Guid>("PatentId");

                    b.Property<string>("PatentRating");

                    b.Property<bool>("Status");

                    b.Property<int>("bookingType");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.HasIndex("PatentId");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("BookingSystem.Models.DoctorDomain.Attachment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CreatedBy");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("DoctorId");

                    b.Property<Guid?>("DoctorsId");

                    b.Property<string>("DocumentName");

                    b.Property<int>("DocumentType");

                    b.Property<bool>("IsActive");

                    b.Property<Guid>("ModifiedBy");

                    b.Property<DateTime>("ModifiedOn");

                    b.Property<string>("Url");

                    b.HasKey("Id");

                    b.HasIndex("DoctorsId");

                    b.ToTable("Attachments");
                });

            modelBuilder.Entity("BookingSystem.Models.DoctorDomain.Doctor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<float>("CallCost");

                    b.Property<Guid>("CreatedBy");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("Description");

                    b.Property<float>("DiacnoseCost");

                    b.Property<string>("FullName");

                    b.Property<bool>("IsActive");

                    b.Property<int>("ListCabacty");

                    b.Property<Guid>("ModifiedBy");

                    b.Property<DateTime>("ModifiedOn");

                    b.Property<string>("Phone1");

                    b.Property<string>("Phone2");

                    b.Property<Guid>("SpecializationId");

                    b.HasKey("Id");

                    b.HasIndex("SpecializationId");

                    b.ToTable("Doctors");
                });

            modelBuilder.Entity("BookingSystem.Models.DoctorDomain.OpenDays", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CreatedBy");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<Guid>("DoctorId");

                    b.Property<int>("HoursFrom");

                    b.Property<int>("HoursTo");

                    b.Property<bool>("IsActive");

                    b.Property<Guid>("ModifiedBy");

                    b.Property<DateTime>("ModifiedOn");

                    b.Property<int>("OpenedDaysFrom");

                    b.Property<int>("OpenedDaysTo");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.ToTable("OpenDays");
                });

            modelBuilder.Entity("BookingSystem.Models.DoctorDomain.Specialization", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CreatedBy");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("Description");

                    b.Property<bool>("IsActive");

                    b.Property<Guid>("ModifiedBy");

                    b.Property<DateTime>("ModifiedOn");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Specializations");
                });

            modelBuilder.Entity("BookingSystem.Models.PatentsDomain.Patent", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<Guid>("CreatedBy");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<bool>("IsActive");

                    b.Property<Guid>("ModifiedBy");

                    b.Property<DateTime>("ModifiedOn");

                    b.Property<string>("Name");

                    b.Property<string>("Phone1");

                    b.Property<string>("Phone2");

                    b.HasKey("Id");

                    b.ToTable("Patents");
                });

            modelBuilder.Entity("BookingSystem.Models.Users.Identity", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp");

                    b.Property<string>("Email");

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail");

                    b.Property<string>("NormalizedUserName");

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.ToTable("Identity");
                });

            modelBuilder.Entity("BookingSystem.Models.Users.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("BirthDate");

                    b.Property<Guid>("CreatedBy");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("Gender");

                    b.Property<string>("IdentityId");

                    b.Property<bool>("IsActive");

                    b.Property<string>("LastName");

                    b.Property<Guid>("ModifiedBy");

                    b.Property<DateTime>("ModifiedOn");

                    b.Property<string>("Password");

                    b.Property<string>("UserName");

                    b.Property<int>("UserType");

                    b.HasKey("Id");

                    b.HasIndex("IdentityId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BookingSystem.Models.Areas.Region", b =>
                {
                    b.HasOne("BookingSystem.Models.Areas.Area", "Areas")
                        .WithMany()
                        .HasForeignKey("AreaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BookingSystem.Models.Booking.Booking", b =>
                {
                    b.HasOne("BookingSystem.Models.DoctorDomain.Doctor", "Doctors")
                        .WithMany()
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BookingSystem.Models.PatentsDomain.Patent", "Patents")
                        .WithMany()
                        .HasForeignKey("PatentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BookingSystem.Models.DoctorDomain.Attachment", b =>
                {
                    b.HasOne("BookingSystem.Models.DoctorDomain.Doctor", "Doctors")
                        .WithMany()
                        .HasForeignKey("DoctorsId");
                });

            modelBuilder.Entity("BookingSystem.Models.DoctorDomain.Doctor", b =>
                {
                    b.HasOne("BookingSystem.Models.DoctorDomain.Specialization", "Specialization")
                        .WithMany()
                        .HasForeignKey("SpecializationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BookingSystem.Models.DoctorDomain.OpenDays", b =>
                {
                    b.HasOne("BookingSystem.Models.DoctorDomain.Doctor", "Doctors")
                        .WithMany()
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BookingSystem.Models.Users.User", b =>
                {
                    b.HasOne("BookingSystem.Models.Users.Identity", "Identity")
                        .WithMany()
                        .HasForeignKey("IdentityId");
                });
#pragma warning restore 612, 618
        }
    }
}
