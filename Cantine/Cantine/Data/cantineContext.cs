using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Cantine.Data.Models;

#nullable disable

namespace Cantine.Data
{
    public partial class cantineContext : DbContext
    {
        public cantineContext()
        {
        }

        public cantineContext(DbContextOptions<cantineContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Eleve> Eleves { get; set; }
        public virtual DbSet<Menus> Menus { get; set; }
        public virtual DbSet<MenuDuJour> MenuDuJour { get; set; }
        public virtual DbSet<Reglement> Reglements { get; set; }
        public virtual DbSet<Reservations> Reservations { get; set; }
        public virtual DbSet<ReservationsMenu> Reservationsmenus { get; set; }
        public virtual DbSet<TypePaiement> Typepaiements { get; set; }
        public virtual DbSet<Utilisateur> Utilisateurs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySQL("server=localhost;user=root;database=cantine;ssl mode=none");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Eleve>(entity =>
            {
                entity.HasKey(e => e.IdUtilisateur)
                    .HasName("PRIMARY");

                entity.ToTable("eleves");

                entity.Property(e => e.IdUtilisateur).HasColumnType("int(11)");

                entity.Property(e => e.Adresse).HasMaxLength(200);

                entity.Property(e => e.Classe)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DateNaissance).HasColumnType("date");

                entity.Property(e => e.Mail)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.Nom)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Prenom)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Menus>(entity =>
            {
                entity.HasKey(e => e.IdMenu)
                    .HasName("PRIMARY");

                entity.ToTable("menus");

                entity.Property(e => e.IdMenu).HasColumnType("int(11)");

                entity.Property(e => e.Dessert)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.Entree)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.LibelleMenu)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.Plat)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.Prix).HasColumnType("decimal(15,2)");
            });

            modelBuilder.Entity<MenuDuJour>(entity =>
            {
                entity.HasKey(e => e.IdMenuDuJour)
                    .HasName("PRIMARY");

                entity.ToTable("MenuDuJour");

                entity.HasIndex(e => e.IdMenu, "FK_MenuDuJour_Menus");

                entity.Property(e => e.IdMenuDuJour).HasColumnType("int(11)");

                entity.Property(e => e.DateDuJour).HasColumnType("date");

                entity.Property(e => e.IdMenu).HasColumnType("int(11)");

                entity.HasOne(d => d.IdMenuNavigation)
                    .WithMany(p => p.Menudujours)
                    .HasForeignKey(d => d.IdMenu)
                    .HasConstraintName("FK_MenuDuJour_Menus");
            });

            modelBuilder.Entity<Reglement>(entity =>
            {
                entity.HasKey(e => e.IdReglement)
                    .HasName("PRIMARY");

                entity.ToTable("reglements");

                entity.HasIndex(e => e.IdUtilisateur, "FK_Reglements_Eleves");

                entity.HasIndex(e => e.IdReservation, "FK_Reglements_Reservations");

                entity.HasIndex(e => e.IdTypePaiement, "FK_Reglements_TypePaiements");

                entity.Property(e => e.IdReglement).HasColumnType("int(11)");

                entity.Property(e => e.DateReglement).HasColumnType("date");

                entity.Property(e => e.IdReservation).HasColumnType("int(11)");

                entity.Property(e => e.IdTypePaiement).HasColumnType("int(11)");

                entity.Property(e => e.IdUtilisateur).HasColumnType("int(11)");

                entity.HasOne(d => d.IdReservationNavigation)
                    .WithMany(p => p.Reglements)
                    .HasForeignKey(d => d.IdReservation)
                    .HasConstraintName("FK_Reglements_Reservations");

                entity.HasOne(d => d.IdTypePaiementNavigation)
                    .WithMany(p => p.Reglements)
                    .HasForeignKey(d => d.IdTypePaiement)
                    .HasConstraintName("FK_Reglements_TypePaiements");

                entity.HasOne(d => d.IdUtilisateurNavigation)
                    .WithMany(p => p.Reglements)
                    .HasForeignKey(d => d.IdUtilisateur)
                    .HasConstraintName("FK_Reglements_Eleves");
            });

            modelBuilder.Entity<Reservations>(entity =>
            {
                entity.HasKey(e => e.IdReservation)
                    .HasName("PRIMARY");

                entity.ToTable("reservations");

                entity.HasIndex(e => e.IdUtilisateur, "FK_Reservations_Eleves");

                entity.Property(e => e.IdReservation).HasColumnType("int(11)");

                entity.Property(e => e.DateRepas).HasColumnType("date");

                entity.Property(e => e.DateReservation).HasColumnType("date");

                entity.Property(e => e.IdUtilisateur).HasColumnType("int(11)");

                entity.HasOne(d => d.IdUtilisateurNavigation)
                    .WithMany(p => p.Reservations)
                    .HasForeignKey(d => d.IdUtilisateur)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Reservations_Eleves");
            });

            modelBuilder.Entity<ReservationsMenu>(entity =>
            {
                entity.HasKey(e => e.IdReservationMenu)
                    .HasName("PRIMARY");

                entity.ToTable("reservationsmenus");

                entity.HasIndex(e => e.IdMenu, "FK_ReservationsMenus_Menus");

                entity.HasIndex(e => e.IdReservation, "FK_ReservationsMenus_Reservations");

                entity.Property(e => e.IdReservationMenu).HasColumnType("int(11)");

                entity.Property(e => e.IdMenu).HasColumnType("int(11)");

                entity.Property(e => e.IdReservation).HasColumnType("int(11)");

                entity.HasOne(d => d.Menu)
                    .WithMany(p => p.Reservationsmenus)
                    .HasForeignKey(d => d.IdMenu)
                    .HasConstraintName("FK_ReservationsMenus_Menus");

                entity.HasOne(d => d.IdReservationNavigation)
                    .WithMany(p => p.Reservationsmenus)
                    .HasForeignKey(d => d.IdReservation)
                    .HasConstraintName("FK_ReservationsMenus_Reservations");
            });

            modelBuilder.Entity<TypePaiement>(entity =>
            {
                entity.HasKey(e => e.IdTypePaiement)
                    .HasName("PRIMARY");

                entity.ToTable("typepaiements");

                entity.Property(e => e.IdTypePaiement).HasColumnType("int(11)");

                entity.Property(e => e.LibelleTypePaiement)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Utilisateur>(entity =>
            {
                entity.HasKey(e => e.IdUtilisateur)
                    .HasName("PRIMARY");

                entity.ToTable("utilisateurs");

                entity.Property(e => e.IdUtilisateur).HasColumnType("int(11)");

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.MotDePasse)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TypeUtilisateur).HasColumnType("int(11)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
