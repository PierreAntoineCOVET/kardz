﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Repositories.DbContexts;

namespace Repositories.Migrations.ReadDb
{
    [DbContext(typeof(ReadDbContext))]
    [Migration("20200419161014_AddDealerAndPlayerTurn")]
    partial class AddDealerAndPlayerTurn
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Repositories.ReadEntities.CoincheGame", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CurrentCards")
                        .HasColumnType("varchar(8)")
                        .HasMaxLength(8)
                        .IsUnicode(false);

                    b.Property<int>("CurrentDealer")
                        .HasColumnType("int");

                    b.Property<int>("CurrentPayerTurn")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("CoincheGames");
                });

            modelBuilder.Entity("Repositories.ReadEntities.CoinchePlayer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Cards")
                        .HasColumnType("varchar(23)")
                        .HasMaxLength(23)
                        .IsUnicode(false);

                    b.Property<Guid>("GameId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<int>("TeamNumber")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GameId", "TeamNumber");

                    b.ToTable("CoinchePlayers");
                });

            modelBuilder.Entity("Repositories.ReadEntities.CoincheTeam", b =>
                {
                    b.Property<Guid>("GameId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<int>("Score")
                        .HasColumnType("int");

                    b.HasKey("GameId", "Number");

                    b.ToTable("CoincheTeams");
                });

            modelBuilder.Entity("Repositories.ReadEntities.CoinchePlayer", b =>
                {
                    b.HasOne("Repositories.ReadEntities.CoincheTeam", "Team")
                        .WithMany("Players")
                        .HasForeignKey("GameId", "TeamNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Repositories.ReadEntities.CoincheTeam", b =>
                {
                    b.HasOne("Repositories.ReadEntities.CoincheGame", "Game")
                        .WithMany("Teams")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}