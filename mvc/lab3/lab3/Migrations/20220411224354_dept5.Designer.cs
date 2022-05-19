﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using lab3.Data;

#nullable disable

namespace lab3.Migrations
{
    [DbContext(typeof(itidatabaseContext))]
    [Migration("20220411224354_dept5")]
    partial class dept5
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Departmentcourse", b =>
                {
                    b.Property<int>("departmentsDeptId")
                        .HasColumnType("int");

                    b.Property<int>("deptCoursecourseId")
                        .HasColumnType("int");

                    b.HasKey("departmentsDeptId", "deptCoursecourseId");

                    b.HasIndex("deptCoursecourseId");

                    b.ToTable("Departmentcourse");
                });

            modelBuilder.Entity("lab3.Models.course", b =>
                {
                    b.Property<int>("courseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("courseId"), 1L, 1);

                    b.Property<string>("courseName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("courseId");

                    b.ToTable("course");
                });

            modelBuilder.Entity("lab3.Models.Department", b =>
                {
                    b.Property<int>("DeptId")
                        .HasColumnType("int");

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DeptId");

                    b.ToTable("department");
                });

            modelBuilder.Entity("lab3.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StdImg")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("age")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("deptno")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("deptno");

                    b.ToTable("students");
                });

            modelBuilder.Entity("Departmentcourse", b =>
                {
                    b.HasOne("lab3.Models.Department", null)
                        .WithMany()
                        .HasForeignKey("departmentsDeptId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("lab3.Models.course", null)
                        .WithMany()
                        .HasForeignKey("deptCoursecourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("lab3.Models.Student", b =>
                {
                    b.HasOne("lab3.Models.Department", "department")
                        .WithMany("students")
                        .HasForeignKey("deptno")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("department");
                });

            modelBuilder.Entity("lab3.Models.Department", b =>
                {
                    b.Navigation("students");
                });
#pragma warning restore 612, 618
        }
    }
}