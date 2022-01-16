﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RestApiMocker.Data;

#nullable disable

namespace RestApiMocker.Data.Migrations
{
    [DbContext(typeof(MockerContext))]
    partial class MockerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("RestApiMocker.Data.Entities.AppRule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Method")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ResponseBody")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ResponseStatus")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("AppRule");
                });

            modelBuilder.Entity("RestApiMocker.Data.Entities.ResponseHeader", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("AppRuleId")
                        .HasColumnType("int");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AppRuleId");

                    b.ToTable("ResponseHeaders");
                });

            modelBuilder.Entity("RestApiMocker.Data.Entities.ResponseHeader", b =>
                {
                    b.HasOne("RestApiMocker.Data.Entities.AppRule", null)
                        .WithMany("ResponseHeaders")
                        .HasForeignKey("AppRuleId");
                });

            modelBuilder.Entity("RestApiMocker.Data.Entities.AppRule", b =>
                {
                    b.Navigation("ResponseHeaders");
                });
#pragma warning restore 612, 618
        }
    }
}
