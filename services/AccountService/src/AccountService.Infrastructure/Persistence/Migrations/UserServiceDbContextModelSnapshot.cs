﻿// <auto-generated />
using System;
using AccountService.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AccountService.Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(AccountDbContext))]
    partial class UserServiceDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("AccountService.Infrastructure.Persistence.Entities.OrganizationEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnOrder(1);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnOrder(4);

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnOrder(3);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnOrder(2);

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnOrder(5);

                    b.HasKey("Id");

                    b.ToTable("Organizations", (string)null);
                });

            modelBuilder.Entity("AccountService.Infrastructure.Persistence.Entities.OrganizationMemberInvitation", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text")
                        .HasColumnOrder(2);

                    b.Property<Guid>("OrganizationId")
                        .HasColumnType("uuid")
                        .HasColumnOrder(4);

                    b.Property<int>("Role")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("AcceptedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnOrder(5);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnOrder(7);

                    b.Property<DateTime>("ExpiresAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnOrder(9);

                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasColumnOrder(1);

                    b.Property<string>("InvitedByUserId")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnOrder(3);

                    b.Property<DateTime?>("RejectedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnOrder(6);

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnOrder(8);

                    b.HasKey("UserId", "OrganizationId", "Role");

                    b.HasIndex("OrganizationId");

                    b.HasIndex("UserId", "OrganizationId", "Role")
                        .IsUnique();

                    b.ToTable("OrganizationMemberInvitations", (string)null);
                });

            modelBuilder.Entity("AccountService.Infrastructure.Persistence.Entities.UserProfileEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnOrder(1);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnOrder(8);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnOrder(4);

                    b.Property<string>("FirstName")
                        .HasColumnType("text")
                        .HasColumnOrder(6);

                    b.Property<string>("LastName")
                        .HasColumnType("text")
                        .HasColumnOrder(7);

                    b.Property<int>("Status")
                        .HasColumnType("integer")
                        .HasColumnOrder(5);

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnOrder(9);

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnOrder(2);

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnOrder(3);

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("UserProfiles", (string)null);
                });

            modelBuilder.Entity("AccountService.Infrastructure.Persistence.Entities.OrganizationMemberInvitation", b =>
                {
                    b.HasOne("AccountService.Infrastructure.Persistence.Entities.OrganizationEntity", null)
                        .WithMany()
                        .HasForeignKey("OrganizationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AccountService.Infrastructure.Persistence.Entities.UserProfileEntity", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .HasPrincipalKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
