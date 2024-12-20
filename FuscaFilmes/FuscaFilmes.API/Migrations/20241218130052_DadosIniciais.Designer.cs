﻿// <auto-generated />
using System;
using FuscaFilmes.API.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FuscaFilmes.API.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20241218130052_DadosIniciais")]
    partial class DadosIniciais
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.4");

            modelBuilder.Entity("FuscaFilmes.API.Entities.Diretor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Diretores");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Christopher Nolan"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Quentin Tarantino"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Steven Spielberg"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Martin Scorsese"
                        },
                        new
                        {
                            Id = 5,
                            Name = "James Cameron"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Francis Ford Coppola"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Alfred Hitchcock"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Ridley Scott"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Stanley Kubrick"
                        },
                        new
                        {
                            Id = 10,
                            Name = "Peter Jackson"
                        },
                        new
                        {
                            Id = 11,
                            Name = "Denis Villeneuve"
                        },
                        new
                        {
                            Id = 12,
                            Name = "Greta Gerwig"
                        },
                        new
                        {
                            Id = 13,
                            Name = "Wes Anderson"
                        });
                });

            modelBuilder.Entity("FuscaFilmes.API.Entities.Filme", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Ano")
                        .HasColumnType("INTEGER");

                    b.Property<int>("DiretorId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("DiretorId");

                    b.ToTable("Filmes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Ano = 2014,
                            DiretorId = 1,
                            Titulo = "Interstellar"
                        },
                        new
                        {
                            Id = 2,
                            Ano = 1994,
                            DiretorId = 2,
                            Titulo = "Pulp Fiction"
                        },
                        new
                        {
                            Id = 3,
                            Ano = 2012,
                            DiretorId = 2,
                            Titulo = "Django Unchained"
                        },
                        new
                        {
                            Id = 4,
                            Ano = 1993,
                            DiretorId = 3,
                            Titulo = "Jurassic Park"
                        },
                        new
                        {
                            Id = 5,
                            Ano = 1993,
                            DiretorId = 3,
                            Titulo = "Schindler's List"
                        },
                        new
                        {
                            Id = 6,
                            Ano = 2013,
                            DiretorId = 4,
                            Titulo = "The Wolf of Wall Street"
                        },
                        new
                        {
                            Id = 7,
                            Ano = 1990,
                            DiretorId = 4,
                            Titulo = "Goodfellas"
                        },
                        new
                        {
                            Id = 8,
                            Ano = 2009,
                            DiretorId = 5,
                            Titulo = "Avatar"
                        },
                        new
                        {
                            Id = 9,
                            Ano = 1997,
                            DiretorId = 5,
                            Titulo = "Titanic"
                        },
                        new
                        {
                            Id = 10,
                            Ano = 1972,
                            DiretorId = 6,
                            Titulo = "The Godfather"
                        },
                        new
                        {
                            Id = 11,
                            Ano = 1974,
                            DiretorId = 6,
                            Titulo = "The Godfather Part II"
                        },
                        new
                        {
                            Id = 12,
                            Ano = 1960,
                            DiretorId = 7,
                            Titulo = "Psycho"
                        },
                        new
                        {
                            Id = 13,
                            Ano = 1954,
                            DiretorId = 7,
                            Titulo = "Rear Window"
                        },
                        new
                        {
                            Id = 14,
                            Ano = 2000,
                            DiretorId = 8,
                            Titulo = "Gladiator"
                        },
                        new
                        {
                            Id = 15,
                            Ano = 1982,
                            DiretorId = 8,
                            Titulo = "Blade Runner"
                        },
                        new
                        {
                            Id = 16,
                            Ano = 1968,
                            DiretorId = 9,
                            Titulo = "2001: A Space Odyssey"
                        },
                        new
                        {
                            Id = 17,
                            Ano = 1980,
                            DiretorId = 9,
                            Titulo = "The Shining"
                        },
                        new
                        {
                            Id = 18,
                            Ano = 2001,
                            DiretorId = 10,
                            Titulo = "The Lord of the Rings: The Fellowship of the Ring"
                        },
                        new
                        {
                            Id = 19,
                            Ano = 2012,
                            DiretorId = 10,
                            Titulo = "The Hobbit: An Unexpected Journey"
                        },
                        new
                        {
                            Id = 20,
                            Ano = 2021,
                            DiretorId = 11,
                            Titulo = "Dune"
                        },
                        new
                        {
                            Id = 21,
                            Ano = 2016,
                            DiretorId = 11,
                            Titulo = "Arrival"
                        },
                        new
                        {
                            Id = 22,
                            Ano = 2023,
                            DiretorId = 12,
                            Titulo = "Barbie"
                        },
                        new
                        {
                            Id = 23,
                            Ano = 2019,
                            DiretorId = 12,
                            Titulo = "Little Women"
                        },
                        new
                        {
                            Id = 24,
                            Ano = 2014,
                            DiretorId = 13,
                            Titulo = "The Grand Budapest Hotel"
                        },
                        new
                        {
                            Id = 25,
                            Ano = 2012,
                            DiretorId = 13,
                            Titulo = "Moonrise Kingdom"
                        });
                });

            modelBuilder.Entity("FuscaFilmes.API.Entities.Filme", b =>
                {
                    b.HasOne("FuscaFilmes.API.Entities.Diretor", "Diretor")
                        .WithMany("Filmes")
                        .HasForeignKey("DiretorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Diretor");
                });

            modelBuilder.Entity("FuscaFilmes.API.Entities.Diretor", b =>
                {
                    b.Navigation("Filmes");
                });
#pragma warning restore 612, 618
        }
    }
}