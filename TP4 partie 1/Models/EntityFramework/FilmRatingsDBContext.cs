using APIfilms.Models.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace TP4_partie_1.Models.EntityFramework
{
    public class FilmRatingsDBContext : DbContext
    {
        public FilmRatingsDBContext(DbContextOptions<FilmRatingsDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Utilisateur> Utilisateurs { get; set; } = null!;
        public virtual DbSet<Film> Films { get; set; } = null!;
        public virtual DbSet<Notation> Notations { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("public");

            modelBuilder.Entity<Notation>(entity =>
            {
                entity.HasKey(e => new { e.UtilisateurId, e.FilmId }).HasName("pk_not");

                entity.HasOne(d => d.FilmNote)
                      .WithMany(p => p.NotesFilm)
                      .OnDelete(DeleteBehavior.Restrict)
                      .HasConstraintName("fk_not_flm");

                entity.HasOne(d => d.UtilisateurNotant)
                      .WithMany(p => p.NotesUtilisateur)
                      .OnDelete(DeleteBehavior.Restrict)
                      .HasConstraintName("fk_not_utl");
            });

            modelBuilder.Entity<Utilisateur>()
                .HasIndex(u => u.Mail)
                .IsUnique()
                .HasDatabaseName("uq_utl_mail");

            modelBuilder.Entity<Utilisateur>()
                .Property(u => u.DateCreation)
                .HasDefaultValueSql("now()");

            modelBuilder.Entity<Utilisateur>()
                .Property(u => u.Pays)
                .HasDefaultValue("France");
        }
    }
}