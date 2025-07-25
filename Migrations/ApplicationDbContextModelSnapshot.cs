﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PiePayAssignment.OfferDbContext;

#nullable disable

namespace PiePayAssignment.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PiePayAssignment.Enitites.AvailableOffers", b =>
                {
                    b.Property<string>("adjustmentId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("OfferId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OfferId"));

                    b.Property<string>("adjustmentSubtype")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("adjustmentType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("banks")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("emiMonths")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("paymentInstrument")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("summary")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("adjustmentId");

                    b.ToTable("AvailableOffer");
                });
#pragma warning restore 612, 618
        }
    }
}
