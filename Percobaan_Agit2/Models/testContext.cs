﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Percobaan_Agit2.Models
{
    public partial class testContext : DbContext
    {
        public testContext()
        {
        }

        public testContext(DbContextOptions<testContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cache> Caches { get; set; } = null!;
        public virtual DbSet<CacheLock> CacheLocks { get; set; } = null!;
        public virtual DbSet<FailedJob> FailedJobs { get; set; } = null!;
        public virtual DbSet<Job> Jobs { get; set; } = null!;
        public virtual DbSet<JobBatch> JobBatches { get; set; } = null!;
        public virtual DbSet<Migration> Migrations { get; set; } = null!;
        public virtual DbSet<PasswordResetToken> PasswordResetTokens { get; set; } = null!;
        public virtual DbSet<Sale> Sales { get; set; } = null!;
        public virtual DbSet<Salesorder> Salesorders { get; set; } = null!;
        public virtual DbSet<Session> Sessions { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=34.101.160.134;Database=test;Username=campuss;Password=my_password;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cache>(entity =>
            {
                entity.HasKey(e => e.Key)
                    .HasName("cache_pkey");

                entity.ToTable("cache");

                entity.Property(e => e.Key)
                    .HasMaxLength(255)
                    .HasColumnName("key");

                entity.Property(e => e.Expiration).HasColumnName("expiration");

                entity.Property(e => e.Value).HasColumnName("value");
            });

            modelBuilder.Entity<CacheLock>(entity =>
            {
                entity.HasKey(e => e.Key)
                    .HasName("cache_locks_pkey");

                entity.ToTable("cache_locks");

                entity.Property(e => e.Key)
                    .HasMaxLength(255)
                    .HasColumnName("key");

                entity.Property(e => e.Expiration).HasColumnName("expiration");

                entity.Property(e => e.Owner)
                    .HasMaxLength(255)
                    .HasColumnName("owner");
            });

            modelBuilder.Entity<FailedJob>(entity =>
            {
                entity.ToTable("failed_jobs");

                entity.HasIndex(e => e.Uuid, "failed_jobs_uuid_unique")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Connection).HasColumnName("connection");

                entity.Property(e => e.Exception).HasColumnName("exception");

                entity.Property(e => e.FailedAt)
                    .HasColumnType("timestamp(0) without time zone")
                    .HasColumnName("failed_at")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Payload).HasColumnName("payload");

                entity.Property(e => e.Queue).HasColumnName("queue");

                entity.Property(e => e.Uuid)
                    .HasMaxLength(255)
                    .HasColumnName("uuid");
            });

            modelBuilder.Entity<Job>(entity =>
            {
                entity.ToTable("jobs");

                entity.HasIndex(e => e.Queue, "jobs_queue_index");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Attempts).HasColumnName("attempts");

                entity.Property(e => e.AvailableAt).HasColumnName("available_at");

                entity.Property(e => e.CreatedAt).HasColumnName("created_at");

                entity.Property(e => e.Payload).HasColumnName("payload");

                entity.Property(e => e.Queue)
                    .HasMaxLength(255)
                    .HasColumnName("queue");

                entity.Property(e => e.ReservedAt).HasColumnName("reserved_at");
            });

            modelBuilder.Entity<JobBatch>(entity =>
            {
                entity.ToTable("job_batches");

                entity.Property(e => e.Id)
                    .HasMaxLength(255)
                    .HasColumnName("id");

                entity.Property(e => e.CancelledAt).HasColumnName("cancelled_at");

                entity.Property(e => e.CreatedAt).HasColumnName("created_at");

                entity.Property(e => e.FailedJobIds).HasColumnName("failed_job_ids");

                entity.Property(e => e.FailedJobs).HasColumnName("failed_jobs");

                entity.Property(e => e.FinishedAt).HasColumnName("finished_at");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name");

                entity.Property(e => e.Options).HasColumnName("options");

                entity.Property(e => e.PendingJobs).HasColumnName("pending_jobs");

                entity.Property(e => e.TotalJobs).HasColumnName("total_jobs");
            });

            modelBuilder.Entity<Migration>(entity =>
            {
                entity.ToTable("migrations");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Batch).HasColumnName("batch");

                entity.Property(e => e.Migration1)
                    .HasMaxLength(255)
                    .HasColumnName("migration");
            });

            modelBuilder.Entity<PasswordResetToken>(entity =>
            {
                entity.HasKey(e => e.Email)
                    .HasName("password_reset_tokens_pkey");

                entity.ToTable("password_reset_tokens");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .HasColumnName("email");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp(0) without time zone")
                    .HasColumnName("created_at");

                entity.Property(e => e.Token)
                    .HasMaxLength(255)
                    .HasColumnName("token");
            });

            modelBuilder.Entity<Sale>(entity =>
            {
                entity.ToTable("sales");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp(0) without time zone")
                    .HasColumnName("created_at");

                entity.Property(e => e.Item)
                    .HasMaxLength(255)
                    .HasColumnName("item");

                entity.Property(e => e.Revenue)
                    .HasPrecision(10, 2)
                    .HasColumnName("revenue");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("timestamp(0) without time zone")
                    .HasColumnName("updated_at");
            });

            modelBuilder.Entity<Salesorder>(entity =>
            {
                entity.ToTable("salesorder");

                entity.Property(e => e.Id)
                    .HasMaxLength(25)
                    .HasColumnName("id");

                entity.Property(e => e.Country)
                    .HasMaxLength(150)
                    .HasColumnName("country");

                entity.Property(e => e.ItemType)
                    .HasMaxLength(100)
                    .HasColumnName("item_type");

                entity.Property(e => e.OrderDate).HasColumnName("order_date");

                entity.Property(e => e.Priority)
                    .HasMaxLength(5)
                    .HasColumnName("priority");

                entity.Property(e => e.Region)
                    .HasMaxLength(150)
                    .HasColumnName("region");

                entity.Property(e => e.SalesChannel)
                    .HasMaxLength(50)
                    .HasColumnName("sales_channel");

                entity.Property(e => e.ShipDate).HasColumnName("ship_date");

                entity.Property(e => e.UnitCost).HasColumnName("unit_cost");

                entity.Property(e => e.UnitPrice).HasColumnName("unit_price");

                entity.Property(e => e.UnitsSold).HasColumnName("units_sold");
            });

            modelBuilder.Entity<Session>(entity =>
            {
                entity.ToTable("sessions");

                entity.HasIndex(e => e.LastActivity, "sessions_last_activity_index");

                entity.HasIndex(e => e.UserId, "sessions_user_id_index");

                entity.Property(e => e.Id)
                    .HasMaxLength(255)
                    .HasColumnName("id");

                entity.Property(e => e.IpAddress)
                    .HasMaxLength(45)
                    .HasColumnName("ip_address");

                entity.Property(e => e.LastActivity).HasColumnName("last_activity");

                entity.Property(e => e.Payload).HasColumnName("payload");

                entity.Property(e => e.UserAgent).HasColumnName("user_agent");

                entity.Property(e => e.UserId).HasColumnName("user_id");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.HasIndex(e => e.Email, "users_email_unique")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp(0) without time zone")
                    .HasColumnName("created_at");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .HasColumnName("email");

                entity.Property(e => e.EmailVerifiedAt)
                    .HasColumnType("timestamp(0) without time zone")
                    .HasColumnName("email_verified_at");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name");

                entity.Property(e => e.Password)
                    .HasMaxLength(255)
                    .HasColumnName("password");

                entity.Property(e => e.RememberToken)
                    .HasMaxLength(100)
                    .HasColumnName("remember_token");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("timestamp(0) without time zone")
                    .HasColumnName("updated_at");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
