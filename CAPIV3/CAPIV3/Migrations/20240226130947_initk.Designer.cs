﻿// <auto-generated />
using System;
using CAPIV3.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CAPIV3.Migrations
{
    [DbContext(typeof(Capiv3dbContext))]
    [Migration("20240226130947_initk")]
    partial class initk
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CAPIV3.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeId"));

                    b.Property<string>("EmployeeName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("ImageName")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime>("JoinDate")
                        .HasColumnType("datetime");

                    b.HasKey("EmployeeId")
                        .HasName("PK__Employee__7AD04F111923A2DF");

                    b.ToTable("Employee", (string)null);
                });

            modelBuilder.Entity("CAPIV3.Models.Experience", b =>
                {
                    b.Property<int>("ExperienceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ExperienceId"));

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<int?>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("ExperienceId")
                        .HasName("PK__tmp_ms_x__2F4E3449F1BE2DB1");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Experience", (string)null);
                });

            modelBuilder.Entity("CAPIV3.Models.TblUser", b =>
                {
                    b.Property<int>("TblUserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TblUserId"));

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime");

                    b.Property<string>("EmailId")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.HasKey("TblUserId")
                        .HasName("PK__tmp_ms_x__A717A8B9A4EA7DE2");

                    b.ToTable("TblUser", (string)null);
                });

            modelBuilder.Entity("CAPIV3.Models.Experience", b =>
                {
                    b.HasOne("CAPIV3.Models.Employee", "Employee")
                        .WithMany("Experiences")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("FK__Experienc__Emplo__31EC6D26");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("CAPIV3.Models.Employee", b =>
                {
                    b.Navigation("Experiences");
                });
#pragma warning restore 612, 618
        }
    }
}
