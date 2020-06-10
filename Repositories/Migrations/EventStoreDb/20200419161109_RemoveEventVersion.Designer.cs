﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Repositories.DbContexts;

namespace Repositories.Migrations.EventStoreDb
{
    [DbContext(typeof(EventStoreDbContext))]
    [Migration("20200419161109_RemoveEventVersion")]
    partial class RemoveEventVersion
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Repositories.EventStoreEntities.Aggregate", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("varchar(200)")
                        .HasMaxLength(200)
                        .IsUnicode(false);

                    b.Property<int>("Version")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Aggregates");
                });

            modelBuilder.Entity("Repositories.EventStoreEntities.Event", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AggregateId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("Author")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Datas")
                        .IsRequired()
                        .HasColumnType("varchar(1500)")
                        .HasMaxLength(1500)
                        .IsUnicode(false);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("varchar(200)")
                        .HasMaxLength(200)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.HasIndex("AggregateId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("Repositories.EventStoreEntities.Event", b =>
                {
                    b.HasOne("Repositories.EventStoreEntities.Aggregate", "Aggregate")
                        .WithMany("Events")
                        .HasForeignKey("AggregateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}