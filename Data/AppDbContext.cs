using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace API.Models;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Approval> Approvals { get; set; }

    public virtual DbSet<Expense> Expenses { get; set; }

    public virtual DbSet<History> Histories { get; set; }

    public virtual DbSet<Position> Positions { get; set; }

    public virtual DbSet<Staff> Staff { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<Trip> Trips { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=.\\BSISqlExpress;Initial Catalog=TripExpense;Integrated Security=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Approval>(entity =>
        {
            entity.HasKey(e => e.ApprovalId).HasName("PK__Approval__328477D420DBFB84");

            entity.Property(e => e.ApprovalDate).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Approver).WithMany(p => p.Approvals)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Approval_Staff");

            entity.HasOne(d => d.Expense).WithMany(p => p.Approvals)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Approval__Expens__634EBE90");
        });

        modelBuilder.Entity<Expense>(entity =>
        {
            entity.HasKey(e => e.ExpenseId).HasName("PK__Expense__1445CFF346454A8D");

            entity.Property(e => e.LastModified).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Trip).WithMany(p => p.Expenses)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Expense__TripID__5D95E53A");
        });

        modelBuilder.Entity<History>(entity =>
        {
            entity.HasKey(e => e.HistoryId).HasName("PK__History__4D7B4ADD50EF7F94");

            entity.HasOne(d => d.Approval).WithMany(p => p.Histories)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__History__Approva__793DFFAF");

            entity.HasOne(d => d.Staff).WithMany(p => p.Histories)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__History__StaffID__7849DB76");
        });

        modelBuilder.Entity<Position>(entity =>
        {
            entity.HasKey(e => e.PositionId).HasName("PK__Position__60BB9A59FE758D3E");

            entity.Property(e => e.BalanceLimit).HasDefaultValue(0.0m);
        });

        modelBuilder.Entity<Staff>(entity =>
        {
            entity.HasKey(e => e.StaffId).HasName("PK__Staff__96D4AAF7CF9F061C");

            entity.Property(e => e.LastLogin).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.LastModified).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.MaxAttempt).HasDefaultValue((byte)5);

            entity.HasOne(d => d.Position).WithMany(p => p.Staff)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Staff_Position");
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.HasKey(e => e.StatusId).HasName("PK__Status__C8EE20436ADB866A");
        });

        modelBuilder.Entity<Trip>(entity =>
        {
            entity.HasKey(e => e.TripId).HasName("PK__Trip__51DC711EA8EF4E2F");

            entity.Property(e => e.IsDeleted).HasDefaultValue(false);
            entity.Property(e => e.LastModified).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.TotalCost).HasDefaultValue(10m);

            entity.HasOne(d => d.Status).WithMany(p => p.Trips).HasConstraintName("FK__Trip__StatusID__58D1301D");

            entity.HasOne(d => d.SubmittedByNavigation).WithMany(p => p.Trips)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Trip_Staff");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
