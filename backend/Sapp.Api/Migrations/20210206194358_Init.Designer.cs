﻿// <auto-generated />
using System;
using Sapp.Core.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Sapp.Api.Migrations
{
    [DbContext(typeof(ApiContext))]
    [Migration("20210206194358_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityByDefaultColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("Sapp.Api.Core.Entities.Item", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Data")
                        .HasColumnType("jsonb");

                    b.Property<Guid>("RoomId")
                        .HasColumnType("uuid");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("RoomId");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("Sapp.Api.Core.Entities.Room", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<Guid?>("SelectedItemId")
                        .HasColumnType("uuid");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<DateTimeOffset>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("Sapp.Api.Core.Entities.RoomUser", b =>
                {
                    b.Property<Guid>("RoomId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<bool>("IsLeader")
                        .HasColumnType("boolean");

                    b.HasKey("RoomId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("RoomUsers");
                });

            modelBuilder.Entity("Sapp.Api.Core.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsGuest")
                        .HasColumnType("boolean");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Username")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Sapp.Api.Core.Entities.Vote", b =>
                {
                    b.Property<Guid>("RoomId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ItemId")
                        .HasColumnType("uuid");

                    b.Property<float?>("VoteData")
                        .HasColumnType("real");

                    b.HasKey("RoomId", "UserId", "ItemId");

                    b.HasIndex("ItemId");

                    b.HasIndex("UserId");

                    b.ToTable("Votes");
                });

            modelBuilder.Entity("Sapp.Api.Core.Entities.Item", b =>
                {
                    b.HasOne("Sapp.Api.Core.Entities.Room", "Room")
                        .WithMany("Items")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Room");
                });

            modelBuilder.Entity("Sapp.Api.Core.Entities.RoomUser", b =>
                {
                    b.HasOne("Sapp.Api.Core.Entities.Room", "Room")
                        .WithMany("RoomUsers")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Sapp.Api.Core.Entities.User", "User")
                        .WithMany("RoomUsers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Room");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Sapp.Api.Core.Entities.Vote", b =>
                {
                    b.HasOne("Sapp.Api.Core.Entities.Item", "Item")
                        .WithMany()
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Sapp.Api.Core.Entities.Room", "Room")
                        .WithMany("Votes")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Sapp.Api.Core.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");

                    b.Navigation("Room");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Sapp.Api.Core.Entities.Room", b =>
                {
                    b.Navigation("Items");

                    b.Navigation("RoomUsers");

                    b.Navigation("Votes");
                });

            modelBuilder.Entity("Sapp.Api.Core.Entities.User", b =>
                {
                    b.Navigation("RoomUsers");
                });
#pragma warning restore 612, 618
        }
    }
}
