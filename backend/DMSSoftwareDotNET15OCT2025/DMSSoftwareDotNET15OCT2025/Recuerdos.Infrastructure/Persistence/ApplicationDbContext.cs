using DMSSoftwareDotNET15OCT2025.Recuerdos.Application.Domain.Entities;
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
        public DbSet<Objeto> Objetos { get; set; } = null!;
        public DbSet<RecuerdoObjeto> Recuerdos_Objetos { get; set; } = null!;
        public DbSet<Nota> Notas { get; set; } = null!;
        public DbSet<Persona> Personas { get; set; } = null!;
        public DbSet<RecuerdoPersona> Recuerdos_Personas { get; set; } = null!;





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

            modelBuilder.Entity<Objeto>(b =>
            {
                b.ToTable("Objetos");
                b.HasKey(o => o.Id);
                b.Property(o => o.Nombre).HasMaxLength(150).IsRequired();
                b.Property(o => o.Descripcion);
                b.Property(o => o.FechaCreacion).HasDefaultValueSql("GETDATE()");

                b.HasOne(o => o.Creador)
                    .WithMany() // Puedes agregar colección de objetos si lo deseas
                    .HasForeignKey(o => o.CreadorId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<RecuerdoObjeto>(b =>
            {
                b.ToTable("Recuerdos_Objetos");
                b.HasKey(ro => new { ro.RecuerdoId, ro.ObjetoId });

                b.Property(ro => ro.FechaAsociacion).HasDefaultValueSql("GETDATE()");

                b.HasOne(ro => ro.Recuerdo)
                 .WithMany()
                 .HasForeignKey(ro => ro.RecuerdoId);

                b.HasOne(ro => ro.Objeto)
                 .WithMany()
                 .HasForeignKey(ro => ro.ObjetoId);

                b.HasOne(ro => ro.AsociadoPor)
                 .WithMany()
                 .HasForeignKey(ro => ro.AsociadoPorId)
                 .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Nota>(b =>
            {
                b.ToTable("Notas");
                b.HasKey(n => n.Id);
                b.Property(n => n.Texto).IsRequired();
                b.Property(n => n.FechaCreacion).HasDefaultValueSql("GETDATE()");

                b.HasOne(n => n.Recuerdo)
                 .WithMany()
                 .HasForeignKey(n => n.RecuerdoId);

                b.HasOne(n => n.Creador)
                 .WithMany()
                 .HasForeignKey(n => n.CreadorId)
                 .OnDelete(DeleteBehavior.Restrict);

                b.HasOne(n => n.AsociadoPor)
                 .WithMany()
                 .HasForeignKey(n => n.AsociadoPorId)
                 .OnDelete(DeleteBehavior.Restrict);
            });


            modelBuilder.Entity<Persona>(b =>
            {
                b.ToTable("Personas");
                b.HasKey(p => p.PersonaId);
                b.Property(p => p.Nombre).HasMaxLength(100).IsRequired();
                b.Property(p => p.Descripcion);
                b.Property(p => p.CreadorId).IsRequired();
            });

            modelBuilder.Entity<RecuerdoPersona>(b =>
            {
                b.ToTable("Recuerdos_Personas");
                b.HasKey(rp => new { rp.RecuerdoId, rp.PersonaId });

                b.HasOne(rp => rp.Recuerdo)
                    .WithMany(r => r.RecuerdosPersonas)
                    .HasForeignKey(rp => rp.RecuerdoId);

                b.HasOne(rp => rp.Persona)
                    .WithMany(p => p.RecuerdosPersonas)
                    .HasForeignKey(rp => rp.PersonaId);

                b.HasOne(rp => rp.AsociadoPor)
                    .WithMany()
                    .HasForeignKey(rp => rp.AsociadoPorId);

                b.Property(rp => rp.FechaAsociacion).HasDefaultValueSql("GETDATE()");
            });
            base.OnModelCreating(modelBuilder);
        }
    }

}
