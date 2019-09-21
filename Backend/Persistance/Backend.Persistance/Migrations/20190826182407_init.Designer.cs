﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Backend.Persistance.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20190826182407_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Backend.Domain.Entities.Chat.ChatMessage", b =>
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

            modelBuilder.Entity("Backend.Domain.Entities.ExerciseType.Tag", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(true);

                    b.Property<Guid>("TagGroupId");

                    b.Property<int>("Order");

                    b.Property<string>("Value");

                    b.HasKey("Id");

                    b.HasIndex("TagGroupId");

                    b.ToTable("ExerciseProperties");
                });

            modelBuilder.Entity("Backend.Domain.Entities.ExerciseType.TagGroup", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(true);

                    b.Property<Guid>("ApplicationUserId");

                    b.Property<string>("HexBackground")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue("#fef6f9");

                    b.Property<string>("HexColor")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue("#616161");

                    b.Property<int>("Order");

                    b.Property<string>("Type");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.ToTable("TagGroups");
                });

            modelBuilder.Entity("Backend.Domain.Entities.ExerciseType.ExerciseType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(true);

                    b.Property<Guid>("ApplicationUserId");

                    b.Property<string>("Name");

                    b.Property<bool?>("RequiresBodyweight")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(false);

                    b.Property<bool?>("RequiresReps")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(true);

                    b.Property<bool?>("RequiresSets")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(true);

                    b.Property<bool?>("RequiresTime")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(false);

                    b.Property<bool?>("RequiresWeight")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(true);

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.ToTable("ExerciseTypes");
                });

            modelBuilder.Entity("Backend.Domain.Entities.ExerciseType.ExerciseTypeTag", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("TagId");

                    b.Property<Guid>("ExerciseTypeId");

                    b.Property<bool>("Show")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(true);

                    b.HasKey("Id");

                    b.HasIndex("TagId");

                    b.HasIndex("ExerciseTypeId");

                    b.ToTable("ExerciseTypeExerciseProperties");
                });

            modelBuilder.Entity("Backend.Domain.Entities.Media.MediaFile", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("ApplicationUserId");

                    b.Property<DateTime>("DateModified");

                    b.Property<DateTime>("DateUploaded");

                    b.Property<string>("DownloadUrl");

                    b.Property<string>("Filename");

                    b.Property<string>("FtpFilePath");

                    b.Property<Guid?>("TrainingId");

                    b.Property<int>("Type");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("TrainingId");

                    b.ToTable("MediaFiles");
                });

            modelBuilder.Entity("Backend.Domain.Entities.ProgressTracking.Max.ExerciseMax", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("ExerciseTypeId");

                    b.Property<double>("IpfPoints");

                    b.Property<double>("Max");

                    b.Property<double>("WilksScore");

                    b.HasKey("Id");

                    b.HasIndex("ExerciseTypeId");

                    b.ToTable("ExerciseMax");
                });

            modelBuilder.Entity("Backend.Domain.Entities.System.SystemException", b =>
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

            modelBuilder.Entity("Backend.Domain.Entities.TrainingLog.Exercise", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("ExerciseTypeId");

                    b.Property<Guid?>("TrainingId");

                    b.HasKey("Id");

                    b.HasIndex("ExerciseTypeId");

                    b.HasIndex("TrainingId");

                    b.ToTable("Exercises");
                });

            modelBuilder.Entity("Backend.Domain.Entities.TrainingLog.Set", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AverageVelocity");

                    b.Property<Guid?>("ExerciseId");

                    b.Property<string>("Intensity");

                    b.Property<double>("ProjectedMax");

                    b.Property<double>("Reps");

                    b.Property<double>("Rpe");

                    b.Property<TimeSpan>("Time");

                    b.Property<double>("Volume");

                    b.Property<double>("Weight");

                    b.HasKey("Id");

                    b.HasIndex("ExerciseId");

                    b.ToTable("Sets");
                });

            modelBuilder.Entity("Backend.Domain.Entities.TrainingLog.Training", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("ApplicationUserId");

                    b.Property<DateTime>("DateTrained")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getutcdate()");

                    b.Property<string>("Note");

                    b.Property<bool>("NoteRead")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(false);

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.ToTable("Trainings");
                });

            modelBuilder.Entity("Backend.Domain.Entities.User.ApplicationUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AccountType")
                        .IsRequired();

                    b.Property<bool>("Active")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(true);

                    b.Property<string>("Avatar");

                    b.Property<DateTime>("CreatedOn")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getutcdate()");

                    b.Property<string>("CustomerId");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue("Male");

                    b.Property<DateTime>("LastModified")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasDefaultValueSql("getutcdate()");

                    b.Property<string>("LastName");

                    b.Property<string>("PasswordHash");

                    b.Property<int>("TrialDuration")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(15);

                    b.Property<Guid?>("UserSettingsId");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.HasIndex("UserSettingsId");

                    b.ToTable("Users");

                    b.HasDiscriminator<string>("AccountType").HasValue("User");
                });

            modelBuilder.Entity("Backend.Domain.Entities.User.UserSettings", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("RpeSystem")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue("Rpe");

                    b.Property<string>("Theme")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue("Light");

                    b.Property<string>("UnitSystem")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue("Metric");

                    b.Property<bool>("UseRpeSystem")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(true);

                    b.HasKey("Id");

                    b.ToTable("UserSettings");
                });

            modelBuilder.Entity("Backend.Domain.Entities.User.Admin", b =>
                {
                    b.HasBaseType("Backend.Domain.Entities.User.ApplicationUser");

                    b.HasDiscriminator().HasValue("Admin");
                });

            modelBuilder.Entity("Backend.Domain.Entities.User.Athlete", b =>
                {
                    b.HasBaseType("Backend.Domain.Entities.User.ApplicationUser");

                    b.Property<Guid?>("CoachId");

                    b.HasIndex("CoachId");

                    b.HasDiscriminator().HasValue("Athlete");
                });

            modelBuilder.Entity("Backend.Domain.Entities.User.Coach", b =>
                {
                    b.HasBaseType("Backend.Domain.Entities.User.ApplicationUser");

                    b.HasDiscriminator().HasValue("Coach");
                });

            modelBuilder.Entity("Backend.Domain.Entities.User.SoloAthlete", b =>
                {
                    b.HasBaseType("Backend.Domain.Entities.User.ApplicationUser");

                    b.HasDiscriminator().HasValue("SoloAthlete");
                });

            modelBuilder.Entity("Backend.Domain.Entities.Chat.ChatMessage", b =>
                {
                    b.HasOne("Backend.Domain.Entities.User.ApplicationUser", "Sender")
                        .WithMany("ChatMessages")
                        .HasForeignKey("SenderId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Backend.Domain.Entities.ExerciseType.Tag", b =>
                {
                    b.HasOne("Backend.Domain.Entities.ExerciseType.TagGroup", "TagGroup")
                        .WithMany("Properties")
                        .HasForeignKey("TagGroupId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Backend.Domain.Entities.ExerciseType.TagGroup", b =>
                {
                    b.HasOne("Backend.Domain.Entities.User.ApplicationUser", "ApplicationUser")
                        .WithMany("TagGroups")
                        .HasForeignKey("ApplicationUserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Backend.Domain.Entities.ExerciseType.ExerciseType", b =>
                {
                    b.HasOne("Backend.Domain.Entities.User.ApplicationUser", "ApplicationUser")
                        .WithMany("ExerciseTypes")
                        .HasForeignKey("ApplicationUserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Backend.Domain.Entities.ExerciseType.ExerciseTypeTag", b =>
                {
                    b.HasOne("Backend.Domain.Entities.ExerciseType.Tag", "Tag")
                        .WithMany()
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Backend.Domain.Entities.ExerciseType.ExerciseType", "ExerciseType")
                        .WithMany("Properties")
                        .HasForeignKey("ExerciseTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Backend.Domain.Entities.Media.MediaFile", b =>
                {
                    b.HasOne("Backend.Domain.Entities.User.ApplicationUser", "ApplicationUser")
                        .WithMany("MediaFiles")
                        .HasForeignKey("ApplicationUserId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Backend.Domain.Entities.TrainingLog.Training")
                        .WithMany("Media")
                        .HasForeignKey("TrainingId");
                });

            modelBuilder.Entity("Backend.Domain.Entities.ProgressTracking.Max.ExerciseMax", b =>
                {
                    b.HasOne("Backend.Domain.Entities.ExerciseType.ExerciseType", "ExerciseType")
                        .WithMany("ExerciseMaxes")
                        .HasForeignKey("ExerciseTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Backend.Domain.Entities.TrainingLog.Exercise", b =>
                {
                    b.HasOne("Backend.Domain.Entities.ExerciseType.ExerciseType", "ExerciseType")
                        .WithMany()
                        .HasForeignKey("ExerciseTypeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Backend.Domain.Entities.TrainingLog.Training")
                        .WithMany("Exercises")
                        .HasForeignKey("TrainingId");
                });

            modelBuilder.Entity("Backend.Domain.Entities.TrainingLog.Set", b =>
                {
                    b.HasOne("Backend.Domain.Entities.TrainingLog.Exercise")
                        .WithMany("Sets")
                        .HasForeignKey("ExerciseId");
                });

            modelBuilder.Entity("Backend.Domain.Entities.TrainingLog.Training", b =>
                {
                    b.HasOne("Backend.Domain.Entities.User.ApplicationUser", "ApplicationUser")
                        .WithMany("Trainings")
                        .HasForeignKey("ApplicationUserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Backend.Domain.Entities.User.ApplicationUser", b =>
                {
                    b.HasOne("Backend.Domain.Entities.User.UserSettings", "UserSettings")
                        .WithMany()
                        .HasForeignKey("UserSettingsId");
                });

            modelBuilder.Entity("Backend.Domain.Entities.User.Athlete", b =>
                {
                    b.HasOne("Backend.Domain.Entities.User.Coach", "Coach")
                        .WithMany("Athletes")
                        .HasForeignKey("CoachId");
                });
#pragma warning restore 612, 618
        }
    }
}
