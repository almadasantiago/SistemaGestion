using AdminArchivos.Domain.Entidades;
using Microsoft.EntityFrameworkCore;

namespace AdminArchivos.Infraestructure.BaseDeDatos
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Entrada> Entradas { get; set; }
        public DbSet<Archivo> Archivos { get; set; }
        public DbSet<Comentario> Comentarios { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("Usuarios");
                entity.HasKey(u => u.Id);
                entity.HasIndex(u => u.Email).IsUnique();
                entity.Property(u => u.Nombre).IsRequired().HasMaxLength(100);
                entity.Property(u => u.Apellido).IsRequired().HasMaxLength(100);
                entity.Property(u => u.Email).IsRequired().HasMaxLength(100);
                entity.Property(u => u.Password).IsRequired();
                entity.Property(u => u.Rol).IsRequired().HasConversion<string>().HasMaxLength(20);
            });

            modelBuilder.Entity<Entrada>(entity =>
            {
                entity.ToTable("Entradas");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Estado).IsRequired().HasConversion<string>().HasMaxLength(20);
                entity.Property(e => e.FechaDeActualizacion).IsRequired();
                entity.Property(e => e.UsuarioId).IsRequired();
                entity.Property(e => e.FechaSubida).IsRequired();
                entity.Property(e => e.NombreArchivo).IsRequired().HasMaxLength(200);

                entity.HasOne(e => e.Usuario)
                      .WithMany(u => u.Entradas)
                      .HasForeignKey(e => e.UsuarioId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Archivo>(entity =>
            {
                entity.ToTable("Archivos");
                entity.HasKey(a => a.Id);
                entity.Property(a => a.Nombre).IsRequired().HasMaxLength(255);
                entity.Property(a => a.Ruta).IsRequired();
                entity.Property(a => a.Tipo).IsRequired().HasMaxLength(100);
                entity.Property(a => a.Tamaño).IsRequired();

                entity.HasOne(a => a.Entrada)
                      .WithMany(e => e.Archivos)
                      .HasForeignKey(a => a.IdEntrada)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Comentario>(entity =>
            {
                entity.ToTable("Comentarios");
                entity.HasKey(c => c.Id);
                entity.Property(c => c.Contenido).IsRequired();
                entity.Property(c => c.FechaComentario).IsRequired();

                entity.HasOne(c => c.Entrada)
                      .WithMany(e => e.Comentarios)
                      .HasForeignKey(c => c.IdEntrada)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(c => c.Usuario)
                      .WithMany()
                      .HasForeignKey(c => c.IdUsuario)
                      .OnDelete(DeleteBehavior.NoAction);
            });
        }
    }
}