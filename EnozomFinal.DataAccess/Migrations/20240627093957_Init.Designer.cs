﻿// <auto-generated />
using System;
using EnozomFinal.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EnozomFinal.Persistence.Migrations
{
    [DbContext(typeof(EnozomFinalContext))]
    [Migration("20240627093957_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("EnozomFinal.Domain.Entities.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("EnozomFinal.Domain.Entities.Copy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<int>("CopyStatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("CopyStatusId");

                    b.ToTable("Copies");
                });

            modelBuilder.Entity("EnozomFinal.Domain.Entities.CopyStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("CopyStatus");
                });

            modelBuilder.Entity("EnozomFinal.Domain.Entities.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("StNumber")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("EnozomFinal.Domain.Entities.StudentCopy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateOnly>("BorrowDate")
                        .HasColumnType("date");

                    b.Property<int>("CopyId")
                        .HasColumnType("int");

                    b.Property<int>("CopyStatusId")
                        .HasColumnType("int");

                    b.Property<DateOnly>("ExpectedReturnDate")
                        .HasColumnType("date");

                    b.Property<DateOnly?>("ReturnDate")
                        .HasColumnType("date");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CopyId");

                    b.HasIndex("CopyStatusId");

                    b.HasIndex("StudentId");

                    b.ToTable("StudentSCopies");
                });

            modelBuilder.Entity("EnozomFinal.Domain.Entities.Copy", b =>
                {
                    b.HasOne("EnozomFinal.Domain.Entities.Book", "Book")
                        .WithMany()
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EnozomFinal.Domain.Entities.CopyStatus", "CopyStatus")
                        .WithMany()
                        .HasForeignKey("CopyStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("CopyStatus");
                });

            modelBuilder.Entity("EnozomFinal.Domain.Entities.StudentCopy", b =>
                {
                    b.HasOne("EnozomFinal.Domain.Entities.Copy", "Copy")
                        .WithMany()
                        .HasForeignKey("CopyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EnozomFinal.Domain.Entities.CopyStatus", "CopyStatus")
                        .WithMany()
                        .HasForeignKey("CopyStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EnozomFinal.Domain.Entities.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Copy");

                    b.Navigation("CopyStatus");

                    b.Navigation("Student");
                });
#pragma warning restore 612, 618
        }
    }
}
