﻿// <auto-generated />
using System;
using Backend.Domain.Enum;
using Backend.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Backend.Persistance.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20190820193322_updates-on-properties")]
    partial class updatesonproperties
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

            modelBuilder.Entity("Backend.Domain.Entities.ExerciseType.ExerciseProperty", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(true);

                    b.Property<Guid>("ExercisePropertyTypeId");

                    b.Property<int>("Order");

                    b.Property<string>("Value");

                    b.HasKey("Id");

                    b.HasIndex("ExercisePropertyTypeId");

                    b.ToTable("ExerciseProperties");
                });

            modelBuilder.Entity("Backend.Domain.Entities.ExerciseType.ExercisePropertyType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(true);

                    b.Property<Guid?>("ApplicationUserId");

                    b.Property<string>("HexColor")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue("#ffffff");

                    b.Property<int>("Order");

                    b.Property<string>("Type");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.ToTable("ExercisePropertyTypes");
                });

            modelBuilder.Entity("Backend.Domain.Entities.ExerciseType.ExerciseType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(true);

                    b.Property<Guid?>("AdminId");

                    b.Property<Guid>("AthleteId");

                    b.Property<Guid?>("CoachId");

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

                    b.Property<Guid?>("SoloAthleteId");

                    b.HasKey("Id");

                    b.HasIndex("AdminId");

                    b.HasIndex("AthleteId");

                    b.HasIndex("CoachId");

                    b.HasIndex("SoloAthleteId");

                    b.ToTable("ExerciseTypes");
                });

            modelBuilder.Entity("Backend.Domain.Entities.ExerciseType.ExerciseTypeExerciseProperty", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("ExercisePropertyId");

                    b.Property<Guid>("ExerciseTypeId");

                    b.Property<bool>("Show")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(true);

                    b.HasKey("Id");

                    b.HasIndex("ExercisePropertyId");

                    b.HasIndex("ExerciseTypeId");

                    b.ToTable("ExerciseTypeExerciseProperty");
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

                    b.Property<int>("Sets");

                    b.Property<Guid?>("TrainingId");

                    b.HasKey("Id");

                    b.HasIndex("ExerciseTypeId");

                    b.HasIndex("TrainingId");

                    b.ToTable("Exercise");
                });

            modelBuilder.Entity("Backend.Domain.Entities.TrainingLog.Lift", b =>
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

                    b.ToTable("Lift");
                });

            modelBuilder.Entity("Backend.Domain.Entities.TrainingLog.Training", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateTrained");

                    b.Property<string>("Note");

                    b.Property<bool>("NoteRead");

                    b.Property<Guid>("ApplicationUserId");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.ToTable("Training");
                });

            modelBuilder.Entity("Backend.Domain.Entities.ApplicationUser.ApplicationUser", b =>
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

                    b.HasDiscriminator<string>("AccountType").HasValue("ApplicationUser");
                });

            modelBuilder.Entity("Backend.Domain.Entities.ApplicationUser.UserSettings", b =>
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

            modelBuilder.Entity("Backend.Domain.Entities.ApplicationUser.Admin", b =>
                {
                    b.HasBaseType("Backend.Domain.Entities.ApplicationUser.ApplicationUser");

                    b.HasDiscriminator().HasValue("Admin");
                });

            modelBuilder.Entity("Backend.Domain.Entities.ApplicationUser.Athlete", b =>
                {
                    b.HasBaseType("Backend.Domain.Entities.ApplicationUser.ApplicationUser");

                    b.Property<Guid?>("CoachId");

                    b.HasIndex("CoachId");

                    b.HasDiscriminator().HasValue("Athlete");
                });

            modelBuilder.Entity("Backend.Domain.Entities.ApplicationUser.Coach", b =>
                {
                    b.HasBaseType("Backend.Domain.Entities.ApplicationUser.ApplicationUser");

                    b.HasDiscriminator().HasValue("Coach");
                });

            modelBuilder.Entity("Backend.Domain.Entities.ApplicationUser.SoloAthlete", b =>
                {
                    b.HasBaseType("Backend.Domain.Entities.ApplicationUser.ApplicationUser");

                    b.HasDiscriminator().HasValue("SoloAthlete");
                });

            modelBuilder.Entity("Backend.Domain.Entities.Chat.ChatMessage", b =>
                {
                    b.HasOne("Backend.Domain.Entities.ApplicationUser.ApplicationUser", "Sender")
                        .WithMany("ChatMessages")
                        .HasForeignKey("SenderId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Backend.Domain.Entities.ExerciseType.ExerciseProperty", b =>
                {
                    b.HasOne("Backend.Domain.Entities.ExerciseType.ExercisePropertyType", "ExercisePropertyType")
                        .WithMany("Properties")
                        .HasForeignKey("ExercisePropertyTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Backend.Domain.Entities.ExerciseType.ExercisePropertyType", b =>
                {
                    b.HasOne("Backend.Domain.Entities.ApplicationUser.ApplicationUser")
                        .WithMany("ExercisePropertyTypes")
                        .HasForeignKey("ApplicationUserId");
                });

            modelBuilder.Entity("Backend.Domain.Entities.ExerciseType.ExerciseType", b =>
                {
                    b.HasOne("Backend.Domain.Entities.ApplicationUser.Admin")
                        .WithMany("ExerciseTypes")
                        .HasForeignKey("AdminId");

                    b.HasOne("Backend.Domain.Entities.ApplicationUser.Athlete", "Athlete")
                        .WithMany("ExerciseTypes")
                        .HasForeignKey("AthleteId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Backend.Domain.Entities.ApplicationUser.Coach")
                        .WithMany("ExerciseTypes")
                        .HasForeignKey("CoachId");

                    b.HasOne("Backend.Domain.Entities.ApplicationUser.SoloAthlete")
                        .WithMany("ExerciseTypes")
                        .HasForeignKey("SoloAthleteId");
                });

            modelBuilder.Entity("Backend.Domain.Entities.ExerciseType.ExerciseTypeExerciseProperty", b =>
                {
                    b.HasOne("Backend.Domain.Entities.ExerciseType.ExerciseProperty", "ExerciseProperty")
                        .WithMany()
                        .HasForeignKey("ExercisePropertyId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Backend.Domain.Entities.ExerciseType.ExerciseType", "ExerciseType")
                        .WithMany("Properties")
                        .HasForeignKey("ExerciseTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Backend.Domain.Entities.Media.MediaFile", b =>
                {
                    b.HasOne("Backend.Domain.Entities.ApplicationUser.ApplicationUser", "ApplicationUser")
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

            modelBuilder.Entity("Backend.Domain.Entities.TrainingLog.Lift", b =>
                {
                    b.HasOne("Backend.Domain.Entities.TrainingLog.Exercise")
                        .WithMany("Lifts")
                        .HasForeignKey("ExerciseId");
                });

            modelBuilder.Entity("Backend.Domain.Entities.TrainingLog.Training", b =>
                {
                    b.HasOne("Backend.Domain.Entities.ApplicationUser.ApplicationUser", "ApplicationUser")
                        .WithMany("Trainings")
                        .HasForeignKey("ApplicationUserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Backend.Domain.Entities.ApplicationUser.ApplicationUser", b =>
                {
                    b.HasOne("Backend.Domain.Entities.ApplicationUser.UserSettings", "UserSettings")
                        .WithMany()
                        .HasForeignKey("UserSettingsId");
                });

            modelBuilder.Entity("Backend.Domain.Entities.ApplicationUser.Athlete", b =>
                {
                    b.HasOne("Backend.Domain.Entities.ApplicationUser.Coach", "Coach")
                        .WithMany("Athletes")
                        .HasForeignKey("CoachId");
                });
#pragma warning restore 612, 618
        }
    }
}
