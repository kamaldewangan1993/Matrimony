using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Matrimony.Models;

public partial class MatrimonyContext : DbContext
{
    public MatrimonyContext()
    {
    }

    public MatrimonyContext(DbContextOptions<MatrimonyContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Preference> Preferences { get; set; }

    public virtual DbSet<Profile> Profiles { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\kamal;Database=Matrimony;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Preference>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Preference");

            entity.Property(e => e.FamilyStatus)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.Location)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.Occupation)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.PreferenceId)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.UserId)
                .HasMaxLength(10)
                .IsFixedLength();
        });

        modelBuilder.Entity<Profile>(entity =>
        {
            entity.ToTable("Profile");

            entity.Property(e => e.AboutMyFamily)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.AboutMySelf)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.BirthPlace)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.BirthTime)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CompanyName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Designation)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Dob)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("DOB");
            entity.Property(e => e.Education)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FatherName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Height)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Hobby)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Images)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.JobLocation)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.MotherName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Weight)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");

            entity.Property(e => e.UserId).ValueGeneratedNever();
            entity.Property(e => e.AadharNo)
                .HasMaxLength(12)
                .IsUnicode(false);
            entity.Property(e => e.Address)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.AppId)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.District)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.EmailId)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.MobileNo)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
