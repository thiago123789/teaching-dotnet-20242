﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NGPD.Manager.Data;

#nullable disable

namespace NGPD.Manager.Data.Migrations
{
    [DbContext(typeof(ManagerDbContext))]
    [Migration("20240711201138_adding faculdade table")]
    partial class addingfaculdadetable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("NGPD.Manager.Entities.Aluno", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("TurmaId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("TurmaId");

                    b.ToTable("Aluno");
                });

            modelBuilder.Entity("NGPD.Manager.Entities.Disponibilidade.Disponibilidade", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Disponibilidades");
                });

            modelBuilder.Entity("NGPD.Manager.Entities.Disponibilidade.MentorDisponibilidade", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("DisponibilidadeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("MentorId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("DisponibilidadeId");

                    b.HasIndex("MentorId");

                    b.ToTable("MentorDisponibilidade");
                });

            modelBuilder.Entity("NGPD.Manager.Entities.Disponibilidade.SquadDisponibilidade", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("DisponibilidadeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("SquadId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("DisponibilidadeId");

                    b.HasIndex("SquadId");

                    b.ToTable("SquadDisponibilidade");
                });

            modelBuilder.Entity("NGPD.Manager.Entities.Disponibilidade.TurmaDisponibilidade", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("DisponibilidadeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("TurmaId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("DisponibilidadeId");

                    b.HasIndex("TurmaId");

                    b.ToTable("TurmaDisponibilidade");
                });

            modelBuilder.Entity("NGPD.Manager.Entities.Empresa", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Empresa");
                });

            modelBuilder.Entity("NGPD.Manager.Entities.Faculdade", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Faculdade");
                });

            modelBuilder.Entity("NGPD.Manager.Entities.Mentor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Mentor");
                });

            modelBuilder.Entity("NGPD.Manager.Entities.Squad", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("EmpresaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("MentorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TurmaId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("EmpresaId");

                    b.HasIndex("MentorId");

                    b.HasIndex("TurmaId");

                    b.ToTable("Squad");
                });

            modelBuilder.Entity("NGPD.Manager.Entities.Turma", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("FaculdadeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("FaculdadeId");

                    b.ToTable("Turma");
                });

            modelBuilder.Entity("NGPD.Manager.Entities.Aluno", b =>
                {
                    b.HasOne("NGPD.Manager.Entities.Turma", "Turma")
                        .WithMany("Alunos")
                        .HasForeignKey("TurmaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Turma");
                });

            modelBuilder.Entity("NGPD.Manager.Entities.Disponibilidade.Disponibilidade", b =>
                {
                    b.OwnsOne("NGPD.Manager.Entities.Disponibilidade.IntervaloTempo", "IntervaloTempo", b1 =>
                        {
                            b1.Property<Guid>("DisponibilidadeId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<TimeSpan>("From")
                                .HasColumnType("time");

                            b1.Property<TimeSpan>("To")
                                .HasColumnType("time");

                            b1.HasKey("DisponibilidadeId");

                            b1.ToTable("Disponibilidades");

                            b1.WithOwner()
                                .HasForeignKey("DisponibilidadeId");

                            b1.OwnsOne("NGPD.Manager.Entities.Disponibilidade.DiaSemana", "DiaSemana", b2 =>
                                {
                                    b2.Property<Guid>("IntervaloTempoDisponibilidadeId")
                                        .HasColumnType("uniqueidentifier");

                                    b2.Property<int>("Id")
                                        .HasColumnType("int");

                                    b2.Property<string>("Name")
                                        .IsRequired()
                                        .HasColumnType("nvarchar(max)");

                                    b2.HasKey("IntervaloTempoDisponibilidadeId");

                                    b2.ToTable("Disponibilidades");

                                    b2.WithOwner()
                                        .HasForeignKey("IntervaloTempoDisponibilidadeId");
                                });

                            b1.Navigation("DiaSemana")
                                .IsRequired();
                        });

                    b.Navigation("IntervaloTempo")
                        .IsRequired();
                });

            modelBuilder.Entity("NGPD.Manager.Entities.Disponibilidade.MentorDisponibilidade", b =>
                {
                    b.HasOne("NGPD.Manager.Entities.Disponibilidade.Disponibilidade", "Disponibilidade")
                        .WithMany()
                        .HasForeignKey("DisponibilidadeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NGPD.Manager.Entities.Mentor", "Mentor")
                        .WithMany("MentorDisponibilidades")
                        .HasForeignKey("MentorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Disponibilidade");

                    b.Navigation("Mentor");
                });

            modelBuilder.Entity("NGPD.Manager.Entities.Disponibilidade.SquadDisponibilidade", b =>
                {
                    b.HasOne("NGPD.Manager.Entities.Disponibilidade.Disponibilidade", "Disponibilidade")
                        .WithMany()
                        .HasForeignKey("DisponibilidadeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NGPD.Manager.Entities.Squad", "Squad")
                        .WithMany("SquadDisponibilidades")
                        .HasForeignKey("SquadId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Disponibilidade");

                    b.Navigation("Squad");
                });

            modelBuilder.Entity("NGPD.Manager.Entities.Disponibilidade.TurmaDisponibilidade", b =>
                {
                    b.HasOne("NGPD.Manager.Entities.Disponibilidade.Disponibilidade", "Disponibilidade")
                        .WithMany()
                        .HasForeignKey("DisponibilidadeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NGPD.Manager.Entities.Turma", "Turma")
                        .WithMany("TurmaDisponibilidades")
                        .HasForeignKey("TurmaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Disponibilidade");

                    b.Navigation("Turma");
                });

            modelBuilder.Entity("NGPD.Manager.Entities.Squad", b =>
                {
                    b.HasOne("NGPD.Manager.Entities.Empresa", "Empresa")
                        .WithMany()
                        .HasForeignKey("EmpresaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NGPD.Manager.Entities.Mentor", "Mentor")
                        .WithMany("Squads")
                        .HasForeignKey("MentorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NGPD.Manager.Entities.Turma", "Turma")
                        .WithMany()
                        .HasForeignKey("TurmaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Empresa");

                    b.Navigation("Mentor");

                    b.Navigation("Turma");
                });

            modelBuilder.Entity("NGPD.Manager.Entities.Turma", b =>
                {
                    b.HasOne("NGPD.Manager.Entities.Faculdade", null)
                        .WithMany("Turmas")
                        .HasForeignKey("FaculdadeId");
                });

            modelBuilder.Entity("NGPD.Manager.Entities.Faculdade", b =>
                {
                    b.Navigation("Turmas");
                });

            modelBuilder.Entity("NGPD.Manager.Entities.Mentor", b =>
                {
                    b.Navigation("MentorDisponibilidades");

                    b.Navigation("Squads");
                });

            modelBuilder.Entity("NGPD.Manager.Entities.Squad", b =>
                {
                    b.Navigation("SquadDisponibilidades");
                });

            modelBuilder.Entity("NGPD.Manager.Entities.Turma", b =>
                {
                    b.Navigation("Alunos");

                    b.Navigation("TurmaDisponibilidades");
                });
#pragma warning restore 612, 618
        }
    }
}
