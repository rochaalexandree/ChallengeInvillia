﻿// <auto-generated />
using System;
using ChallengeInvillia.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ChallengeInvillia.Repository.Migrations
{
    [DbContext(typeof(ChallengeInvilliaContext))]
    partial class ChallengeInvilliaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10");

            modelBuilder.Entity("ChallengeInvillia.Domain.Friend", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Age")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Friends");
                });

            modelBuilder.Entity("ChallengeInvillia.Domain.Game", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int?>("FriendId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsOnLoan")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Type")
                        .HasColumnType("TEXT");

                    b.HasKey("Id", "Name");

                    b.HasIndex("FriendId");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("ChallengeInvillia.Domain.GameRented", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("FriendId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("GameId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("GameName")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("RentalDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("FriendId");

                    b.HasIndex("GameId", "GameName");

                    b.ToTable("GameRenteds");
                });

            modelBuilder.Entity("ChallengeInvillia.Domain.Game", b =>
                {
                    b.HasOne("ChallengeInvillia.Domain.Friend", null)
                        .WithMany("Games")
                        .HasForeignKey("FriendId");
                });

            modelBuilder.Entity("ChallengeInvillia.Domain.GameRented", b =>
                {
                    b.HasOne("ChallengeInvillia.Domain.Friend", "Friend")
                        .WithMany()
                        .HasForeignKey("FriendId");

                    b.HasOne("ChallengeInvillia.Domain.Game", "Game")
                        .WithMany()
                        .HasForeignKey("GameId", "GameName");
                });
#pragma warning restore 612, 618
        }
    }
}
