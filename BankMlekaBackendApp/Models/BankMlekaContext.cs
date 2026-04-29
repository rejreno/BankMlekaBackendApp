using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BankMlekaBackendApp.Models;

public partial class BankMlekaContext : DbContext
{
    public BankMlekaContext()
    {
    }

    public BankMlekaContext(DbContextOptions<BankMlekaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BabyInfo> BabyInfos { get; set; }

    public virtual DbSet<BabyUpdate> BabyUpdates { get; set; }

    public virtual DbSet<Bed> Beds { get; set; }

    public virtual DbSet<Bedding> Beddings { get; set; }

    public virtual DbSet<Consumption> Consumptions { get; set; }

    public virtual DbSet<Delivery> Deliveries { get; set; }

    public virtual DbSet<Device> Devices { get; set; }

    public virtual DbSet<MilkInfo> MilkInfos { get; set; }

    public virtual DbSet<MilkTest> MilkTests { get; set; }

    public virtual DbSet<ParentInfo> ParentInfos { get; set; }

    public virtual DbSet<Rented> Renteds { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=BankMleka;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BabyInfo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__baby_inf__3213E83F573F049F");

            entity.ToTable("baby_info");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AvatarName)
                .HasDefaultValue("1.jpg")
                .HasColumnType("text")
                .HasColumnName("avatar_name");
            entity.Property(e => e.FatherId).HasColumnName("father_id");
            entity.Property(e => e.FirstName)
                .HasColumnType("text")
                .HasColumnName("first_name");
            entity.Property(e => e.Gender)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("gender");
            entity.Property(e => e.Height).HasColumnName("height");
            entity.Property(e => e.LastName)
                .HasColumnType("text")
                .HasColumnName("last_name");
            entity.Property(e => e.MotherId).HasColumnName("mother_id");
            entity.Property(e => e.Pesel)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("pesel");
            entity.Property(e => e.Weight).HasColumnName("weight");

            entity.HasOne(d => d.Father).WithMany(p => p.BabyInfoFathers)
                .HasForeignKey(d => d.FatherId)
                .HasConstraintName("FK__baby_info__fathe__4D94879B");

            entity.HasOne(d => d.Mother).WithMany(p => p.BabyInfoMothers)
                .HasForeignKey(d => d.MotherId)
                .HasConstraintName("FK__baby_info__mothe__4CA06362");
        });

        modelBuilder.Entity<BabyUpdate>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__baby_upd__3213E83F1CE88693");

            entity.ToTable("baby_updates");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BabyId).HasColumnName("baby_id");
            entity.Property(e => e.Consumption).HasColumnName("consumption");
            entity.Property(e => e.Height).HasColumnName("height");
            entity.Property(e => e.UpdateDate).HasColumnName("update_date");
            entity.Property(e => e.Weight).HasColumnName("weight");

            entity.HasOne(d => d.Baby).WithMany(p => p.BabyUpdates)
                .HasForeignKey(d => d.BabyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__baby_upda__baby___5070F446");
        });

        modelBuilder.Entity<Bed>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__beds__3213E83F21AF54EC");

            entity.ToTable("beds");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BedNumber).HasColumnName("bed_number");
            entity.Property(e => e.Floor).HasColumnName("floor");
            entity.Property(e => e.Room).HasColumnName("room");
        });

        modelBuilder.Entity<Bedding>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__beddings__3213E83F24B16625");

            entity.ToTable("beddings");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AssignDate).HasColumnName("assign_date");
            entity.Property(e => e.BabyId).HasColumnName("baby_id");
            entity.Property(e => e.BedId).HasColumnName("bed_id");
            entity.Property(e => e.MotherId).HasColumnName("mother_id");
            entity.Property(e => e.Note)
                .HasColumnType("text")
                .HasColumnName("note");
            entity.Property(e => e.ReleaseDate).HasColumnName("release_date");

            entity.HasOne(d => d.Baby).WithMany(p => p.Beddings)
                .HasForeignKey(d => d.BabyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__beddings__baby_i__5629CD9C");

            entity.HasOne(d => d.Bed).WithMany(p => p.Beddings)
                .HasForeignKey(d => d.BedId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__beddings__bed_id__5535A963");

            entity.HasOne(d => d.Mother).WithMany(p => p.Beddings)
                .HasForeignKey(d => d.MotherId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__beddings__mother__571DF1D5");
        });

        modelBuilder.Entity<Consumption>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__consumpt__3213E83F7355E328");

            entity.ToTable("consumption");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Amount).HasColumnName("amount");
            entity.Property(e => e.BabyId).HasColumnName("baby_id");
            entity.Property(e => e.MilkId).HasColumnName("milk_id");
            entity.Property(e => e.Timestamp)
                .HasColumnType("datetime")
                .HasColumnName("timestamp");

            entity.HasOne(d => d.Baby).WithMany(p => p.Consumptions)
                .HasForeignKey(d => d.BabyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__consumpti__baby___60A75C0F");

            entity.HasOne(d => d.Milk).WithMany(p => p.Consumptions)
                .HasForeignKey(d => d.MilkId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__consumpti__milk___619B8048");
        });

        modelBuilder.Entity<Delivery>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__delivery__3213E83F99D1DCF3");

            entity.ToTable("delivery");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AcceptanceDate)
                .HasColumnType("datetime")
                .HasColumnName("acceptance_date");
            entity.Property(e => e.Amount).HasColumnName("amount");
            entity.Property(e => e.DeviceId).HasColumnName("device_id");
            entity.Property(e => e.ExpectedDate)
                .HasColumnType("datetime")
                .HasColumnName("expected_date");
            entity.Property(e => e.MilkId).HasColumnName("milk_id");
            entity.Property(e => e.ParentId).HasColumnName("parent_id");
            entity.Property(e => e.TransportType)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("transport_type");

            entity.HasOne(d => d.Device).WithMany(p => p.Deliveries)
                .HasForeignKey(d => d.DeviceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__delivery__device__6754599E");

            entity.HasOne(d => d.Milk).WithMany(p => p.Deliveries)
                .HasForeignKey(d => d.MilkId)
                .HasConstraintName("FK__delivery__milk_i__68487DD7");

            entity.HasOne(d => d.Parent).WithMany(p => p.Deliveries)
                .HasForeignKey(d => d.ParentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__delivery__parent__66603565");
        });

        modelBuilder.Entity<Device>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__devices__3213E83F619ED9A8");

            entity.ToTable("devices");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.MaxAmount).HasColumnName("max_amount");
            entity.Property(e => e.Name)
                .HasColumnType("text")
                .HasColumnName("name");
            entity.Property(e => e.Type)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("type");
        });

        modelBuilder.Entity<MilkInfo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__milk_inf__3213E83F97A30FCA");

            entity.ToTable("milk_info");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AcceptanceDate)
                .HasColumnType("datetime")
                .HasColumnName("acceptance_date");
            entity.Property(e => e.BottleId).HasColumnName("bottle_id");
            entity.Property(e => e.DonorId).HasColumnName("donor_id");
            entity.Property(e => e.LastTestId).HasColumnName("last_test_id");
            entity.Property(e => e.MaxVolume).HasColumnName("max_volume");
            entity.Property(e => e.Storage)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("storage");
            entity.Property(e => e.TerminationDate)
                .HasColumnType("datetime")
                .HasColumnName("termination_date");
            entity.Property(e => e.Volume).HasColumnName("volume");

            entity.HasOne(d => d.Donor).WithMany(p => p.MilkInfos)
                .HasForeignKey(d => d.DonorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__milk_info__donor__5CD6CB2B");

            entity.HasOne(d => d.LastTest).WithMany(p => p.MilkInfos)
                .HasForeignKey(d => d.LastTestId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__milk_info__last___5DCAEF64");
        });

        modelBuilder.Entity<MilkTest>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__milk_tes__3213E83F7C84B7E8");

            entity.ToTable("milk_test");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Calories).HasColumnName("calories");
            entity.Property(e => e.Carbs).HasColumnName("carbs");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.DonorId).HasColumnName("donor_id");
            entity.Property(e => e.Fat).HasColumnName("fat");
            entity.Property(e => e.Protein).HasColumnName("protein");

            entity.HasOne(d => d.Donor).WithMany(p => p.MilkTests)
                .HasForeignKey(d => d.DonorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__milk_test__donor__59FA5E80");
        });

        modelBuilder.Entity<ParentInfo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__parent_i__3213E83F4FE68BE4");

            entity.ToTable("parent_info");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DonorStatus).HasColumnName("donor_status");
            entity.Property(e => e.FirstName)
                .HasColumnType("text")
                .HasColumnName("first_name");
            entity.Property(e => e.Gender)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("gender");
            entity.Property(e => e.LastName)
                .HasColumnType("text")
                .HasColumnName("last_name");
            entity.Property(e => e.Pesel)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("pesel");
        });

        modelBuilder.Entity<Rented>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__rented__3213E83F13B87B9A");

            entity.ToTable("rented");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DeviceId).HasColumnName("device_id");
            entity.Property(e => e.RentDate).HasColumnName("rent_date");
            entity.Property(e => e.ReturnDate).HasColumnName("return_date");
            entity.Property(e => e.TransportId).HasColumnName("transport_id");

            entity.HasOne(d => d.Device).WithMany(p => p.Renteds)
                .HasForeignKey(d => d.DeviceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__rented__device_i__6B24EA82");

            entity.HasOne(d => d.Transport).WithMany(p => p.Renteds)
                .HasForeignKey(d => d.TransportId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__rented__transpor__6C190EBB");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
