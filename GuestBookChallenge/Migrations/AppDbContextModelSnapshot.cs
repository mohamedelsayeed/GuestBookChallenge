﻿// <auto-generated />
using GuestBook.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GuestBookChallenge.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("GuestBook.Models.Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Body")
                        .IsRequired()
                        .HasMaxLength(2500)
                        .HasColumnType("nvarchar(2500)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Messages");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Body = "Some random text ",
                            Title = "first",
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            Body = "Some random text ",
                            Title = "sec",
                            UserId = 1
                        },
                        new
                        {
                            Id = 3,
                            Body = "Some random text ",
                            Title = "third",
                            UserId = 1
                        },
                        new
                        {
                            Id = 4,
                            Body = "Some random text ",
                            Title = "first",
                            UserId = 2
                        },
                        new
                        {
                            Id = 5,
                            Body = "Some random text ",
                            Title = "sec",
                            UserId = 2
                        },
                        new
                        {
                            Id = 6,
                            Body = "Some random text ",
                            Title = "third",
                            UserId = 2
                        },
                        new
                        {
                            Id = 7,
                            Body = "Some random text ",
                            Title = "first",
                            UserId = 3
                        },
                        new
                        {
                            Id = 8,
                            Body = "Some random text ",
                            Title = "sec",
                            UserId = 3
                        },
                        new
                        {
                            Id = 9,
                            Body = "Some random text ",
                            Title = "third",
                            UserId = 3
                        });
                });

            modelBuilder.Entity("GuestBook.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProfilePic")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Mohamed",
                            Password = "123456",
                            UserName = "Mohamed"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Mostafa",
                            Password = "123456",
                            UserName = "Mostafa"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Mahmoud",
                            Password = "123456",
                            UserName = "Mahmoud"
                        });
                });

            modelBuilder.Entity("GuestBook.Models.Message", b =>
                {
                    b.HasOne("GuestBook.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
