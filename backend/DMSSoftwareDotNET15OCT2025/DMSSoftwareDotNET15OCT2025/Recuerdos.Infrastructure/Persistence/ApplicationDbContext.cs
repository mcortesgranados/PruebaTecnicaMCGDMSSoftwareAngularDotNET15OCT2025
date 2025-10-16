using DMSSoftwareDotNET15OCT2025.Recuerdos.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DMSSoftwareDotNET15OCT2025.Recuerdos.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> opts) : base(opts) { }

        public DbSet<User> Usuarios { get; set; } = null!;

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

            base.OnModelCreating(modelBuilder);
        }
    }
}
