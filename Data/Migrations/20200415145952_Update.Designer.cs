﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Poznavacka.Data;

namespace Poznavacka.Migrations
{
    [DbContext(typeof(OrganismDbContext))]
    [Migration("20200415145952_Update")]
    partial class Update
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Poznavacka.Data.DbSystem.EnumClasses.EcosystemEnumClass", b =>
                {
                    b.Property<int>("EcosystemID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Ecosystem")
                        .HasColumnType("int");

                    b.Property<int?>("SpeciesTID")
                        .HasColumnType("int");

                    b.HasKey("EcosystemID");

                    b.HasIndex("SpeciesTID");

                    b.ToTable("EcosystemEnumClass");
                });

            modelBuilder.Entity("Poznavacka.Data.DbSystem.EnumClasses.OccurenceWorldEnumClass", b =>
                {
                    b.Property<int>("OccurenceWID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("OccurenceWorld")
                        .HasColumnType("int");

                    b.Property<int?>("SpeciesTID")
                        .HasColumnType("int");

                    b.HasKey("OccurenceWID");

                    b.HasIndex("SpeciesTID");

                    b.ToTable("OccurenceWorldEnumClass");
                });

            modelBuilder.Entity("Poznavacka.Data.DbSystem.Taxons.ClassT", b =>
                {
                    b.Property<int>("ClassTID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int>("PhylumTID")
                        .HasColumnType("int");

                    b.HasKey("ClassTID");

                    b.HasIndex("PhylumTID");

                    b.ToTable("ClassT");
                });

            modelBuilder.Entity("Poznavacka.Data.DbSystem.Taxons.FamilyT", b =>
                {
                    b.Property<int>("FamilyTID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int>("OrderTID")
                        .HasColumnType("int");

                    b.HasKey("FamilyTID");

                    b.HasIndex("OrderTID");

                    b.ToTable("FamilyT");
                });

            modelBuilder.Entity("Poznavacka.Data.DbSystem.Taxons.GenusT", b =>
                {
                    b.Property<int>("GenusTID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FamilyTID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("GenusTID");

                    b.HasIndex("FamilyTID");

                    b.ToTable("GenusT");
                });

            modelBuilder.Entity("Poznavacka.Data.DbSystem.Taxons.KingdomT", b =>
                {
                    b.Property<int>("KingdomTID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("KingdomTID");

                    b.ToTable("Kingdoms");
                });

            modelBuilder.Entity("Poznavacka.Data.DbSystem.Taxons.OrderT", b =>
                {
                    b.Property<int>("OrderTID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClassTID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("OrderTID");

                    b.HasIndex("ClassTID");

                    b.ToTable("OrderT");
                });

            modelBuilder.Entity("Poznavacka.Data.DbSystem.Taxons.PhylumT", b =>
                {
                    b.Property<int>("PhylumTID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("KingdomTID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("PhylumTID");

                    b.HasIndex("KingdomTID");

                    b.ToTable("PhylumT");
                });

            modelBuilder.Entity("Poznavacka.Data.DbSystem.Taxons.SpeciesT", b =>
                {
                    b.Property<int>("SpeciesTID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(1000)")
                        .HasMaxLength(1000);

                    b.Property<int>("EcoFunction")
                        .HasColumnType("int");

                    b.Property<int>("GenusTID")
                        .HasColumnType("int");

                    b.Property<string>("ImgPath")
                        .HasColumnType("nvarchar(1000)")
                        .HasMaxLength(1000);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int>("OccurenceCR")
                        .HasColumnType("int");

                    b.Property<int>("Protection")
                        .HasColumnType("int");

                    b.Property<string>("Size")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("Use")
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.HasKey("SpeciesTID");

                    b.HasIndex("GenusTID");

                    b.ToTable("SpeciesT");
                });

            modelBuilder.Entity("Poznavacka.Data.DbSystem.EnumClasses.EcosystemEnumClass", b =>
                {
                    b.HasOne("Poznavacka.Data.DbSystem.Taxons.SpeciesT", "SpeciesT")
                        .WithMany("Ecosystems")
                        .HasForeignKey("SpeciesTID");
                });

            modelBuilder.Entity("Poznavacka.Data.DbSystem.EnumClasses.OccurenceWorldEnumClass", b =>
                {
                    b.HasOne("Poznavacka.Data.DbSystem.Taxons.SpeciesT", "SpeciesT")
                        .WithMany("OccurencesWorld")
                        .HasForeignKey("SpeciesTID");
                });

            modelBuilder.Entity("Poznavacka.Data.DbSystem.Taxons.ClassT", b =>
                {
                    b.HasOne("Poznavacka.Data.DbSystem.Taxons.PhylumT", "PhylumT")
                        .WithMany("Classes")
                        .HasForeignKey("PhylumTID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Poznavacka.Data.DbSystem.Taxons.FamilyT", b =>
                {
                    b.HasOne("Poznavacka.Data.DbSystem.Taxons.OrderT", "OrderT")
                        .WithMany("Families")
                        .HasForeignKey("OrderTID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Poznavacka.Data.DbSystem.Taxons.GenusT", b =>
                {
                    b.HasOne("Poznavacka.Data.DbSystem.Taxons.FamilyT", "FamilyT")
                        .WithMany("Genusses")
                        .HasForeignKey("FamilyTID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Poznavacka.Data.DbSystem.Taxons.OrderT", b =>
                {
                    b.HasOne("Poznavacka.Data.DbSystem.Taxons.ClassT", "ClassT")
                        .WithMany("Orders")
                        .HasForeignKey("ClassTID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Poznavacka.Data.DbSystem.Taxons.PhylumT", b =>
                {
                    b.HasOne("Poznavacka.Data.DbSystem.Taxons.KingdomT", "KingdomT")
                        .WithMany("Phylums")
                        .HasForeignKey("KingdomTID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Poznavacka.Data.DbSystem.Taxons.SpeciesT", b =>
                {
                    b.HasOne("Poznavacka.Data.DbSystem.Taxons.GenusT", "GenusT")
                        .WithMany("Species")
                        .HasForeignKey("GenusTID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
