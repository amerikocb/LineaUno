using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace VLP.Models
{
    public partial class BDVLPContext : DbContext
    {
        public BDVLPContext()
        {
        }

        public BDVLPContext(DbContextOptions<BDVLPContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TabAgenda> TabAgenda { get; set; }
        public virtual DbSet<TabBeneficio> TabBeneficio { get; set; }
        public virtual DbSet<TabBusquedaH> TabBusquedaH { get; set; }
        public virtual DbSet<TabCatBeneficio> TabCatBeneficio { get; set; }
        public virtual DbSet<TabContribuyente> TabContribuyente { get; set; }
        public virtual DbSet<TabDetBeneficio> TabDetBeneficio { get; set; }
        public virtual DbSet<TabEvento> TabEvento { get; set; }
        public virtual DbSet<TabInstitucion> TabInstitucion { get; set; }
        public virtual DbSet<TabMovBeneficio> TabMovBeneficio { get; set; }
        public virtual DbSet<TabPeriodo> TabPeriodo { get; set; }
        public virtual DbSet<TabUsuario> TabUsuario { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<TabAgenda>(entity =>
            {
                entity.HasKey(e => new { e.SiCodEvento, e.TiCodAgenda })
                    .HasName("PK_TABAGENDA");

                entity.Property(e => e.SiCodEvento).HasColumnName("siCodEvento");

                entity.Property(e => e.TiCodAgenda).HasColumnName("tiCodAgenda");

                entity.Property(e => e.BEstActivo).HasColumnName("bEstActivo");

                entity.Property(e => e.CNomTer)
                    .HasColumnName("cNomTer")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CNomTerCreacion)
                    .IsRequired()
                    .HasColumnName("cNomTerCreacion")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SdFecAct)
                    .HasColumnName("sdFecAct")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.SdFecCreacion)
                    .HasColumnName("sdFecCreacion")
                    .HasColumnType("smalldatetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SdFecFinEvento)
                    .HasColumnName("sdFecFinEvento")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.SdFecIniEvento)
                    .HasColumnName("sdFecIniEvento")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.SiCodUsu).HasColumnName("siCodUsu");

                entity.Property(e => e.SiCodUsuCreacion).HasColumnName("siCodUsuCreacion");

                entity.HasOne(d => d.SiCodEventoNavigation)
                    .WithMany(p => p.TabAgenda)
                    .HasForeignKey(d => d.SiCodEvento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TABEVENTO_TABAGENDA");
            });

            modelBuilder.Entity<TabBeneficio>(entity =>
            {
                entity.HasKey(e => e.SiCodBeneficio)
                    .HasName("PK_TABBENEFICIO");

                entity.Property(e => e.SiCodBeneficio)
                    .HasColumnName("siCodBeneficio")
                    .ValueGeneratedNever();

                entity.Property(e => e.BEstActivo).HasColumnName("bEstActivo");

                entity.Property(e => e.CNomTer)
                    .HasColumnName("cNomTer")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CNomTerCreacion)
                    .IsRequired()
                    .HasColumnName("cNomTerCreacion")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SdFecAct)
                    .HasColumnName("sdFecAct")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.SdFecCreacion)
                    .HasColumnName("sdFecCreacion")
                    .HasColumnType("smalldatetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SdFecVigFin)
                    .HasColumnName("sdFecVigFin")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.SdFecVigInicio)
                    .HasColumnName("sdFecVigInicio")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.SiCodCatBeneficio).HasColumnName("siCodCatBeneficio");

                entity.Property(e => e.SiCodInstitucion).HasColumnName("siCodInstitucion");

                entity.Property(e => e.SiCodUsu).HasColumnName("siCodUsu");

                entity.Property(e => e.SiCodUsuCreacion).HasColumnName("siCodUsuCreacion");

                entity.Property(e => e.SiNumUsoPermitido).HasColumnName("siNumUsoPermitido");

                entity.Property(e => e.TiCodPeriodo).HasColumnName("tiCodPeriodo");

                entity.Property(e => e.TiNumPrioridad).HasColumnName("tiNumPrioridad");

                entity.Property(e => e.VDetBeneficio)
                    .IsRequired()
                    .HasColumnName("vDetBeneficio")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.VImgBeneficio)
                    .IsRequired()
                    .HasColumnName("vImgBeneficio")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.VNomBeneficio)
                    .IsRequired()
                    .HasColumnName("vNomBeneficio")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.VNomProAlmacenado)
                    .IsRequired()
                    .HasColumnName("vNomProAlmacenado")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.SiCodCatBeneficioNavigation)
                    .WithMany(p => p.TabBeneficio)
                    .HasForeignKey(d => d.SiCodCatBeneficio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TABCATBENEFICIO_TABBENEFICIO");

                entity.HasOne(d => d.SiCodInstitucionNavigation)
                    .WithMany(p => p.TabBeneficio)
                    .HasForeignKey(d => d.SiCodInstitucion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TABINSTITUCION_TABBENEFICIO");

                entity.HasOne(d => d.TiCodPeriodoNavigation)
                    .WithMany(p => p.TabBeneficio)
                    .HasForeignKey(d => d.TiCodPeriodo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TABPERIODO_TABBENEFICIO");
            });

            modelBuilder.Entity<TabBusquedaH>(entity =>
            {
                entity.HasKey(e => e.ICodBusquedaH)
                    .HasName("PK_TABBUSQUEDAH");

                entity.Property(e => e.ICodBusquedaH)
                    .HasColumnName("iCodBusquedaH")
                    .ValueGeneratedNever();

                entity.Property(e => e.CNumDocContribuyente)
                    .IsRequired()
                    .HasColumnName("cNumDocContribuyente")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.SdFecBusquedaH)
                    .HasColumnName("sdFecBusquedaH")
                    .HasColumnType("smalldatetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TiTipDocContribuyente).HasColumnName("tiTipDocContribuyente");
            });

            modelBuilder.Entity<TabCatBeneficio>(entity =>
            {
                entity.HasKey(e => e.SiCodCatBeneficio)
                    .HasName("PK_TABCATBENEFICIO");

                entity.Property(e => e.SiCodCatBeneficio).HasColumnName("siCodCatBeneficio");

                entity.Property(e => e.BEstActivo).HasColumnName("bEstActivo");

                entity.Property(e => e.CNomTer)
                    .HasColumnName("cNomTer")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CNomTerCreacion)
                    .IsRequired()
                    .HasColumnName("cNomTerCreacion")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SdFecAct)
                    .HasColumnName("sdFecAct")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.SdFecCreacion)
                    .HasColumnName("sdFecCreacion")
                    .HasColumnType("smalldatetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SiCodUsu).HasColumnName("siCodUsu");

                entity.Property(e => e.SiCodUsuCreacion).HasColumnName("siCodUsuCreacion");

                entity.Property(e => e.VNomCatBeneficio)
                    .IsRequired()
                    .HasColumnName("vNomCatBeneficio")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TabContribuyente>(entity =>
            {
                entity.HasKey(e => e.ICodContribuyente)
                    .HasName("PK_TABCONTRIBUYENTE");

                entity.Property(e => e.ICodContribuyente)
                    .HasColumnName("iCodContribuyente")
                    .ValueGeneratedNever();

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.Property(e => e.CNomTer)
                    .HasColumnName("cNomTer")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CNomTerCreacion)
                    .IsRequired()
                    .HasColumnName("cNomTerCreacion")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CNumDocContribuyente)
                    .IsRequired()
                    .HasColumnName("cNumDocContribuyente")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.SdFecAct)
                    .HasColumnName("sdFecAct")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.SdFecCarContribuyente)
                    .HasColumnName("sdFecCarContribuyente")
                    .HasColumnType("smalldatetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SdFecCreacion)
                    .HasColumnName("sdFecCreacion")
                    .HasColumnType("smalldatetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SdFecFinVigencia)
                    .HasColumnName("sdFecFinVigencia")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.SdFecIniVigencia)
                    .HasColumnName("sdFecIniVigencia")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.SiCodUsu).HasColumnName("siCodUsu");

                entity.Property(e => e.SiCodUsuCreacion).HasColumnName("siCodUsuCreacion");

                entity.Property(e => e.TiTipDocContribuyente).HasColumnName("tiTipDocContribuyente");

                entity.Property(e => e.VApeMatContribuyente)
                    .IsRequired()
                    .HasColumnName("vApeMatContribuyente")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.VApePatContribuyente)
                    .IsRequired()
                    .HasColumnName("vApePatContribuyente")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.VNomContribuyente)
                    .IsRequired()
                    .HasColumnName("vNomContribuyente")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TabDetBeneficio>(entity =>
            {
                entity.HasKey(e => new { e.SiCodBeneficio, e.TiCodDetBeneficio })
                    .HasName("PK_TABDETBENEFICIO");

                entity.Property(e => e.SiCodBeneficio).HasColumnName("siCodBeneficio");

                entity.Property(e => e.TiCodDetBeneficio).HasColumnName("tiCodDetBeneficio");

                entity.Property(e => e.BEstActivo).HasColumnName("bEstActivo");

                entity.Property(e => e.CNomTer)
                    .HasColumnName("cNomTer")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CNomTerCreacion)
                    .IsRequired()
                    .HasColumnName("cNomTerCreacion")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SdFecAct)
                    .HasColumnName("sdFecAct")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.SdFecCreacion)
                    .HasColumnName("sdFecCreacion")
                    .HasColumnType("smalldatetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SiCodUsu).HasColumnName("siCodUsu");

                entity.Property(e => e.SiCodUsuCreacion).HasColumnName("siCodUsuCreacion");

                entity.Property(e => e.VDesDetBeneficio)
                    .IsRequired()
                    .HasColumnName("vDesDetBeneficio")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.SiCodBeneficioNavigation)
                    .WithMany(p => p.TabDetBeneficio)
                    .HasForeignKey(d => d.SiCodBeneficio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TABBENEFICIO_TABDETBENEFICIO");
            });

            modelBuilder.Entity<TabEvento>(entity =>
            {
                entity.HasKey(e => e.SiCodEvento)
                    .HasName("PK_TABEVENTO");

                entity.Property(e => e.SiCodEvento)
                    .HasColumnName("siCodEvento")
                    .ValueGeneratedNever();

                entity.Property(e => e.BEstActivo).HasColumnName("bEstActivo");

                entity.Property(e => e.CNomTer)
                    .HasColumnName("cNomTer")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CNomTerCreacion)
                    .IsRequired()
                    .HasColumnName("cNomTerCreacion")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SdFecAct)
                    .HasColumnName("sdFecAct")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.SdFecCreacion)
                    .HasColumnName("sdFecCreacion")
                    .HasColumnType("smalldatetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SiCodInstitucion).HasColumnName("siCodInstitucion");

                entity.Property(e => e.SiCodUsu).HasColumnName("siCodUsu");

                entity.Property(e => e.SiCodUsuCreacion).HasColumnName("siCodUsuCreacion");

                entity.Property(e => e.VDetEvento)
                    .IsRequired()
                    .HasColumnName("vDetEvento")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.VImgEvento)
                    .IsRequired()
                    .HasColumnName("vImgEvento")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.VNomEvento)
                    .IsRequired()
                    .HasColumnName("vNomEvento")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.VUrlEvento)
                    .IsRequired()
                    .HasColumnName("vUrlEvento")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.SiCodInstitucionNavigation)
                    .WithMany(p => p.TabEvento)
                    .HasForeignKey(d => d.SiCodInstitucion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TABINSTITUCION_TABEVENTO");
            });

            modelBuilder.Entity<TabInstitucion>(entity =>
            {
                entity.HasKey(e => e.SiCodInstitucion)
                    .HasName("PK_TABINSTITUCION");

                entity.Property(e => e.SiCodInstitucion)
                    .HasColumnName("siCodInstitucion")
                    .ValueGeneratedNever();

                entity.Property(e => e.BEstActivo).HasColumnName("bEstActivo");

                entity.Property(e => e.CNomTer)
                    .HasColumnName("cNomTer")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CNomTerCreacion)
                    .IsRequired()
                    .HasColumnName("cNomTerCreacion")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SdFecAct)
                    .HasColumnName("sdFecAct")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.SdFecCreacion)
                    .HasColumnName("sdFecCreacion")
                    .HasColumnType("smalldatetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SiCodUsu).HasColumnName("siCodUsu");

                entity.Property(e => e.SiCodUsuCreacion).HasColumnName("siCodUsuCreacion");

                entity.Property(e => e.TiCodCatInstitucion).HasColumnName("tiCodCatInstitucion");

                entity.Property(e => e.TiNumPrioridad).HasColumnName("tiNumPrioridad");

                entity.Property(e => e.VImgLogo)
                    .IsRequired()
                    .HasColumnName("vImgLogo")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.VNomInstitucion)
                    .IsRequired()
                    .HasColumnName("vNomInstitucion")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TabMovBeneficio>(entity =>
            {
                entity.HasKey(e => new { e.ICodContribuyente, e.SiCodBeneficio, e.SdFecUtilizado })
                    .HasName("PK_TABMOVBENEFICIO");

                entity.Property(e => e.ICodContribuyente).HasColumnName("iCodContribuyente");

                entity.Property(e => e.SiCodBeneficio).HasColumnName("siCodBeneficio");

                entity.Property(e => e.SdFecUtilizado)
                    .HasColumnName("sdFecUtilizado")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.BEstActivo).HasColumnName("bEstActivo");

                entity.Property(e => e.CNomTer)
                    .HasColumnName("cNomTer")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CNomTerCreacion)
                    .IsRequired()
                    .HasColumnName("cNomTerCreacion")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SdFecAct)
                    .HasColumnName("sdFecAct")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.SdFecCreacion)
                    .HasColumnName("sdFecCreacion")
                    .HasColumnType("smalldatetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SiCodUsu).HasColumnName("siCodUsu");

                entity.Property(e => e.SiCodUsuCreacion).HasColumnName("siCodUsuCreacion");

                entity.HasOne(d => d.ICodContribuyenteNavigation)
                    .WithMany(p => p.TabMovBeneficio)
                    .HasForeignKey(d => d.ICodContribuyente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TABCONTRIBUYENTE_TABMOVBENEFICIO");

                entity.HasOne(d => d.SiCodBeneficioNavigation)
                    .WithMany(p => p.TabMovBeneficio)
                    .HasForeignKey(d => d.SiCodBeneficio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TABBENEFICIO_TABMOVBENEFICIO");
            });

            modelBuilder.Entity<TabPeriodo>(entity =>
            {
                entity.HasKey(e => e.TiCodPeriodo)
                    .HasName("PK_TABPERIODO");

                entity.Property(e => e.TiCodPeriodo).HasColumnName("tiCodPeriodo");

                entity.Property(e => e.BEstActivo).HasColumnName("bEstActivo");

                entity.Property(e => e.CNomTer)
                    .HasColumnName("cNomTer")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CNomTerCreacion)
                    .IsRequired()
                    .HasColumnName("cNomTerCreacion")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SdFecAct)
                    .HasColumnName("sdFecAct")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.SdFecCreacion)
                    .HasColumnName("sdFecCreacion")
                    .HasColumnType("smalldatetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SiCodUsu).HasColumnName("siCodUsu");

                entity.Property(e => e.SiCodUsuCreacion).HasColumnName("siCodUsuCreacion");

                entity.Property(e => e.VDesPeriodo)
                    .IsRequired()
                    .HasColumnName("vDesPeriodo")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TabUsuario>(entity =>
            {
                entity.HasKey(e => e.SiCodUsuario)
                    .HasName("PK_TABUSUARIO");

                entity.Property(e => e.SiCodUsuario)
                    .HasColumnName("siCodUsuario")
                    .ValueGeneratedNever();

                entity.Property(e => e.BEstActivo).HasColumnName("bEstActivo");

                entity.Property(e => e.CNomTer)
                    .HasColumnName("cNomTer")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CNomTerCreacion)
                    .IsRequired()
                    .HasColumnName("cNomTerCreacion")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CNumDocContribuyente)
                    .IsRequired()
                    .HasColumnName("cNumDocContribuyente")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.ContrasenaHash)
                    .IsRequired()
                    .HasColumnName("contrasenaHash");

                entity.Property(e => e.ContrasenaSalt)
                    .IsRequired()
                    .HasColumnName("contrasenaSalt");

                entity.Property(e => e.SdFecAct)
                    .HasColumnName("sdFecAct")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.SdFecCreacion)
                    .HasColumnName("sdFecCreacion")
                    .HasColumnType("smalldatetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SiCodInstitucion).HasColumnName("siCodInstitucion");

                entity.Property(e => e.SiCodUsu).HasColumnName("siCodUsu");

                entity.Property(e => e.SiCodUsuCreacion).HasColumnName("siCodUsuCreacion");

                entity.Property(e => e.TiTipDocUsuario).HasColumnName("tiTipDocUsuario");

                entity.Property(e => e.VIdUsuario)
                    .IsRequired()
                    .HasColumnName("vIdUsuario")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.SiCodInstitucionNavigation)
                    .WithMany(p => p.TabUsuario)
                    .HasForeignKey(d => d.SiCodInstitucion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TABINSTITUCION_TABUSUARIO");
            });
        }
    }
}
