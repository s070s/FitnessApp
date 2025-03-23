using System;
using System.Collections.Generic;
using FitnessApp.API.Models;
using Microsoft.EntityFrameworkCore;

namespace FitnessApp.API.Data;

public partial class FitnessContext : DbContext
{
    public FitnessContext()
    {
    }

    public FitnessContext(DbContextOptions<FitnessContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Trainer> Trainers { get; set; }

    public virtual DbSet<TrainerCustomerRelationship> TrainerCustomerRelationships { get; set; }

    public virtual DbSet<TrainingSession> TrainingSessions { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite("Data Source=../db/FitnessDB.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.ToTable("Customer");

            entity.HasIndex(e => e.BillingAddressFull, "IX_Customer_BillingAddress_Full").IsUnique();

            entity.HasIndex(e => e.CustomerId, "IX_Customer_CustomerId").IsUnique();

            entity.Property(e => e.CustomerId).ValueGeneratedNever();
            entity.Property(e => e.BillingAddressFloor).HasColumnName("BillingAddress_Floor");
            entity.Property(e => e.BillingAddressFull).HasColumnName("BillingAddress_Full");
            entity.Property(e => e.BillingAddressNo).HasColumnName("BillingAddress_No");
            entity.Property(e => e.BillingAddressStreet).HasColumnName("BillingAddress_Street");
            entity.Property(e => e.SubDateEndDay).HasColumnName("SubDateEnd_Day");
            entity.Property(e => e.SubDateEndMonth).HasColumnName("SubDateEnd_Month");
            entity.Property(e => e.SubDateEndYear).HasColumnName("SubDateEnd_Year");
            entity.Property(e => e.SubDateStartDay).HasColumnName("SubDateStart_Day");
            entity.Property(e => e.SubDateStartMonth).HasColumnName("SubDateStart_Month");
            entity.Property(e => e.SubDateStartYear).HasColumnName("SubDateStart_Year");

            entity.HasOne(d => d.CustomerNavigation).WithOne(p => p.Customer)
                .HasForeignKey<Customer>(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Trainer>(entity =>
        {
            entity.ToTable("Trainer");

            entity.HasIndex(e => e.TrainerId, "IX_Trainer_TrainerId").IsUnique();

            entity.Property(e => e.TrainerId).ValueGeneratedNever();
            entity.Property(e => e.EducationTitle).HasColumnName("Education_Title");

            entity.HasOne(d => d.TrainerNavigation).WithOne(p => p.Trainer)
                .HasForeignKey<Trainer>(d => d.TrainerId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<TrainerCustomerRelationship>(entity =>
        {
            entity.HasKey(e => e.RelationshipId);

            entity.ToTable("Trainer_Customer_Relationship");

            entity.HasIndex(e => e.RelationshipId, "IX_Trainer_Customer_Relationship_RelationshipId").IsUnique();

            entity.Property(e => e.RelationshipId).ValueGeneratedNever();
            entity.Property(e => e.RelationshipEndDateDay).HasColumnName("RelationshipEndDate_Day");
            entity.Property(e => e.RelationshipEndDateMonth).HasColumnName("RelationshipEndDate_Month");
            entity.Property(e => e.RelationshipEndDateYear).HasColumnName("RelationshipEndDate_Year");
            entity.Property(e => e.RelationshipStartDateDay).HasColumnName("RelationshipStartDate_Day");
            entity.Property(e => e.RelationshipStartDateMonth).HasColumnName("RelationshipStartDate_Month");
            entity.Property(e => e.RelationshipStartDateYear).HasColumnName("RelationshipStartDate_Year");

            entity.HasOne(d => d.Customer).WithMany(p => p.TrainerCustomerRelationships)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Trainer).WithMany(p => p.TrainerCustomerRelationships)
                .HasForeignKey(d => d.TrainerId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<TrainingSession>(entity =>
        {
            entity.ToTable("Training_Session");

            entity.HasIndex(e => e.TrainerCustomerRelationshipId, "IX_Training_Session_TrainerCustomerRelationshipId").IsUnique();

            entity.HasIndex(e => e.TrainingSessionId, "IX_Training_Session_Training_SessionId").IsUnique();

            entity.Property(e => e.TrainingSessionId).HasColumnName("Training_SessionId");
            entity.Property(e => e.SessionDateDay).HasColumnName("SessionDate_Day");
            entity.Property(e => e.SessionDateMonth).HasColumnName("SessionDate_Month");
            entity.Property(e => e.SessionDateYear).HasColumnName("SessionDate_Year");
            entity.Property(e => e.SessionDurationMinutes).HasColumnName("Session_Duration_Minutes");
            entity.Property(e => e.SessionFocus).HasColumnName("Session_Focus");

            entity.HasOne(d => d.TrainerCustomerRelationship).WithOne(p => p.TrainingSession)
                .HasForeignKey<TrainingSession>(d => d.TrainerCustomerRelationshipId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");

            entity.HasIndex(e => e.Id, "IX_User_Id").IsUnique();

            entity.HasIndex(e => e.LoginEmaill, "IX_User_Login_Emaill").IsUnique();

            entity.HasIndex(e => e.LoginUserName, "IX_User_Login_UserName").IsUnique();

            entity.Property(e => e.BirthDateDay).HasColumnName("BirthDate_Day");
            entity.Property(e => e.BirthDateMonth).HasColumnName("BirthDate_Month");
            entity.Property(e => e.BirthDateYear).HasColumnName("BirthDate_Year");
            entity.Property(e => e.Bmr).HasColumnName("BMR");
            entity.Property(e => e.BodyHeight).HasColumnName("Body_Height");
            entity.Property(e => e.BodyWeight).HasColumnName("Body_Weight");
            entity.Property(e => e.CommunicationPhone).HasColumnName("Communication_Phone");
            entity.Property(e => e.CommunicationPhoneAreaCode).HasColumnName("Communication_Phone_AreaCode");
            entity.Property(e => e.DietaryPreferences).HasColumnName("Dietary_Preferences");
            entity.Property(e => e.FirstName).HasColumnName("First_Name");
            entity.Property(e => e.JoinDateDay).HasColumnName("JoinDate_Day");
            entity.Property(e => e.JoinDateMonth).HasColumnName("JoinDate_Month");
            entity.Property(e => e.JoinDateYear).HasColumnName("JoinDate_Year");
            entity.Property(e => e.LastLoginDateDay).HasColumnName("LastLoginDate_Day");
            entity.Property(e => e.LastLoginDateMonth).HasColumnName("LastLoginDate_Month");
            entity.Property(e => e.LastLoginDateYear).HasColumnName("LastLoginDate_Year");
            entity.Property(e => e.LastName).HasColumnName("Last_Name");
            entity.Property(e => e.LoginEmaill).HasColumnName("Login_Emaill");
            entity.Property(e => e.LoginPasswordHash).HasColumnName("Login_Password_Hash");
            entity.Property(e => e.LoginUserName).HasColumnName("Login_UserName");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
