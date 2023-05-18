﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UMS.Data;

#nullable disable

namespace UMS.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230518083513_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("UMS.Models.Course", b =>
                {
                    b.Property<string>("CourseID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("CreditHours")
                        .HasColumnType("int");

                    b.Property<bool>("HasLab")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("CourseID");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("UMS.Models.Finance", b =>
                {
                    b.Property<string>("RollNo")
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("RemainingFee")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("TotalFee")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("RollNo");

                    b.ToTable("Finances");
                });

            modelBuilder.Entity("UMS.Models.Guardian", b =>
                {
                    b.Property<string>("RollNo")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("GuardianCNIC")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Relationship")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("StudentRoll")
                        .HasColumnType("int");

                    b.HasKey("RollNo");

                    b.ToTable("Guardians");
                });

            modelBuilder.Entity("UMS.Models.Student", b =>
                {
                    b.Property<string>("RollNo")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("CNIC")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("DOB")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FinanceRollNo")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("RollNo");

                    b.HasIndex("FinanceRollNo");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("UMS.Models.Studies", b =>
                {
                    b.Property<string>("RollNo")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CourseID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<TimeSpan>("Time")
                        .HasColumnType("time");

                    b.HasKey("RollNo", "CourseID");

                    b.HasIndex("CourseID");

                    b.ToTable("Studies");
                });

            modelBuilder.Entity("UMS.Models.Teacher", b =>
                {
                    b.Property<string>("TeacherID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CNIC")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("DOB")
                        .HasMaxLength(50)
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("MartialStatus")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("MaxQualification")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("TeacherID");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("UMS.Models.Teaches", b =>
                {
                    b.Property<string>("TeacherID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CourseID")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("TeacherID", "CourseID");

                    b.HasIndex("CourseID");

                    b.ToTable("Teaches");
                });

            modelBuilder.Entity("UMS.Models.Transcript", b =>
                {
                    b.Property<string>("RollNo")
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("GPA")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("GradeLetter")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RollNo");

                    b.ToTable("Transcripts");
                });

            modelBuilder.Entity("UMS.Models.Finance", b =>
                {
                    b.HasOne("UMS.Models.Student", "Student")
                        .WithMany("Finances")
                        .HasForeignKey("RollNo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");
                });

            modelBuilder.Entity("UMS.Models.Guardian", b =>
                {
                    b.HasOne("UMS.Models.Student", "Student")
                        .WithOne("Guardian")
                        .HasForeignKey("UMS.Models.Guardian", "RollNo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");
                });

            modelBuilder.Entity("UMS.Models.Student", b =>
                {
                    b.HasOne("UMS.Models.Finance", "Finance")
                        .WithMany()
                        .HasForeignKey("FinanceRollNo");

                    b.HasOne("UMS.Models.Transcript", "Transcript")
                        .WithOne("Student")
                        .HasForeignKey("UMS.Models.Student", "RollNo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Finance");

                    b.Navigation("Transcript");
                });

            modelBuilder.Entity("UMS.Models.Studies", b =>
                {
                    b.HasOne("UMS.Models.Course", "Course")
                        .WithMany("Studies")
                        .HasForeignKey("CourseID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UMS.Models.Student", "Student")
                        .WithMany("Studies")
                        .HasForeignKey("RollNo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("UMS.Models.Teaches", b =>
                {
                    b.HasOne("UMS.Models.Course", "Course")
                        .WithMany("Teaches")
                        .HasForeignKey("CourseID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UMS.Models.Teacher", "Teacher")
                        .WithMany("Teaches")
                        .HasForeignKey("TeacherID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("UMS.Models.Course", b =>
                {
                    b.Navigation("Studies");

                    b.Navigation("Teaches");
                });

            modelBuilder.Entity("UMS.Models.Student", b =>
                {
                    b.Navigation("Finances");

                    b.Navigation("Guardian");

                    b.Navigation("Studies");
                });

            modelBuilder.Entity("UMS.Models.Teacher", b =>
                {
                    b.Navigation("Teaches");
                });

            modelBuilder.Entity("UMS.Models.Transcript", b =>
                {
                    b.Navigation("Student");
                });
#pragma warning restore 612, 618
        }
    }
}
