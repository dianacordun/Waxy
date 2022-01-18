﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Waxy.Entities;

namespace Waxy.Migrations
{
    [DbContext(typeof(WaxyContext))]
    [Migration("20220109150951_RemoveInstagramfromCreator")]
    partial class RemoveInstagramfromCreator
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Waxy.Models.Entities.Candle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ContainerId")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("Scent")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ContainerId");

                    b.ToTable("Candles");
                });

            modelBuilder.Entity("Waxy.Models.Entities.CandleIngredient", b =>
                {
                    b.Property<int>("CandleId")
                        .HasColumnType("int");

                    b.Property<int>("IngredientId")
                        .HasColumnType("int");

                    b.HasKey("CandleId", "IngredientId");

                    b.HasIndex("IngredientId");

                    b.ToTable("CandleIngredients");
                });

            modelBuilder.Entity("Waxy.Models.Entities.Container", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Color")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Material")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Containers");
                });

            modelBuilder.Entity("Waxy.Models.Entities.Creator", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Creator");
                });

            modelBuilder.Entity("Waxy.Models.Entities.Ingredient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Ingredients");
                });

            modelBuilder.Entity("Waxy.Models.Entities.Label", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ContainerId")
                        .HasColumnType("int");

                    b.Property<int>("CreatorId")
                        .HasColumnType("int");

                    b.Property<string>("Quote")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ContainerId")
                        .IsUnique();

                    b.HasIndex("CreatorId");

                    b.ToTable("Labels");
                });

            modelBuilder.Entity("Waxy.Models.Entities.Candle", b =>
                {
                    b.HasOne("Waxy.Models.Entities.Container", "Container")
                        .WithMany("Candles")
                        .HasForeignKey("ContainerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Container");
                });

            modelBuilder.Entity("Waxy.Models.Entities.CandleIngredient", b =>
                {
                    b.HasOne("Waxy.Models.Entities.Candle", "Candle")
                        .WithMany("CandleIngredients")
                        .HasForeignKey("CandleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Waxy.Models.Entities.Ingredient", "Ingredient")
                        .WithMany("CandleIngredients")
                        .HasForeignKey("IngredientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Candle");

                    b.Navigation("Ingredient");
                });

            modelBuilder.Entity("Waxy.Models.Entities.Label", b =>
                {
                    b.HasOne("Waxy.Models.Entities.Container", "Container")
                        .WithOne("Label")
                        .HasForeignKey("Waxy.Models.Entities.Label", "ContainerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Waxy.Models.Entities.Creator", "Creator")
                        .WithMany("Labels")
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Container");

                    b.Navigation("Creator");
                });

            modelBuilder.Entity("Waxy.Models.Entities.Candle", b =>
                {
                    b.Navigation("CandleIngredients");
                });

            modelBuilder.Entity("Waxy.Models.Entities.Container", b =>
                {
                    b.Navigation("Candles");

                    b.Navigation("Label");
                });

            modelBuilder.Entity("Waxy.Models.Entities.Creator", b =>
                {
                    b.Navigation("Labels");
                });

            modelBuilder.Entity("Waxy.Models.Entities.Ingredient", b =>
                {
                    b.Navigation("CandleIngredients");
                });
#pragma warning restore 612, 618
        }
    }
}
