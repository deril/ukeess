﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;
using Ukeess.Models;

namespace Ukeess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20171123201718_AddDepartments")]
    partial class AddDepartments
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Ukeess.Models.Department", b =>
                {
                    b.Property<int>("DepartmentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("dpID");

                    b.Property<string>("Name")
                        .HasColumnName("dpName");

                    b.HasKey("DepartmentID");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("Ukeess.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("empID");

                    b.Property<bool>("Active")
                        .HasColumnName("empActive");

                    b.Property<int>("DepartmentID")
                        .HasColumnName("emp_dpID");

                    b.Property<string>("Name")
                        .HasColumnName("empName");

                    b.HasKey("EmployeeID");

                    b.HasIndex("DepartmentID");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("Ukeess.Models.Employee", b =>
                {
                    b.HasOne("Ukeess.Models.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}