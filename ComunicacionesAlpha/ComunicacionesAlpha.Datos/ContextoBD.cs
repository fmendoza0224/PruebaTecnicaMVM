using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ComunicacionesAlpha.Infraestructura.Models
{
    public partial class ContextoBD : DbContext
    {
        public ContextoBD()
        {
        }

        public ContextoBD(DbContextOptions<ContextoBD> options)
            : base(options)
        {
        }

        public virtual DbSet<AuditoriaCorrespondencium> AuditoriaCorrespondencia { get; set; }
        public virtual DbSet<Cargo> Cargos { get; set; }
        public virtual DbSet<Empleado> Empleados { get; set; }
        public virtual DbSet<EstadosCorrespondencium> EstadosCorrespondencia { get; set; }
        public virtual DbSet<RegistroCorrespondencium> RegistroCorrespondencia { get; set; }
        public virtual DbSet<Role> Roles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(string.Empty);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<AuditoriaCorrespondencium>(entity =>
            {
                entity.HasKey(e => e.IdAuditoriaCorrespondencia);

                entity.Property(e => e.FechaHoraRegistro).HasColumnType("datetime");

                entity.Property(e => e.IdAuditoriaCorrespondencia).ValueGeneratedOnAdd();

                entity.HasOne(d => d.IdEmpleadoNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdEmpleado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AuditoriaCorrespondencia_Empleado");

                entity.HasOne(d => d.IdEstadoCorrespondenciaNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdEstadoCorrespondencia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AuditoriaCorrespondencia_EstadosCorrespondencia");

                entity.HasOne(d => d.IdRegistroCorrespondenciaNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdRegistroCorrespondencia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AuditoriaCorrespondencia_RegistroCorrespondencia");
            });

            modelBuilder.Entity<Cargo>(entity =>
            {
                entity.HasKey(e => e.IdCargo);

                entity.Property(e => e.IdCargo).ValueGeneratedNever();

                entity.Property(e => e.NombreCargo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Empleado>(entity =>
            {
                entity.HasKey(e => e.IdEmpleado);

                entity.ToTable("Empleado");

                entity.Property(e => e.IdEmpleado).ValueGeneratedNever();

                entity.Property(e => e.ApellidosEmpleado)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DireccionResidencia)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmailCorporativo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmailPersonal)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FechaInicioLabores).HasColumnType("datetime");

                entity.Property(e => e.FechaNacimiento).HasColumnType("datetime");

                entity.Property(e => e.NombresEmpleado)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TelefonoResidencia)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCargoNavigation)
                    .WithMany(p => p.Empleados)
                    .HasForeignKey(d => d.IdCargo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Empleado_Cargos");

                entity.HasOne(d => d.IdRolNavigation)
                    .WithMany(p => p.Empleados)
                    .HasForeignKey(d => d.IdRol)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Empleado_Roles");
            });

            modelBuilder.Entity<EstadosCorrespondencium>(entity =>
            {
                entity.HasKey(e => e.IdEstadoCorrespondencia);

                entity.Property(e => e.IdEstadoCorrespondencia).ValueGeneratedNever();

                entity.Property(e => e.DescripcionEstadoCorrespondencia)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RegistroCorrespondencium>(entity =>
            {
                entity.HasKey(e => e.IdRegistroCorrespondencia);

                entity.Property(e => e.ApellidosDestinatario)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ApellidosRemitente)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Consecutivo)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DireccionDestinatario)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DocumentoDigital).HasColumnType("text");

                entity.Property(e => e.EmailDestinatario)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmailRemitente)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NombresDestinatario)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NombresRemitente)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TelefonoDestinatario)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.TelefonoRemitente)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.IdRol);

                entity.Property(e => e.IdRol).ValueGeneratedNever();

                entity.Property(e => e.NombreRol)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Permisos)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
