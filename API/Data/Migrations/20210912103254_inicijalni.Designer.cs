﻿// <auto-generated />
using System;
using API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace API.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20210912103254_inicijalni")]
    partial class inicijalni
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("API.Models.EmailAddress", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("EmailMessageId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("To")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("EmailMessageId");

                    b.ToTable("EmailAddress");
                });

            modelBuilder.Entity("API.Models.EmailMessage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Content")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("From")
                        .HasColumnType("TEXT");

                    b.Property<string>("Importance")
                        .HasColumnType("TEXT");

                    b.Property<string>("Subject")
                        .HasColumnType("TEXT");

                    b.Property<string>("To")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("EmailMessages");
                });

            modelBuilder.Entity("API.Models.EmailAddress", b =>
                {
                    b.HasOne("API.Models.EmailMessage", null)
                        .WithMany("Cc")
                        .HasForeignKey("EmailMessageId");
                });

            modelBuilder.Entity("API.Models.EmailMessage", b =>
                {
                    b.Navigation("Cc");
                });
#pragma warning restore 612, 618
        }
    }
}
