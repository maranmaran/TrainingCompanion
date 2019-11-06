﻿// <auto-generated />
using System;
using Backend.Domain.Enum;
using Backend.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Backend.Persistance.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Backend.Domain.Entities.Chat.ChatMessage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("ContainsMedia")
                        .HasColumnType("bit");

                    b.Property<string>("DownloadUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("FileSizeInBytes")
                        .HasColumnType("int");

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("ReceiverId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("S3Filename")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("SeenAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("SenderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("SentAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getutcdate()");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SenderId");

                    b.ToTable("ChatMessages");
                });

            modelBuilder.Entity("Backend.Domain.Entities.ExerciseType.ExerciseType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Active")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<Guid>("ApplicationUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("RequiresBodyweight")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<bool>("RequiresReps")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<bool>("RequiresSets")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<bool>("RequiresTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<bool>("RequiresWeight")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.ToTable("ExerciseTypes");
                });

            modelBuilder.Entity("Backend.Domain.Entities.ExerciseType.ExerciseTypeTag", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ExerciseTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Show")
                        .HasColumnType("bit");

                    b.Property<Guid>("TagId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ExerciseTypeId");

                    b.HasIndex("TagId");

                    b.ToTable("ExerciseTypeTags");
                });

            modelBuilder.Entity("Backend.Domain.Entities.ExerciseType.Tag", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Active")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.Property<Guid>("TagGroupId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("TagGroupId");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("Backend.Domain.Entities.ExerciseType.TagGroup", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Active")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<Guid>("ApplicationUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("HexBackground")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("#fef6f9");

                    b.Property<string>("HexColor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("#616161");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.ToTable("TagGroups");
                });

            modelBuilder.Entity("Backend.Domain.Entities.Media.MediaFile", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ApplicationUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateUploaded")
                        .HasColumnType("datetime2");

                    b.Property<string>("DownloadUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Filename")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FtpFilePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("TrainingId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("TrainingId");

                    b.ToTable("MediaFiles");
                });

            modelBuilder.Entity("Backend.Domain.Entities.Notification.Notification", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Payload")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Read")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<Guid?>("ReceiverId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("RedirectUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("SenderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("SenderId1")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SenderId");

                    b.HasIndex("SenderId1");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("Backend.Domain.Entities.ProgressTracking.Max.ExerciseMax", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ExerciseTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("IpfPoints")
                        .HasColumnType("float");

                    b.Property<double>("Max")
                        .HasColumnType("float");

                    b.Property<double>("WilksScore")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("ExerciseTypeId");

                    b.ToTable("ExerciseMax");
                });

            modelBuilder.Entity("Backend.Domain.Entities.System.SystemException", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getutcdate()");

                    b.Property<string>("InnerException")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StatusCode")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("SystemExceptions");
                });

            modelBuilder.Entity("Backend.Domain.Entities.TrainingLog.Exercise", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ExerciseTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TrainingId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ExerciseTypeId");

                    b.HasIndex("TrainingId");

                    b.ToTable("Exercises");
                });

            modelBuilder.Entity("Backend.Domain.Entities.TrainingLog.Set", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AverageVelocity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ExerciseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Intensity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("ProjectedMax")
                        .HasColumnType("float");

                    b.Property<double>("Reps")
                        .HasColumnType("float");

                    b.Property<double>("Rpe")
                        .HasColumnType("float");

                    b.Property<TimeSpan>("Time")
                        .HasColumnType("time");

                    b.Property<double>("Volume")
                        .HasColumnType("float");

                    b.Property<double>("Weight")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("ExerciseId");

                    b.ToTable("Sets");
                });

            modelBuilder.Entity("Backend.Domain.Entities.TrainingLog.Training", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ApplicationUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateTrained")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getutcdate()");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("NoteRead")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.ToTable("Trainings");
                });

            modelBuilder.Entity("Backend.Domain.Entities.User.ApplicationUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AccountType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Active")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<string>("Avatar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedOn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getutcdate()");

                    b.Property<string>("CustomerId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("Male");

                    b.Property<DateTime>("LastModified")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getutcdate()");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TrialDuration")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(15);

                    b.Property<Guid?>("UserSettingsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("UserSettingsId");

                    b.ToTable("Users");

                    b.HasDiscriminator<string>("AccountType").HasValue("User");
                });

            modelBuilder.Entity("Backend.Domain.Entities.User.UserSettings", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("RpeSystem")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("Rpe");

                    b.Property<string>("Theme")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("Light");

                    b.Property<string>("UnitSystem")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("Metric");

                    b.Property<bool>("UseRpeSystem")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
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

                    b.Property<Guid?>("CoachId")
                        .HasColumnType("uniqueidentifier");

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
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Backend.Domain.Entities.ExerciseType.ExerciseType", b =>
                {
                    b.HasOne("Backend.Domain.Entities.User.ApplicationUser", "ApplicationUser")
                        .WithMany("ExerciseTypes")
                        .HasForeignKey("ApplicationUserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Backend.Domain.Entities.ExerciseType.ExerciseTypeTag", b =>
                {
                    b.HasOne("Backend.Domain.Entities.ExerciseType.ExerciseType", "ExerciseType")
                        .WithMany("Properties")
                        .HasForeignKey("ExerciseTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Backend.Domain.Entities.ExerciseType.Tag", "Tag")
                        .WithMany()
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Backend.Domain.Entities.ExerciseType.Tag", b =>
                {
                    b.HasOne("Backend.Domain.Entities.ExerciseType.TagGroup", "TagGroup")
                        .WithMany("Tags")
                        .HasForeignKey("TagGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Backend.Domain.Entities.ExerciseType.TagGroup", b =>
                {
                    b.HasOne("Backend.Domain.Entities.User.ApplicationUser", "ApplicationUser")
                        .WithMany("TagGroups")
                        .HasForeignKey("ApplicationUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Backend.Domain.Entities.Media.MediaFile", b =>
                {
                    b.HasOne("Backend.Domain.Entities.User.ApplicationUser", "ApplicationUser")
                        .WithMany("MediaFiles")
                        .HasForeignKey("ApplicationUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Backend.Domain.Entities.TrainingLog.Training", "Training")
                        .WithMany("Media")
                        .HasForeignKey("TrainingId");
                });

            modelBuilder.Entity("Backend.Domain.Entities.Notification.Notification", b =>
                {
                    b.HasOne("Backend.Domain.Entities.User.ApplicationUser", "Receiver")
                        .WithMany("Notifications")
                        .HasForeignKey("SenderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Backend.Domain.Entities.User.ApplicationUser", "Sender")
                        .WithMany()
                        .HasForeignKey("SenderId1");
                });

            modelBuilder.Entity("Backend.Domain.Entities.ProgressTracking.Max.ExerciseMax", b =>
                {
                    b.HasOne("Backend.Domain.Entities.ExerciseType.ExerciseType", "ExerciseType")
                        .WithMany("ExerciseMaxes")
                        .HasForeignKey("ExerciseTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Backend.Domain.Entities.TrainingLog.Exercise", b =>
                {
                    b.HasOne("Backend.Domain.Entities.ExerciseType.ExerciseType", "ExerciseType")
                        .WithMany()
                        .HasForeignKey("ExerciseTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Backend.Domain.Entities.TrainingLog.Training", "Training")
                        .WithMany("Exercises")
                        .HasForeignKey("TrainingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Backend.Domain.Entities.TrainingLog.Set", b =>
                {
                    b.HasOne("Backend.Domain.Entities.TrainingLog.Exercise", "Exercise")
                        .WithMany("Sets")
                        .HasForeignKey("ExerciseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Backend.Domain.Entities.TrainingLog.Training", b =>
                {
                    b.HasOne("Backend.Domain.Entities.User.ApplicationUser", "ApplicationUser")
                        .WithMany("Trainings")
                        .HasForeignKey("ApplicationUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
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
