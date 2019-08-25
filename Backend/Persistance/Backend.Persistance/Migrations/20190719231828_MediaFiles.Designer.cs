﻿// <auto-generated />
using System;
using Backend.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Backend.Persistance.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20190719231828_MediaFiles")]
    partial class MediaFiles
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Backend.Domain.Entities.ApplicationUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AccountStatus")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue("Active");

                    b.Property<string>("AccountType")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue("ApplicationUser");

                    b.Property<string>("Avatar");

                    b.Property<DateTime>("CreatedOn")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getutcdate()");

                    b.Property<string>("CustomerId");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<DateTime>("LastModified")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getutcdate()");

                    b.Property<string>("LastName");

                    b.Property<Guid?>("ParentId");

                    b.Property<string>("PasswordHash");

                    b.Property<int>("TrialDuration")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(15);

                    b.Property<Guid?>("UserSettingsId");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.HasIndex("UserSettingsId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Backend.Domain.Entities.ChatMessage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("ContainsMedia");

                    b.Property<string>("DownloadUrl");

                    b.Property<int?>("FileSizeInBytes");

                    b.Property<string>("Message");

                    b.Property<Guid?>("ReceiverId");

                    b.Property<string>("S3Filename");

                    b.Property<DateTime?>("SeenAt");

                    b.Property<Guid>("SenderId");

                    b.Property<DateTime>("SentAt")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getutcdate()");

                    b.Property<int>("Type");

                    b.HasKey("Id");

                    b.HasIndex("SenderId");

                    b.ToTable("ChatMessages");
                });

            modelBuilder.Entity("Backend.Domain.Entities.MediaFile", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("ApplicationUserId");

                    b.Property<DateTime>("DateModified");

                    b.Property<DateTime>("DateUploaded");

                    b.Property<string>("DownloadUrl");

                    b.Property<string>("Filename");

                    b.Property<string>("FtpFilePath");

                    b.Property<int>("Type");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.ToTable("MediaFiles");
                });

            modelBuilder.Entity("Backend.Domain.Entities.SystemException", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getutcdate()");

                    b.Property<string>("InnerException");

                    b.Property<string>("Message");

                    b.Property<int>("StatusCode");

                    b.HasKey("Id");

                    b.ToTable("SystemExceptions");
                });

            modelBuilder.Entity("Backend.Domain.Entities.UserSettings", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Theme")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue("Light");

                    b.HasKey("Id");

                    b.ToTable("UserSettings");
                });

            modelBuilder.Entity("Backend.Domain.Entities.ApplicationUser", b =>
                {
                    b.HasOne("Backend.Domain.Entities.ApplicationUser", "Parent")
                        .WithMany("Athletes")
                        .HasForeignKey("ParentId");

                    b.HasOne("Backend.Domain.Entities.UserSettings", "UserSettings")
                        .WithMany()
                        .HasForeignKey("UserSettingsId");
                });

            modelBuilder.Entity("Backend.Domain.Entities.ChatMessage", b =>
                {
                    b.HasOne("Backend.Domain.Entities.ApplicationUser", "Sender")
                        .WithMany("ChatMessages")
                        .HasForeignKey("SenderId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Backend.Domain.Entities.MediaFile", b =>
                {
                    b.HasOne("Backend.Domain.Entities.ApplicationUser")
                        .WithMany("MediaFiles")
                        .HasForeignKey("ApplicationUserId");
                });
#pragma warning restore 612, 618
        }
    }
}
