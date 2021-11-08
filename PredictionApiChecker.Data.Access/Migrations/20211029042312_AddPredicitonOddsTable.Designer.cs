﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PredictionApiChecker.Data.Access.DAL;

namespace PredictionApiChecker.Data.Access.Migrations
{
    [DbContext(typeof(MainDbContext))]
    [Migration("20211029042312_AddPredicitonOddsTable")]
    partial class AddPredicitonOddsTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.11");

            modelBuilder.Entity("PredictionApiChecker.Data.Models.Football.PredictionOdd", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("Coefficient")
                        .HasColumnType("REAL");

                    b.Property<byte>("OddType")
                        .HasColumnType("INTEGER");

                    b.Property<long>("PredictionRecordId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("PredicitonOdds");
                });

            modelBuilder.Entity("PredictionApiChecker.Data.Models.Football.PredictionRecord", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AwayTeam")
                        .HasColumnType("TEXT");

                    b.Property<string>("CompetionName")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("HomeTeam")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsExpired")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsUpdated")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("LastUpdateDate")
                        .HasColumnType("TEXT");

                    b.Property<byte>("Prediction")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("TEXT");

                    b.Property<byte>("Status")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("PredictionRecords");
                });
#pragma warning restore 612, 618
        }
    }
}
