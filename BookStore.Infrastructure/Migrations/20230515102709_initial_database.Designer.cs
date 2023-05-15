﻿// <auto-generated />
using System;
using BookStore.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BookStore.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230515102709_initial_database")]
    partial class initial_database
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BookStore.Domain.Models.Author", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("BookStore.Domain.Models.Book", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<Guid?>("AuthorId1")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LongDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PageNumber")
                        .HasColumnType("int");

                    b.Property<int>("ProductCode")
                        .HasColumnType("int");

                    b.Property<int>("PublishYear")
                        .HasColumnType("int");

                    b.Property<int>("PublisherId")
                        .HasColumnType("int");

                    b.Property<Guid?>("PublisherId1")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ShortDescription")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<int>("TranslatorId")
                        .HasColumnType("int");

                    b.Property<Guid?>("TranslatorId1")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("UnitPrice")
                        .HasColumnType("int");

                    b.Property<int>("Weight")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId1");

                    b.HasIndex("PublisherId1");

                    b.HasIndex("TranslatorId1");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("BookStore.Domain.Models.OrderDetail", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<Guid?>("BookId1")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("OrderHeaderId")
                        .HasColumnType("int");

                    b.Property<Guid?>("OrderHeaderId1")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("UnitPrice")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BookId1");

                    b.HasIndex("OrderHeaderId1");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("BookStore.Domain.Models.OrderHeader", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Date")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<Guid?>("UserId1")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId1");

                    b.ToTable("OrderHeaders");
                });

            modelBuilder.Entity("BookStore.Domain.Models.Publisher", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.HasKey("Id");

                    b.ToTable("Publishers");
                });

            modelBuilder.Entity("BookStore.Domain.Models.Translator", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.ToTable("Translators");
                });

            modelBuilder.Entity("BookStore.Domain.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("LastName")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("NationalId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BookStore.Domain.Models.Book", b =>
                {
                    b.HasOne("BookStore.Domain.Models.Author", "Author")
                        .WithMany("Books")
                        .HasForeignKey("AuthorId1");

                    b.HasOne("BookStore.Domain.Models.Publisher", "Publisher")
                        .WithMany("Books")
                        .HasForeignKey("PublisherId1");

                    b.HasOne("BookStore.Domain.Models.Translator", "Translator")
                        .WithMany("Books")
                        .HasForeignKey("TranslatorId1");

                    b.Navigation("Author");

                    b.Navigation("Publisher");

                    b.Navigation("Translator");
                });

            modelBuilder.Entity("BookStore.Domain.Models.OrderDetail", b =>
                {
                    b.HasOne("BookStore.Domain.Models.Book", "Book")
                        .WithMany()
                        .HasForeignKey("BookId1");

                    b.HasOne("BookStore.Domain.Models.OrderHeader", "OrderHeader")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderHeaderId1");

                    b.Navigation("Book");

                    b.Navigation("OrderHeader");
                });

            modelBuilder.Entity("BookStore.Domain.Models.OrderHeader", b =>
                {
                    b.HasOne("BookStore.Domain.Models.User", "User")
                        .WithMany("OrderHeaders")
                        .HasForeignKey("UserId1");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BookStore.Domain.Models.Author", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("BookStore.Domain.Models.OrderHeader", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("BookStore.Domain.Models.Publisher", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("BookStore.Domain.Models.Translator", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("BookStore.Domain.Models.User", b =>
                {
                    b.Navigation("OrderHeaders");
                });
#pragma warning restore 612, 618
        }
    }
}
