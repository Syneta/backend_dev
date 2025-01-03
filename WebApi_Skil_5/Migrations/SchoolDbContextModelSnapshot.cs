﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApi_Skil_5.Data;

#nullable disable

namespace WebApi_Skil_5.Migrations
{
    [DbContext(typeof(SchoolDbContext))]
    partial class SchoolDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SubjectTeacher", b =>
                {
                    b.Property<int>("SubjectsSubjectId")
                        .HasColumnType("int");

                    b.Property<int>("TeachersTeacherId")
                        .HasColumnType("int");

                    b.HasKey("SubjectsSubjectId", "TeachersTeacherId");

                    b.HasIndex("TeachersTeacherId");

                    b.ToTable("SubjectTeacher");

                    b.HasData(
                        new
                        {
                            SubjectsSubjectId = 1,
                            TeachersTeacherId = 1
                        },
                        new
                        {
                            SubjectsSubjectId = 2,
                            TeachersTeacherId = 2
                        });
                });

            modelBuilder.Entity("WebApi_Skil_5.Models.Group", b =>
                {
                    b.Property<int>("GroupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GroupId"));

                    b.Property<string>("GroupName")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("GroupId");

                    b.ToTable("Groups");

                    b.HasData(
                        new
                        {
                            GroupId = 1,
                            GroupName = "Group A"
                        },
                        new
                        {
                            GroupId = 2,
                            GroupName = "Group B"
                        });
                });

            modelBuilder.Entity("WebApi_Skil_5.Models.Mark", b =>
                {
                    b.Property<int>("MarkId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MarkId"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("MarkNum")
                        .HasColumnType("int");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.Property<int>("SubjectId")
                        .HasColumnType("int");

                    b.HasKey("MarkId");

                    b.HasIndex("StudentId");

                    b.ToTable("Marks");

                    b.HasData(
                        new
                        {
                            MarkId = 1,
                            Date = new DateTime(2024, 11, 12, 13, 31, 51, 770, DateTimeKind.Local).AddTicks(6149),
                            MarkNum = 90,
                            StudentId = 1,
                            SubjectId = 1
                        },
                        new
                        {
                            MarkId = 2,
                            Date = new DateTime(2024, 11, 12, 13, 31, 51, 770, DateTimeKind.Local).AddTicks(6164),
                            MarkNum = 85,
                            StudentId = 2,
                            SubjectId = 2
                        });
                });

            modelBuilder.Entity("WebApi_Skil_5.Models.Student", b =>
                {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StudentId"));

                    b.Property<int>("GroupId")
                        .HasColumnType("int");

                    b.Property<string>("StudentFirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("StudentLastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("SubjectId")
                        .HasColumnType("int");

                    b.HasKey("StudentId");

                    b.HasIndex("GroupId");

                    b.HasIndex("SubjectId");

                    b.ToTable("Students");

                    b.HasData(
                        new
                        {
                            StudentId = 1,
                            GroupId = 1,
                            StudentFirstName = "Alice",
                            StudentLastName = "Johnson"
                        },
                        new
                        {
                            StudentId = 2,
                            GroupId = 2,
                            StudentFirstName = "Bob",
                            StudentLastName = "Brown"
                        });
                });

            modelBuilder.Entity("WebApi_Skil_5.Models.Subject", b =>
                {
                    b.Property<int>("SubjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SubjectId"));

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("SubjectId");

                    b.ToTable("Subjects");

                    b.HasData(
                        new
                        {
                            SubjectId = 1,
                            Title = "Math"
                        },
                        new
                        {
                            SubjectId = 2,
                            Title = "Science"
                        });
                });

            modelBuilder.Entity("WebApi_Skil_5.Models.Teacher", b =>
                {
                    b.Property<int>("TeacherId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TeacherId"));

                    b.Property<string>("TeacherFirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("TeacherLastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("TeacherId");

                    b.ToTable("Teachers");

                    b.HasData(
                        new
                        {
                            TeacherId = 1,
                            TeacherFirstName = "John",
                            TeacherLastName = "Doe"
                        },
                        new
                        {
                            TeacherId = 2,
                            TeacherFirstName = "Jane",
                            TeacherLastName = "Smith"
                        });
                });

            modelBuilder.Entity("SubjectTeacher", b =>
                {
                    b.HasOne("WebApi_Skil_5.Models.Subject", null)
                        .WithMany()
                        .HasForeignKey("SubjectsSubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApi_Skil_5.Models.Teacher", null)
                        .WithMany()
                        .HasForeignKey("TeachersTeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebApi_Skil_5.Models.Mark", b =>
                {
                    b.HasOne("WebApi_Skil_5.Models.Student", null)
                        .WithMany("Mark")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebApi_Skil_5.Models.Student", b =>
                {
                    b.HasOne("WebApi_Skil_5.Models.Group", null)
                        .WithMany("Students")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApi_Skil_5.Models.Subject", null)
                        .WithMany("Students")
                        .HasForeignKey("SubjectId");
                });

            modelBuilder.Entity("WebApi_Skil_5.Models.Group", b =>
                {
                    b.Navigation("Students");
                });

            modelBuilder.Entity("WebApi_Skil_5.Models.Student", b =>
                {
                    b.Navigation("Mark");
                });

            modelBuilder.Entity("WebApi_Skil_5.Models.Subject", b =>
                {
                    b.Navigation("Students");
                });
#pragma warning restore 612, 618
        }
    }
}
