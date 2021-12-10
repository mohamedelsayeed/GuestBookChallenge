﻿// <auto-generated />
using System;
using GuestBookChallenge.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GuestBookChallenge.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20211210121250_messageCreatedDate")]
    partial class messageCreatedDate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("GuestBookChallenge.Models.Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Body")
                        .IsRequired()
                        .HasMaxLength(2500)
                        .HasColumnType("nvarchar(2500)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Messages");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Body = "Some random text ",
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "first",
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            Body = "Some random text ",
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "sec",
                            UserId = 1
                        },
                        new
                        {
                            Id = 3,
                            Body = "Some random text ",
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "third",
                            UserId = 1
                        },
                        new
                        {
                            Id = 4,
                            Body = "Some random text ",
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "first",
                            UserId = 2
                        },
                        new
                        {
                            Id = 5,
                            Body = "Some random text ",
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "sec",
                            UserId = 2
                        },
                        new
                        {
                            Id = 6,
                            Body = "Some random text ",
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "third",
                            UserId = 2
                        },
                        new
                        {
                            Id = 7,
                            Body = "Some random text ",
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "first",
                            UserId = 3
                        },
                        new
                        {
                            Id = 8,
                            Body = "Some random text ",
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "sec",
                            UserId = 3
                        },
                        new
                        {
                            Id = 9,
                            Body = "Some random text ",
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "third",
                            UserId = 3
                        });
                });

            modelBuilder.Entity("GuestBookChallenge.Models.Reply", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Body")
                        .IsRequired()
                        .HasMaxLength(2500)
                        .HasColumnType("nvarchar(2500)");

                    b.Property<int?>("MessageId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MessageId");

                    b.HasIndex("UserId");

                    b.ToTable("Replys");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Body = "Some random reply ",
                            MessageId = 1,
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            Body = "Some random  reply",
                            MessageId = 2,
                            UserId = 1
                        },
                        new
                        {
                            Id = 3,
                            Body = "Some random reply ",
                            MessageId = 3,
                            UserId = 1
                        },
                        new
                        {
                            Id = 4,
                            Body = "Some random reply ",
                            MessageId = 4,
                            UserId = 2
                        },
                        new
                        {
                            Id = 5,
                            Body = "Some random  reply",
                            MessageId = 5,
                            UserId = 2
                        },
                        new
                        {
                            Id = 6,
                            Body = "Some random reply ",
                            MessageId = 6,
                            UserId = 2
                        },
                        new
                        {
                            Id = 7,
                            Body = "Some random reply ",
                            MessageId = 7,
                            UserId = 3
                        },
                        new
                        {
                            Id = 8,
                            Body = "Some random  reply",
                            MessageId = 8,
                            UserId = 3
                        },
                        new
                        {
                            Id = 9,
                            Body = "Some random reply ",
                            MessageId = 9,
                            UserId = 3
                        });
                });

            modelBuilder.Entity("GuestBookChallenge.Models.User", b =>
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

            modelBuilder.Entity("GuestBookChallenge.Models.Message", b =>
                {
                    b.HasOne("GuestBookChallenge.Models.User", "User")
                        .WithMany("Messages")
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("GuestBookChallenge.Models.Reply", b =>
                {
                    b.HasOne("GuestBookChallenge.Models.Message", "Message")
                        .WithMany("Replies")
                        .HasForeignKey("MessageId");

                    b.HasOne("GuestBookChallenge.Models.User", "User")
                        .WithMany("Replies")
                        .HasForeignKey("UserId");

                    b.Navigation("Message");

                    b.Navigation("User");
                });

            modelBuilder.Entity("GuestBookChallenge.Models.Message", b =>
                {
                    b.Navigation("Replies");
                });

            modelBuilder.Entity("GuestBookChallenge.Models.User", b =>
                {
                    b.Navigation("Messages");

                    b.Navigation("Replies");
                });
#pragma warning restore 612, 618
        }
    }
}
