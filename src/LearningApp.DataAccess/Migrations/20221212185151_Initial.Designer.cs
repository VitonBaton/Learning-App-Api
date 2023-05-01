﻿// <auto-generated />
using System;
using LearningApp.DataAccess;
using LearningApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace LearningApp.Models.Migrations
{
    [DbContext(typeof(LearningDbContext))]
    [Migration("20221212185151_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("LearningApp.Models.Models.Chapter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Order")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Chapters");
                });

            modelBuilder.Entity("LearningApp.Models.Models.ChapterTest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ChapterId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ChapterId");

                    b.ToTable("ChapterTests");
                });

            modelBuilder.Entity("LearningApp.Models.Models.ChapterTestAnswer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Answer")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("ChapterTestQuestionId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("ChapterTestQuestionId");

                    b.ToTable("ChapterTestAnswers");
                });

            modelBuilder.Entity("LearningApp.Models.Models.ChapterTestQuestion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ChapterTestId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Order")
                        .HasColumnType("integer");

                    b.Property<string>("Question")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ChapterTestId");

                    b.ToTable("ChapterTestQuestions");
                });

            modelBuilder.Entity("LearningApp.Models.Models.Lecture", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ChapterId")
                        .HasColumnType("integer");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Order")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ChapterId");

                    b.ToTable("Lectures");
                });

            modelBuilder.Entity("LearningApp.Models.Models.LectureTest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("LectureId")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("LectureId");

                    b.ToTable("LectureTests");
                });

            modelBuilder.Entity("LearningApp.Models.Models.LectureTestAnswer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Answer")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("LectureTestQuestionId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("LectureTestQuestionId");

                    b.ToTable("LectureTestAnswers");
                });

            modelBuilder.Entity("LearningApp.Models.Models.LectureTestQuestion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("LectureTestId")
                        .HasColumnType("integer");

                    b.Property<int>("Order")
                        .HasColumnType("integer");

                    b.Property<string>("Question")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("LectureTestId");

                    b.ToTable("LectureTestQuestions");
                });

            modelBuilder.Entity("LearningApp.Models.Models.ChapterTest", b =>
                {
                    b.HasOne("LearningApp.Models.Models.Chapter", "Chapter")
                        .WithMany("ChapterTests")
                        .HasForeignKey("ChapterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Chapter");
                });

            modelBuilder.Entity("LearningApp.Models.Models.ChapterTestAnswer", b =>
                {
                    b.HasOne("LearningApp.Models.Models.ChapterTestQuestion", "ChapterTestQuestion")
                        .WithMany("ChapterTestAnswers")
                        .HasForeignKey("ChapterTestQuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ChapterTestQuestion");
                });

            modelBuilder.Entity("LearningApp.Models.Models.ChapterTestQuestion", b =>
                {
                    b.HasOne("LearningApp.Models.Models.ChapterTest", "ChapterTest")
                        .WithMany("ChapterTestQuestions")
                        .HasForeignKey("ChapterTestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ChapterTest");
                });

            modelBuilder.Entity("LearningApp.Models.Models.Lecture", b =>
                {
                    b.HasOne("LearningApp.Models.Models.Chapter", "Chapter")
                        .WithMany("Lectures")
                        .HasForeignKey("ChapterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Chapter");
                });

            modelBuilder.Entity("LearningApp.Models.Models.LectureTest", b =>
                {
                    b.HasOne("LearningApp.Models.Models.Lecture", "Lecture")
                        .WithMany("Tests")
                        .HasForeignKey("LectureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lecture");
                });

            modelBuilder.Entity("LearningApp.Models.Models.LectureTestAnswer", b =>
                {
                    b.HasOne("LearningApp.Models.Models.LectureTestQuestion", "LectureTestQuestion")
                        .WithMany("LectureTestAnswers")
                        .HasForeignKey("LectureTestQuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LectureTestQuestion");
                });

            modelBuilder.Entity("LearningApp.Models.Models.LectureTestQuestion", b =>
                {
                    b.HasOne("LearningApp.Models.Models.LectureTest", "LectureTest")
                        .WithMany("LectureTestQuestions")
                        .HasForeignKey("LectureTestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LectureTest");
                });

            modelBuilder.Entity("LearningApp.Models.Models.Chapter", b =>
                {
                    b.Navigation("ChapterTests");

                    b.Navigation("Lectures");
                });

            modelBuilder.Entity("LearningApp.Models.Models.ChapterTest", b =>
                {
                    b.Navigation("ChapterTestQuestions");
                });

            modelBuilder.Entity("LearningApp.Models.Models.ChapterTestQuestion", b =>
                {
                    b.Navigation("ChapterTestAnswers");
                });

            modelBuilder.Entity("LearningApp.Models.Models.Lecture", b =>
                {
                    b.Navigation("Tests");
                });

            modelBuilder.Entity("LearningApp.Models.Models.LectureTest", b =>
                {
                    b.Navigation("LectureTestQuestions");
                });

            modelBuilder.Entity("LearningApp.Models.Models.LectureTestQuestion", b =>
                {
                    b.Navigation("LectureTestAnswers");
                });
#pragma warning restore 612, 618
        }
    }
}