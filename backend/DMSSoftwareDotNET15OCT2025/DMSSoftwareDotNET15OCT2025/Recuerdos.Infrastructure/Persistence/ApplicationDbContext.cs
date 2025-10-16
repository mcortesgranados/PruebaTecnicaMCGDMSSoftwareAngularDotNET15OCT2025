using DMSSoftwareDotNET15OCT2025.Recuerdos.Application.Domain.Models;
using DMSSoftwareDotNET15OCT2025.Recuerdos.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DMSSoftwareDotNET15OCT2025.Recuerdos.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> opts) : base(opts) { }

        public DbSet<User> Usuarios { get; set; } = null!;
        public DbSet<Recuerdo> Recuerdos { get; set; } = null!; // <-- AGREGAR ESTO


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(b =>
            {
                b.ToTable("Usuarios");
                b.HasKey(u => u.UsuarioId);
                b.Property(u => u.Nombre).HasMaxLength(100).IsRequired();
                b.Property(u => u.Email).HasMaxLength(150).IsRequired();
                b.HasIndex(u => u.Email).IsUnique();
                b.Property(u => u.PasswordHash).HasMaxLength(255).IsRequired();
                b.Property(u => u.FechaRegistro).HasDefaultValueSql("GETDATE()");
                b.Property(u => u.EsActivo).HasDefaultValue(true);
            });

            modelBuilder.Entity<Recuerdo>(b =>
            {
                b.ToTable("Recuerdos");
                b.HasKey(r => r.Id); // <-- Usar Id
                b.Property(r => r.Situacion).HasMaxLength(500).IsRequired();
                b.Property(r => r.FechaCreacion).HasDefaultValueSql("GETDATE()");
                b.Property(r => r.Estado).HasConversion<string>().HasMaxLength(50).IsRequired();

                b.HasOne(r => r.Creador)
                    .WithMany(u => u.Recuerdos)
                    .HasForeignKey(r => r.CreadorId);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
