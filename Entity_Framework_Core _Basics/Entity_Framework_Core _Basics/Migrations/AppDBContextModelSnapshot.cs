﻿// <auto-generated />
using Entity_Framework_Core__Basics.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Entity_Framework_Core__Basics.Migrations
{
    [DbContext(typeof(AppDBContext))]
    partial class AppDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Entity_Framework_Core__Basics.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeId"));

                    b.Property<long>("EmpSalary")
                        .HasColumnType("bigint");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");


                    b.Property<int>("ManagerId")
                        .HasColumnType("int");

                    b.HasKey("EmployeeId");

                    b.HasIndex("ManagerId");


                    b.ToTable("Employees");
                });

            modelBuilder.Entity("Entity_Framework_Core__Basics.Models.EmployeeDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId")
                        .IsUnique();

                    b.ToTable("EmployeeDetails");

                });

            modelBuilder.Entity("Entity_Framework_Core__Basics.Models.EmployeeProject", b =>
                {
                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.HasKey("ProjectId", "EmployeeId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("EmployeeProjects");
                });

            modelBuilder.Entity("Entity_Framework_Core__Basics.Models.Manager", b =>
                {
                    b.Property<int>("ManagerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ManagerId"));

                    b.Property<string>("MngFirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MngLastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ManagerId");


                    b.ToTable("Managers");
                });


            modelBuilder.Entity("Entity_Framework_Core__Basics.Models.Project", b =>
                {
                    b.Property<int>("ProjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProjectId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProjectId");

                    b.ToTable("Project");
                });


            modelBuilder.Entity("Entity_Framework_Core__Basics.Models.Employee", b =>
                {
                    b.HasOne("Entity_Framework_Core__Basics.Models.Manager", "Manager")
                        .WithMany("Employees")
                        .HasForeignKey("ManagerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Manager");

                });

            modelBuilder.Entity("Entity_Framework_Core__Basics.Models.EmployeeDetails", b =>
                {
                    b.HasOne("Entity_Framework_Core__Basics.Models.Employee", "Employee")
                        .WithOne("EmployeeDetails")
                        .HasForeignKey("Entity_Framework_Core__Basics.Models.EmployeeDetails", "EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("Entity_Framework_Core__Basics.Models.EmployeeProject", b =>
                {
                    b.HasOne("Entity_Framework_Core__Basics.Models.Employee", "Employee")
                        .WithMany("EmployeeProjects")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entity_Framework_Core__Basics.Models.Project", "Project")
                        .WithMany("EmployeeProjects")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("Entity_Framework_Core__Basics.Models.Employee", b =>
                {
                    b.Navigation("EmployeeDetails")
                        .IsRequired();

                    b.Navigation("EmployeeProjects");
                });

            modelBuilder.Entity("Entity_Framework_Core__Basics.Models.Manager", b =>
                {
                    b.Navigation("Employees");

                });

            modelBuilder.Entity("Entity_Framework_Core__Basics.Models.Project", b =>
                {
                    b.Navigation("EmployeeProjects");
                });

            modelBuilder.Entity("Entity_Framework_Core__Basics.Models.Manager", b =>
                {
                    b.Navigation("Employees");

                });
#pragma warning restore 612, 618
        }
    }
}
