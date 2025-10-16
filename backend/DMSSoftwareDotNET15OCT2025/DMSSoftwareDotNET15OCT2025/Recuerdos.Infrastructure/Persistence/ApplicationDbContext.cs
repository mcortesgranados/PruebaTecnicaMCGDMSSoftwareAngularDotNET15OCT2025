using DMSSoftwareDotNET15OCT2025.Recuerdos.Application.Domain.Models;
using DMSSoftwareDotNET15OCT2025.Recuerdos.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DMSSoftwareDotNET15OCT2025.Recuerdos.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> opts) : base(opts) { }

        public DbSet<User> Usuarios { get; set; } = null!;
        public DbSet<Recuerdo> Recuerdos { get; set; } = null!; 
        public DbSet<Lugar> Lugares { get; set; } = null!;
        public DbSet<RecuerdoLugar> Recuerdos_Lugares { get; set; } = null!;


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

            modelBuilder.Entity<Lugar>(b =>
            {
                b.ToTable("Lugares");
                b.HasKey(l => l.Id);
                b.Property(l => l.Nombre).HasMaxLength(150).IsRequired();
                b.Property(l => l.Descripcion);
                b.Property(l => l.Direccion).HasMaxLength(255);
                b.Property(l => l.FechaCreacion).HasDefaultValueSql("GETDATE()");
            });

            modelBuilder.Entity<RecuerdoLugar>(b =>
            {
                b.ToTable("Recuerdos_Lugares");
                b.HasKey(rl => new { rl.RecuerdoId, rl.LugarId });
                b.Property(rl => rl.FechaAsociacion).HasDefaultValueSql("GETDATE()");

                b.HasOne(rl => rl.Recuerdo)
                 .WithMany()
                 .HasForeignKey(rl => rl.RecuerdoId);

                b.HasOne(rl => rl.Lugar)
                 .WithMany()
                 .HasForeignKey(rl => rl.LugarId);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
