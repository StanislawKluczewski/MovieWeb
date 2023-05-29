﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MoviesWeb.WebApi.DAL.Data;

#nullable disable

namespace MoviesWeb.WebApi.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ActorMovie", b =>
                {
                    b.Property<int>("ActorMoviesMovieId")
                        .HasColumnType("int");

                    b.Property<int>("ActorsActorId")
                        .HasColumnType("int");

                    b.HasKey("ActorMoviesMovieId", "ActorsActorId");

                    b.HasIndex("ActorsActorId");

                    b.ToTable("ActorMovie");
                });

            modelBuilder.Entity("MoviesWeb.WebApi.DAL.Models.Actor", b =>
                {
                    b.Property<int>("ActorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ActorId"), 1L, 1);

                    b.Property<double>("ActorMark")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Nationality")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Sex")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Surname")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("Wiek")
                        .HasColumnType("int");

                    b.HasKey("ActorId");

                    b.ToTable("Actors");
                });

            modelBuilder.Entity("MoviesWeb.WebApi.DAL.Models.Director", b =>
                {
                    b.Property<int>("DirectorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DirectorId"), 1L, 1);

                    b.Property<double>("DirectorMark")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Nationality")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Sex")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Surname")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("Wiek")
                        .HasColumnType("int");

                    b.HasKey("DirectorId");

                    b.ToTable("Directors");
                });

            modelBuilder.Entity("MoviesWeb.WebApi.DAL.Models.Movie", b =>
                {
                    b.Property<int>("MovieId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MovieId"), 1L, 1);

                    b.Property<decimal>("BoxOffice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Category")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("DateOfProduction")
                        .HasColumnType("datetime2");

                    b.Property<int>("MovieLength")
                        .HasColumnType("int");

                    b.Property<double>("MovieMark")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("ProductionCountry")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("MovieId");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("ActorMovie", b =>
                {
                    b.HasOne("MoviesWeb.WebApi.DAL.Models.Movie", null)
                        .WithMany()
                        .HasForeignKey("ActorMoviesMovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MoviesWeb.WebApi.DAL.Models.Actor", null)
                        .WithMany()
                        .HasForeignKey("ActorsActorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}