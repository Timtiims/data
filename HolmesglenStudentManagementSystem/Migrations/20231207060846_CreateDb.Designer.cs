﻿// <auto-generated />
using HolmesglenStudentManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HolmesglenStudentManagementSystem.Migrations
{
    [DbContext(typeof(AppDBContext))]
    [Migration("20231207060846_CreateDb")]
    partial class CreateDb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("HolmesglenStudentManagementSystem.Models.Enrollment", b =>
                {
                    b.Property<string>("EnrollmentID")
                        .HasColumnType("TEXT");

                    b.Property<string>("StudentID_FK")
                        .HasColumnType("TEXT");

                    b.Property<string>("SubjectID_FK")
                        .HasColumnType("TEXT");

                    b.HasKey("EnrollmentID");

                    b.ToTable("Enrollments");
                });

            modelBuilder.Entity("HolmesglenStudentManagementSystem.Models.Student", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("HolmesglenStudentManagementSystem.Models.Subject", b =>
                {
                    b.Property<string>("SubjectId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.HasKey("SubjectId");

                    b.ToTable("Subjects");
                });
#pragma warning restore 612, 618
        }
    }
}
