﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence.Contexts;

#nullable disable

namespace Persistence.Migrations
{
    [DbContext(typeof(BaseDbContext))]
    partial class BaseDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.ProgrammingLanguage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.ToTable("ProgrammingLanguages", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "C#"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Java"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Python"
                        });
                });

            modelBuilder.Entity("Domain.Entities.SoftwareTech", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Name");

                    b.Property<int?>("ProgrammingLanguageId")
                        .HasColumnType("int")
                        .HasColumnName("ProgrammingLanguageId");

                    b.HasKey("Id");

                    b.HasIndex("ProgrammingLanguageId");

                    b.ToTable("SoftwareTechs", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "WPF",
                            ProgrammingLanguageId = 1
                        },
                        new
                        {
                            Id = 2,
                            Name = "ASP.NET",
                            ProgrammingLanguageId = 1
                        },
                        new
                        {
                            Id = 3,
                            Name = "Spring",
                            ProgrammingLanguageId = 2
                        },
                        new
                        {
                            Id = 4,
                            Name = "JSP",
                            ProgrammingLanguageId = 2
                        },
                        new
                        {
                            Id = 5,
                            Name = "Vue",
                            ProgrammingLanguageId = 3
                        },
                        new
                        {
                            Id = 6,
                            Name = "React",
                            ProgrammingLanguageId = 3
                        });
                });

            modelBuilder.Entity("Domain.Entities.SoftwareTech", b =>
                {
                    b.HasOne("Domain.Entities.ProgrammingLanguage", "ProgrammingLanguage")
                        .WithMany("SoftwareTechs")
                        .HasForeignKey("ProgrammingLanguageId");

                    b.Navigation("ProgrammingLanguage");
                });

            modelBuilder.Entity("Domain.Entities.ProgrammingLanguage", b =>
                {
                    b.Navigation("SoftwareTechs");
                });
#pragma warning restore 612, 618
        }
    }
}
