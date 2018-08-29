﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using SLB_REST.Context;
using System;

namespace SLB_REST.Migrations
{
    [DbContext(typeof(EFContext))]
    [Migration("20180829143313_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<int>("RoleId");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<int>("UserId");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<int>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("SLB_REST.Models.AlbumModel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Title");

                    b.Property<int?>("UserID");

                    b.HasKey("ID");

                    b.HasIndex("UserID");

                    b.ToTable("Albums");
                });

            modelBuilder.Entity("SLB_REST.Models.AlbumThumbModel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ArtistName");

                    b.Property<string>("Genres");

                    b.Property<string>("ImageThumbSrc");

                    b.Property<string>("Style");

                    b.Property<string>("Title");

                    b.HasKey("ID");

                    b.ToTable("AlbumsThumb");
                });

            modelBuilder.Entity("SLB_REST.Models.ArtistModel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AlbumModelID");

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.HasIndex("AlbumModelID");

                    b.ToTable("Artists");
                });

            modelBuilder.Entity("SLB_REST.Models.ExtraArtistModel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AlbumModelID");

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.HasIndex("AlbumModelID");

                    b.ToTable("ExtraArtists");
                });

            modelBuilder.Entity("SLB_REST.Models.GenreModel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AlbumModelID");

                    b.Property<string>("Genre");

                    b.HasKey("ID");

                    b.HasIndex("AlbumModelID");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("SLB_REST.Models.ImagesModel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AlbumModelID");

                    b.Property<string>("Uri");

                    b.HasKey("ID");

                    b.HasIndex("AlbumModelID");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("SLB_REST.Models.StyleModel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AlbumModelID");

                    b.Property<string>("Style");

                    b.HasKey("ID");

                    b.HasIndex("AlbumModelID");

                    b.ToTable("Styles");
                });

            modelBuilder.Entity("SLB_REST.Models.TrackModel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AlbumModelID");

                    b.Property<string>("Duration");

                    b.Property<string>("Position");

                    b.Property<string>("Title");

                    b.HasKey("ID");

                    b.HasIndex("AlbumModelID");

                    b.ToTable("Tracks");
                });

            modelBuilder.Entity("SLB_REST.Models.UserModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("SLB_REST.Models.VideoModel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AlbumModelID");

                    b.Property<string>("Description");

                    b.Property<string>("Uri");

                    b.HasKey("ID");

                    b.HasIndex("AlbumModelID");

                    b.ToTable("Videos");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<int>")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("SLB_REST.Models.UserModel")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("SLB_REST.Models.UserModel")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<int>")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SLB_REST.Models.UserModel")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("SLB_REST.Models.UserModel")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SLB_REST.Models.AlbumModel", b =>
                {
                    b.HasOne("SLB_REST.Models.UserModel", "User")
                        .WithMany("Albums")
                        .HasForeignKey("UserID");
                });

            modelBuilder.Entity("SLB_REST.Models.ArtistModel", b =>
                {
                    b.HasOne("SLB_REST.Models.AlbumModel")
                        .WithMany("Artists")
                        .HasForeignKey("AlbumModelID");
                });

            modelBuilder.Entity("SLB_REST.Models.ExtraArtistModel", b =>
                {
                    b.HasOne("SLB_REST.Models.AlbumModel")
                        .WithMany("Extraartists")
                        .HasForeignKey("AlbumModelID");
                });

            modelBuilder.Entity("SLB_REST.Models.GenreModel", b =>
                {
                    b.HasOne("SLB_REST.Models.AlbumModel")
                        .WithMany("Genres")
                        .HasForeignKey("AlbumModelID");
                });

            modelBuilder.Entity("SLB_REST.Models.ImagesModel", b =>
                {
                    b.HasOne("SLB_REST.Models.AlbumModel")
                        .WithMany("Images")
                        .HasForeignKey("AlbumModelID");
                });

            modelBuilder.Entity("SLB_REST.Models.StyleModel", b =>
                {
                    b.HasOne("SLB_REST.Models.AlbumModel")
                        .WithMany("Styles")
                        .HasForeignKey("AlbumModelID");
                });

            modelBuilder.Entity("SLB_REST.Models.TrackModel", b =>
                {
                    b.HasOne("SLB_REST.Models.AlbumModel")
                        .WithMany("Tracks")
                        .HasForeignKey("AlbumModelID");
                });

            modelBuilder.Entity("SLB_REST.Models.VideoModel", b =>
                {
                    b.HasOne("SLB_REST.Models.AlbumModel")
                        .WithMany("Videos")
                        .HasForeignKey("AlbumModelID");
                });
#pragma warning restore 612, 618
        }
    }
}
