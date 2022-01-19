﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RestApiMocker.Data;

#nullable disable

namespace RestApiMocker.Data.Migrations
{
    [DbContext(typeof(MockerContext))]
    [Migration("20220116223707_cascadate_delete")]
    partial class cascadate_delete
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Path")
                        .HasColumnType("nvarchar(max)");

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

                    b.Property<int>("AppRuleId")
                        .HasColumnType("int");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AppRuleId");

                    b.ToTable("ResponseHeaders");
                });

            modelBuilder.Entity("RestApiMocker.Data.Entities.ResponseHeader", b =>
                {
                    b.HasOne("RestApiMocker.Data.Entities.AppRule", "AppRule")
                        .WithMany("ResponseHeaders")
                        .HasForeignKey("AppRuleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppRule");
                });

            modelBuilder.Entity("RestApiMocker.Data.Entities.AppRule", b =>
                {
                    b.Navigation("ResponseHeaders");
                });
#pragma warning restore 612, 618
        }
    }
}
