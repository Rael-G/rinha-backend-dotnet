﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Rinha.Api;

#nullable disable

namespace Rinha.Api.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240206233026_Searchable")]
    partial class Searchable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Rinha.Api.Pessoa", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Apelido")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("character varying(32)");

                    b.Property<DateTime>("Nascimento")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Searchable")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string[]>("Stack")
                        .HasMaxLength(32)
                        .HasColumnType("text[]");

                    b.HasKey("Id");

                    b.HasIndex("Apelido")
                        .IsUnique();

                    b.ToTable("Pessoas");
                });
#pragma warning restore 612, 618
        }
    }
}
