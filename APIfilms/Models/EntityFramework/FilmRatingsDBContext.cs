using Microsoft.EntityFrameworkCore;

namespace APIfilms.Models.EntityFramework
{
    public class FilmRatingsDBContext : DbContext
    {
        public FilmRatingsDBContext(DbContextOptions<FilmRatingsDBContext> options) : base(options) { }
        public DbSet<Film> Films { get; set; }
        public DbSet<Utilisateur> Utilisateurs { get; set; }
        public DbSet<Notation> Notations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // À adapter avec vos paramètres de connexion réels
                optionsBuilder.UseNpgsql("Host=localhost;Database=FilmsRatingsDB;Username=postgres;Password=postgres");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("public");

            // --- Configuration Utilisateur ---
            modelBuilder.Entity<Utilisateur>(entity =>
            {
                entity.HasIndex(u => u.Mail).IsUnique();
                entity.Property(u => u.Pays).HasDefaultValue("France");
                entity.Property(u => u.DateCreation).HasDefaultValueSql("now()");
                entity.Property(u => u.Mobile).IsFixedLength();
                entity.Property(u => u.CodePostal).IsFixedLength();
            });

            // --- Configuration Notation (Clé composite + FK nommées + Restrict) ---
            modelBuilder.Entity<Notation>(entity =>
            {
                entity.HasKey(n => new { n.UtilisateurId, n.FilmId }).HasName("pk_not");

                entity.HasOne(n => n.UtilisateurNotant)
                    .WithMany(u => u.NotesUtilisateur)
                    .HasForeignKey(n => n.UtilisateurId)
                    .HasConstraintName("fk_not_utl")
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(n => n.FilmNote)
                    .WithMany(f => f.NotesFilm)
                    .HasForeignKey(n => n.FilmId)
                    .HasConstraintName("fk_not_flm")
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // --- Configuration Film (Index non unique) ---
            modelBuilder.Entity<Film>(entity =>
            {
                entity.HasIndex(f => f.Titre).IsUnique(false);
            });
        }
    }
}
