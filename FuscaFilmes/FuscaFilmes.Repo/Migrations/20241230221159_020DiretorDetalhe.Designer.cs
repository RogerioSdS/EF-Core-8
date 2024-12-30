﻿// <auto-generated />
using System;
using FuscaFilmes.Repo.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FuscaFilmes.Repo.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20241230221159_020DiretorDetalhe")]
    partial class _020DiretorDetalhe
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.4");

            modelBuilder.Entity("FuscaFilmes.Domain.Entities.Diretor", b =>
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

            modelBuilder.Entity("FuscaFilmes.Domain.Entities.DiretorDetalhe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Biografia")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("TEXT");

                    b.Property<int>("DiretorId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("DiretorId")
                        .IsUnique();

                    b.ToTable("DiretorDetalhe");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Biografia = "Biografia do Christopher Nolan",
                            DataNascimento = new DateTime(1970, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DiretorId = 1
                        },
                        new
                        {
                            Id = 2,
                            Biografia = "Biografia do Quentin Tarantino",
                            DataNascimento = new DateTime(1963, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DiretorId = 2
                        });
                });

            modelBuilder.Entity("FuscaFilmes.Domain.Entities.DiretorFilme", b =>
                {
                    b.Property<int>("DiretorId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("FilmeId")
                        .HasColumnType("INTEGER");

                    b.HasKey("DiretorId", "FilmeId");

                    b.HasIndex("FilmeId");

                    b.ToTable("DiretoresFilmes", (string)null);

                    b.HasData(
                        new
                        {
                            DiretorId = 1,
                            FilmeId = 1
                        },
                        new
                        {
                            DiretorId = 1,
                            FilmeId = 2
                        },
                        new
                        {
                            DiretorId = 1,
                            FilmeId = 3
                        },
                        new
                        {
                            DiretorId = 2,
                            FilmeId = 4
                        },
                        new
                        {
                            DiretorId = 2,
                            FilmeId = 5
                        },
                        new
                        {
                            DiretorId = 2,
                            FilmeId = 6
                        },
                        new
                        {
                            DiretorId = 3,
                            FilmeId = 7
                        },
                        new
                        {
                            DiretorId = 3,
                            FilmeId = 8
                        },
                        new
                        {
                            DiretorId = 3,
                            FilmeId = 9
                        },
                        new
                        {
                            DiretorId = 4,
                            FilmeId = 10
                        },
                        new
                        {
                            DiretorId = 4,
                            FilmeId = 11
                        },
                        new
                        {
                            DiretorId = 4,
                            FilmeId = 12
                        },
                        new
                        {
                            DiretorId = 5,
                            FilmeId = 13
                        },
                        new
                        {
                            DiretorId = 5,
                            FilmeId = 14
                        },
                        new
                        {
                            DiretorId = 5,
                            FilmeId = 15
                        },
                        new
                        {
                            DiretorId = 6,
                            FilmeId = 16
                        },
                        new
                        {
                            DiretorId = 6,
                            FilmeId = 17
                        },
                        new
                        {
                            DiretorId = 6,
                            FilmeId = 18
                        });
                });

            modelBuilder.Entity("FuscaFilmes.Domain.Entities.Filme", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Ano")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Filmes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Ano = 2014,
                            Titulo = "Interstellar"
                        },
                        new
                        {
                            Id = 2,
                            Ano = 1994,
                            Titulo = "Pulp Fiction"
                        },
                        new
                        {
                            Id = 3,
                            Ano = 2012,
                            Titulo = "Django Unchained"
                        },
                        new
                        {
                            Id = 4,
                            Ano = 1993,
                            Titulo = "Jurassic Park"
                        },
                        new
                        {
                            Id = 5,
                            Ano = 1993,
                            Titulo = "Schindler's List"
                        },
                        new
                        {
                            Id = 6,
                            Ano = 2013,
                            Titulo = "The Wolf of Wall Street"
                        },
                        new
                        {
                            Id = 7,
                            Ano = 1990,
                            Titulo = "Goodfellas"
                        },
                        new
                        {
                            Id = 8,
                            Ano = 2009,
                            Titulo = "Avatar"
                        },
                        new
                        {
                            Id = 9,
                            Ano = 1997,
                            Titulo = "Titanic"
                        },
                        new
                        {
                            Id = 10,
                            Ano = 1972,
                            Titulo = "The Godfather"
                        },
                        new
                        {
                            Id = 11,
                            Ano = 1974,
                            Titulo = "The Godfather Part II"
                        },
                        new
                        {
                            Id = 12,
                            Ano = 1960,
                            Titulo = "Psycho"
                        },
                        new
                        {
                            Id = 13,
                            Ano = 1954,
                            Titulo = "Rear Window"
                        },
                        new
                        {
                            Id = 14,
                            Ano = 2000,
                            Titulo = "Gladiator"
                        },
                        new
                        {
                            Id = 15,
                            Ano = 1982,
                            Titulo = "Blade Runner"
                        },
                        new
                        {
                            Id = 16,
                            Ano = 1968,
                            Titulo = "2001: A Space Odyssey"
                        },
                        new
                        {
                            Id = 17,
                            Ano = 1980,
                            Titulo = "The Shining"
                        },
                        new
                        {
                            Id = 18,
                            Ano = 2001,
                            Titulo = "The Lord of the Rings: The Fellowship of the Ring"
                        },
                        new
                        {
                            Id = 19,
                            Ano = 2012,
                            Titulo = "The Hobbit: An Unexpected Journey"
                        },
                        new
                        {
                            Id = 20,
                            Ano = 2021,
                            Titulo = "Dune"
                        },
                        new
                        {
                            Id = 21,
                            Ano = 2016,
                            Titulo = "Arrival"
                        },
                        new
                        {
                            Id = 22,
                            Ano = 2023,
                            Titulo = "Barbie"
                        },
                        new
                        {
                            Id = 23,
                            Ano = 2019,
                            Titulo = "Little Women"
                        },
                        new
                        {
                            Id = 24,
                            Ano = 2014,
                            Titulo = "The Grand Budapest Hotel"
                        },
                        new
                        {
                            Id = 25,
                            Ano = 2012,
                            Titulo = "Moonrise Kingdom"
                        });
                });

            modelBuilder.Entity("FuscaFilmes.Domain.Entities.DiretorDetalhe", b =>
                {
                    b.HasOne("FuscaFilmes.Domain.Entities.Diretor", "Diretor")
                        .WithOne("DiretorDetalhe")
                        .HasForeignKey("FuscaFilmes.Domain.Entities.DiretorDetalhe", "DiretorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Diretor");
                });

            modelBuilder.Entity("FuscaFilmes.Domain.Entities.DiretorFilme", b =>
                {
                    b.HasOne("FuscaFilmes.Domain.Entities.Diretor", "Diretor")
                        .WithMany("DiretoresFilmes")
                        .HasForeignKey("DiretorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FuscaFilmes.Domain.Entities.Filme", "Filme")
                        .WithMany("DiretoresFilmes")
                        .HasForeignKey("FilmeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Diretor");

                    b.Navigation("Filme");
                });

            modelBuilder.Entity("FuscaFilmes.Domain.Entities.Diretor", b =>
                {
                    b.Navigation("DiretorDetalhe");

                    b.Navigation("DiretoresFilmes");
                });

            modelBuilder.Entity("FuscaFilmes.Domain.Entities.Filme", b =>
                {
                    b.Navigation("DiretoresFilmes");
                });
#pragma warning restore 612, 618
        }
    }
}