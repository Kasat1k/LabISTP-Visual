using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ISTPLab.Models;

public partial class TimeTableContext : DbContext
{
    public TimeTableContext()
    {
    }

    public TimeTableContext(DbContextOptions<TimeTableContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Auditory> Auditories { get; set; }

    public virtual DbSet<Faculty> Faculties { get; set; }

    public virtual DbSet<Group> Groups { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<Subject> Subjects { get; set; }

    public virtual DbSet<Teacher> Teachers { get; set; }

    public virtual DbSet<Timetable> Timetables { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-DOQKB49;Database=TimeTable;Trusted_Connection=True;Trust Server Certificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Auditory>(entity =>
        {
            entity.ToTable("AUDITORY");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Faculty).HasColumnName("FACULTY");
            entity.Property(e => e.Floor).HasColumnName("FLOOR");
            entity.Property(e => e.Number).HasColumnName("NUMBER");

            entity.HasOne(d => d.FacultyNavigation).WithMany(p => p.Auditories)
                .HasForeignKey(d => d.Faculty)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AUDITORY_FACULTY");
        });

        modelBuilder.Entity<Faculty>(entity =>
        {
            entity.ToTable("FACULTY");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name)
                .HasMaxLength(75)
                .IsUnicode(false)
                .HasColumnName("NAME");
        });

        modelBuilder.Entity<Group>(entity =>
        {
            entity.ToTable("GROUP");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Faculty).HasColumnName("FACULTY");
            entity.Property(e => e.Name)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("NAME");

            entity.HasOne(d => d.FacultyNavigation).WithMany(p => p.Groups)
                .HasForeignKey(d => d.Faculty)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GROUP_FACULTY");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.ToTable("STUDENT");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.GroupSt).HasColumnName("GROUP_ST");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NAME");

            entity.HasOne(d => d.GroupStNavigation).WithMany(p => p.Students)
                .HasForeignKey(d => d.GroupSt)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_STUDENT_GROUP");
        });

        modelBuilder.Entity<Subject>(entity =>
        {
            entity.ToTable("SUBJECT");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("NAME");
        });

        modelBuilder.Entity<Teacher>(entity =>
        {
            entity.ToTable("TEACHER");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Faculty).HasColumnName("FACULTY");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NAME");

            entity.HasOne(d => d.FacultyNavigation).WithMany(p => p.Teachers)
                .HasForeignKey(d => d.Faculty)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TEACHER_FACULTY");
        });

        modelBuilder.Entity<Timetable>(entity =>
        {
            entity.ToTable("TIMETABLE");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Auditory).HasColumnName("AUDITORY");
            entity.Property(e => e.GroupTt).HasColumnName("GROUP_TT");
            entity.Property(e => e.Subject).HasColumnName("SUBJECT");
            entity.Property(e => e.Teacher).HasColumnName("TEACHER");
            entity.Property(e => e.Time).HasColumnName("Time");

            entity.HasOne(d => d.AuditoryNavigation).WithMany(p => p.Timetables)
                .HasForeignKey(d => d.Auditory)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TIMETABLE_AUDITORY");

            entity.HasOne(d => d.GroupTtNavigation).WithMany(p => p.Timetables)
                .HasForeignKey(d => d.GroupTt)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TIMETABLE_GROUP");

            entity.HasOne(d => d.SubjectNavigation).WithMany(p => p.Timetables)
                .HasForeignKey(d => d.Subject)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TIMETABLE_SUBJECT");

            entity.HasOne(d => d.TeacherNavigation).WithMany(p => p.Timetables)
                .HasForeignKey(d => d.Teacher)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TIMETABLE_TEACHER");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
