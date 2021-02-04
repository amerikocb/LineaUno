using System;
using LineaUno.App.Servicios.Modelo.SMC.v1.Response;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace LineaUno.App.Servicios.Modelo.SMC.v1.Model
{
    public partial class BDLINEAUNOContext : DbContext
    {
        public BDLINEAUNOContext()
        {
        }

        public BDLINEAUNOContext(DbContextOptions<BDLINEAUNOContext> options)
            : base(options)
        {
        }

        public virtual DbSet<McdetCargaForDos> McdetCargaForDos { get; set; }
        public virtual DbSet<McdetPt> McdetPt { get; set; }
        public virtual DbSet<McmaeAdjPt> McmaeAdjPt { get; set; }
        public virtual DbSet<McmaeCargaForDos> McmaeCargaForDos { get; set; }
        public virtual DbSet<McmaePt> McmaePt { get; set; }
        public virtual DbSet<McmaeTraPt> McmaeTraPt { get; set; }
        public virtual DbSet<McmaeTrabajador> McmaeTrabajador { get; set; }
        public virtual DbSet<McmovEstPt> McmovEstPt { get; set; }
        public virtual DbSet<MctabParSeccion> MctabParSeccion { get; set; }
        public virtual DbSet<MctabParValor> MctabParValor { get; set; }
        public virtual DbSet<MctabParametro> MctabParametro { get; set; }
        public virtual DbSet<McmovBanPt> McmovBanPt { get; set; }
        public virtual DbSet<McmovIncPT> McmovIncPt { get; set; }
        public virtual DbSet<McmaeCargaTraForDos> McmaeCargaTraForDos { get; set; }

        //        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //        {
        //            if (!optionsBuilder.IsConfigured)
        //            {
        //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
        //                optionsBuilder.UseSqlServer("Server=(local);Database=BDLINEAUNO;Trusted_Connection=True;");
        //            }
        //        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Query<PedidoTrabajoResponse>();
            modelBuilder.Query<PedidoTrabajoBResponse>();
            modelBuilder.Query<ParametroValorResponse>();
            modelBuilder.Query<TablaValidarResponse>();
            modelBuilder.Query<RecursoResponse>();
            modelBuilder.Query<NotificacionBanResponse>();
            modelBuilder.Query<MotivosIncResponse>();
            modelBuilder.Query<MCTrabajadorResponse>();
            modelBuilder.Query<ResStringResponse>();
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<McdetCargaForDos>(entity =>
            {
                entity.HasKey(e => new { e.INumCarga, e.INumDetCarga })
                    .HasName("PK_MCDETCARGAFORDOS");

                entity.ToTable("MCDetCargaForDos");

                entity.Property(e => e.INumCarga).HasColumnName("iNumCarga");

                entity.Property(e => e.INumDetCarga).HasColumnName("iNumDetCarga");

                entity.Property(e => e.CNomTerCreacion)
                    .HasColumnName("cNomTerCreacion")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CNomTerModificacion)
                    .HasColumnName("cNomTerModificacion")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SdFecCreacion)
                    .HasColumnName("sdFecCreacion")
                    .HasColumnType("smalldatetime")
                    .HasDefaultValueSql("(getdate())"); ;

                entity.Property(e => e.SdFecModificacion)
                    .HasColumnName("sdFecModificacion")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.VAreResponsable)
                    .HasColumnName("vAreResponsable")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.VCelSupResponsable)
                    .HasColumnName("vCelSupResponsable")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.VCelTercero)
                    .HasColumnName("vCelTercero")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.VCelTeresponsable)
                    .HasColumnName("vCelTEResponsable")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.VCodUsuCreacion)
                    .HasColumnName("vCodUsuCreacion")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.VCodUsuModificacion)
                    .HasColumnName("vCodUsuModificacion")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.VDesActividad)
                    .HasColumnName("vDesActividad")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.VHorFin)
                    .HasColumnName("vHorFin")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.VHorInicio)
                    .HasColumnName("vHorInicio")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.VNumPt)
                    .IsRequired()
                    .HasColumnName("vNumPT")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.VParFecha)
                    .HasColumnName("vParFecha")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.VPerIntervencion)
                    .HasColumnName("vPerIntervencion")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.VPrioridad)
                    .HasColumnName("vPrioridad")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.VRazSocial)
                    .HasColumnName("vRazSocial")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.VRecMedios)
                    .HasColumnName("vRecMedios")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.VResTercero)
                    .HasColumnName("vResTercero")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.VRuc)
                    .HasColumnName("vRuc")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.VSecLinea)
                    .HasColumnName("vSecLinea")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.VSupResConcar)
                    .HasColumnName("vSupResConcar")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.VTeresConcar)
                    .HasColumnName("vTEResConcar")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.VTipActividad)
                    .HasColumnName("vTipActividad")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.VZonEspecifica)
                    .HasColumnName("vZonEspecifica")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.VZona)
                    .HasColumnName("vZona")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.INumCargaNavigation)
                    .WithMany(p => p.McdetCargaForDos)
                    .HasForeignKey(d => d.INumCarga)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MCMAECAR_FK_MCDETCAR");
            });

            modelBuilder.Entity<McdetPt>(entity =>
            {
                entity.HasKey(e => new { e.INumIdPt, e.INumDetPt })
                    .HasName("PK_MCDETPT");

                entity.ToTable("MCDetPT");

                entity.Property(e => e.INumIdPt).HasColumnName("iNumIdPT");

                entity.Property(e => e.INumDetPt).HasColumnName("iNumDetPT");

                entity.Property(e => e.BEstRegistro).HasColumnName("bEstRegistro");

                entity.Property(e => e.BPerIntervencion).HasColumnName("bPerIntervencion");

                entity.Property(e => e.CHorFin)
                    .HasColumnName("cHorFin")
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.CHorInicio)
                    .HasColumnName("cHorInicio")
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.CNomTerCreacion)
                    .HasColumnName("cNomTerCreacion")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CNomTerModificacion)
                    .HasColumnName("cNomTerModificacion")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CRazSocial)
                    .HasColumnName("cRazSocial")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.CRuc)
                    .HasColumnName("cRUC")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.ICodAreResponsable).HasColumnName("iCodAreResponsable");

                entity.Property(e => e.ICodPrioridad).HasColumnName("iCodPrioridad");

                entity.Property(e => e.ICodTipActividad).HasColumnName("iCodTipActividad");

                entity.Property(e => e.ICodZona).HasColumnName("iCodZona");

                entity.Property(e => e.SdFecCreacion)
                    .HasColumnName("sdFecCreacion")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.SdFecModificacion)
                    .HasColumnName("sdFecModificacion")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.SdFecProgramada)
                    .HasColumnName("sdFecProgramada")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.VCelResTercero)
                    .HasColumnName("vCelResTercero")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.VCodUsuCreacion)
                    .HasColumnName("vCodUsuCreacion")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.VCodUsuModificacion)
                    .HasColumnName("vCodUsuModificacion")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.VDesActividad)
                    .HasColumnName("vDesActividad")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.VRecMedios)
                    .HasColumnName("vRecMedios")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.VResTercero)
                    .HasColumnName("vResTercero")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.VSecLinea)
                    .HasColumnName("vSecLinea")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.VZonEspecifica)
                    .HasColumnName("vZonEspecifica")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.HasOne(d => d.INumIdPtNavigation)
                    .WithMany(p => p.McdetPt)
                    .HasForeignKey(d => d.INumIdPt)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MCDETPT_FK_MCMAEPT");
            });

            modelBuilder.Entity<McmaeAdjPt>(entity =>
            {
                entity.HasKey(e => new { e.INumIdPt, e.INumDetPt, e.INumDetAdjT })
                    .HasName("PK_MCMAEADJPT");

                entity.ToTable("MCMaeAdjPT");

                entity.Property(e => e.INumIdPt).HasColumnName("iNumIdPT");

                entity.Property(e => e.INumDetPt).HasColumnName("iNumDetPT");

                entity.Property(e => e.INumDetAdjT).HasColumnName("iNumDetAdjT");

                entity.Property(e => e.ITipAdjunto).HasColumnName("iTipAdjunto");

                entity.Property(e => e.BEstRegistro).HasColumnName("bEstRegistro");

                entity.Property(e => e.CNomTerCreacion)
                    .HasColumnName("cNomTerCreacion")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CNomTerModificacion)
                    .HasColumnName("cNomTerModificacion")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SdFecCreacion)
                    .HasColumnName("sdFecCreacion")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.SdFecModificacion)
                    .HasColumnName("sdFecModificacion")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.VCodUsuCreacion)
                    .HasColumnName("vCodUsuCreacion")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.VCodUsuModificacion)
                    .HasColumnName("vCodUsuModificacion")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.VRutaAdjunto)
                    .HasColumnName("vRutaAdjunto")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.INum)
                    .WithMany(p => p.McmaeAdjPt)
                    .HasForeignKey(d => new { d.INumIdPt, d.INumDetPt })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MCMAEADJPT_FK_MCDETPT");
            });

            modelBuilder.Entity<McmaeCargaForDos>(entity =>
            {
                entity.HasKey(e => e.INumCarga)
                    .HasName("PK_MCMAECARGAFORDOS");

                entity.ToTable("MCMaeCargaForDos");

                entity.Property(e => e.INumCarga).HasColumnName("iNumCarga");

                entity.Property(e => e.BEstRegistro).HasColumnName("bEstRegistro");

                entity.Property(e => e.CEstado)
                    .HasColumnName("cEstado")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('A')");

                entity.Property(e => e.CNomTerCreacion)
                    .HasColumnName("cNomTerCreacion")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CNomTerModificacion)
                    .HasColumnName("cNomTerModificacion")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CTipCarga)
                    .HasColumnName("cTipCarga")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('M')");

                entity.Property(e => e.SdFecCreacion)
                    .HasColumnName("sdFecCreacion")
                    .HasColumnType("smalldatetime")
                     .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SdFecModificacion)
                    .HasColumnName("sdFecModificacion")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.VCodUsuCreacion)
                    .HasColumnName("vCodUsuCreacion")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.VCodUsuModificacion)
                    .HasColumnName("vCodUsuModificacion")
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<McmaePt>(entity =>
            {
                entity.HasKey(e => e.INumIdPt)
                    .HasName("PK_MCMAEPT");

                entity.ToTable("MCMaePT");

                entity.Property(e => e.INumIdPt).HasColumnName("iNumIdPT");

                entity.Property(e => e.BEstRegistro).HasColumnName("bEstRegistro");

                entity.Property(e => e.CEstPt)
                    .HasColumnName("cEstPT")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.CNomTerCreacion)
                    .HasColumnName("cNomTerCreacion")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CNomTerModificacion)
                    .HasColumnName("cNomTerModificacion")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SdFecCreacion)
                    .HasColumnName("sdFecCreacion")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.SdFecModificacion)
                    .HasColumnName("sdFecModificacion")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.VCodUsuCreacion)
                    .HasColumnName("vCodUsuCreacion")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.VCodUsuModificacion)
                    .HasColumnName("vCodUsuModificacion")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.VNumPt)
                    .HasColumnName("vNumPT")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<McmaeTraPt>(entity =>
            {
                entity.HasKey(e => new { e.INumIdPt, e.INumDetPt, e.ICodTrabajador })
                    .HasName("PK_MCMaeTraPT_1");

                entity.ToTable("MCMaeTraPT");

                entity.Property(e => e.INumIdPt).HasColumnName("iNumIdPT");

                entity.Property(e => e.INumDetPt).HasColumnName("iNumDetPT");

                entity.Property(e => e.ICodTrabajador).HasColumnName("iCodTrabajador");

                entity.Property(e => e.BEstRegistro).HasColumnName("bEstRegistro");

                entity.Property(e => e.CNomTerCreacion)
                    .HasColumnName("cNomTerCreacion")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CNomTerModificacion)
                    .HasColumnName("cNomTerModificacion")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SdFecCreacion)
                    .HasColumnName("sdFecCreacion")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.SdFecModificacion)
                    .HasColumnName("sdFecModificacion")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.VCodUsuCreacion)
                    .HasColumnName("vCodUsuCreacion")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.VCodUsuModificacion)
                    .HasColumnName("vCodUsuModificacion")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.HasOne(d => d.INum)
                    .WithMany(p => p.McmaeTraPt)
                    .HasForeignKey(d => new { d.INumIdPt, d.INumDetPt })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MCMAETRAPT_FK_MCDETPT");
            });

            modelBuilder.Entity<McmaeTrabajador>(entity =>
            {
                entity.HasKey(e => e.ICodTrabajador)
                    .HasName("PK_MCMaeTrabajador_1");

                entity.ToTable("MCMaeTrabajador");

                entity.Property(e => e.ICodTrabajador).HasColumnName("iCodTrabajador");

                entity.Property(e => e.BEstRegistro).HasColumnName("bEstRegistro");

                entity.Property(e => e.CNomTerCreacion)
                    .HasColumnName("cNomTerCreacion")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CNomTerModificacion)
                    .HasColumnName("cNomTerModificacion")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CTipTrabajador)
                    .IsRequired()
                    .HasColumnName("cTipTrabajador")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.SdFecCreacion)
                    .HasColumnName("sdFecCreacion")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.SdFecModificacion)
                    .HasColumnName("sdFecModificacion")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.VCodUsuCreacion)
                    .HasColumnName("vCodUsuCreacion")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.VCodUsuModificacion)
                    .HasColumnName("vCodUsuModificacion")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.VCodigo)
                    .HasColumnName("vCodigo")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.VCorTrabajador)
                    .HasColumnName("vCorTrabajador")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.VNomTrabajador)
                    .HasColumnName("vNomTrabajador")
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<McmovEstPt>(entity =>
            {
                entity.HasKey(e => new { e.INumIdPt, e.INumDetPt, e.INumDetEstPt })
                    .HasName("PK_MCMOVESTPT");

                entity.ToTable("MCMovEstPT");

                entity.Property(e => e.INumIdPt).HasColumnName("iNumIdPT");

                entity.Property(e => e.INumDetPt).HasColumnName("iNumDetPT");

                entity.Property(e => e.INumDetEstPt).HasColumnName("iNumDetEstPT");

                entity.Property(e => e.BEstRegistro).HasColumnName("bEstRegistro");

                entity.Property(e => e.CEstPt)
                    .HasColumnName("cEstPT")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.CNomTerCreacion)
                    .HasColumnName("cNomTerCreacion")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CNomTerModificacion)
                    .HasColumnName("cNomTerModificacion")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NDurPt)
                    .HasColumnName("nDurPT")
                    .HasColumnType("numeric(9, 4)");

                entity.Property(e => e.SdFecCreacion)
                    .HasColumnName("sdFecCreacion")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.SdFecFinEstado)
                    .HasColumnName("sdFecFinEstado")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.SdFecIniEstado)
                    .HasColumnName("sdFecIniEstado")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.SdFecModificacion)
                    .HasColumnName("sdFecModificacion")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.VCodUsuCreacion)
                    .HasColumnName("vCodUsuCreacion")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.VCodUsuModificacion)
                    .HasColumnName("vCodUsuModificacion")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.VObsPt)
                    .HasColumnName("vObsPT")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.HasOne(d => d.INum)
                    .WithMany(p => p.McmovEstPt)
                    .HasForeignKey(d => new { d.INumIdPt, d.INumDetPt })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MCMOVESTPT_FK_MCDETPT");
            });

            modelBuilder.Entity<MctabParSeccion>(entity =>
            {
                entity.HasKey(e => new { e.ICodParametro, e.ICodParSeccion })
                    .HasName("PK_MCTABPARSECCION");

                entity.ToTable("MCTabParSeccion");

                entity.Property(e => e.ICodParametro).HasColumnName("iCodParametro");

                entity.Property(e => e.ICodParSeccion).HasColumnName("iCodParSeccion");

                entity.Property(e => e.BEstRegistro).HasColumnName("bEstRegistro");

                entity.Property(e => e.CCodTipDato)
                    .HasColumnName("cCodTipDato")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.CNomTerCreacion)
                    .HasColumnName("cNomTerCreacion")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CNomTerModificacion)
                    .HasColumnName("cNomTerModificacion")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SdFecCreacion)
                    .HasColumnName("sdFecCreacion")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.SdFecModificacion)
                    .HasColumnName("sdFecModificacion")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.VCodUsuCreacion)
                    .HasColumnName("vCodUsuCreacion")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.VCodUsuModificacion)
                    .HasColumnName("vCodUsuModificacion")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.VNomParSeccion)
                    .HasColumnName("vNomParSeccion")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.ICodParametroNavigation)
                    .WithMany(p => p.MctabParSeccion)
                    .HasForeignKey(d => d.ICodParametro)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MCTABPARAMETRO_FK_MCTABPARSECCION");
            });

            modelBuilder.Entity<MctabParValor>(entity =>
            {
                entity.HasKey(e => new { e.ICodParametro, e.ICodParSeccion, e.ICodParValor })
                    .HasName("PK_MCTABPARVALOR");

                entity.ToTable("MCTabParValor");

                entity.Property(e => e.ICodParametro).HasColumnName("iCodParametro");

                entity.Property(e => e.ICodParSeccion).HasColumnName("iCodParSeccion");

                entity.Property(e => e.ICodParValor).HasColumnName("iCodParValor");

                entity.Property(e => e.BEstRegistro).HasColumnName("bEstRegistro");

                entity.Property(e => e.CNomTerCreacion)
                    .HasColumnName("cNomTerCreacion")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CNomTerModificacion)
                    .HasColumnName("cNomTerModificacion")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SdFecCreacion)
                    .HasColumnName("sdFecCreacion")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.SdFecModificacion)
                    .HasColumnName("sdFecModificacion")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.VCodUsuCreacion)
                    .HasColumnName("vCodUsuCreacion")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.VCodUsuModificacion)
                    .HasColumnName("vCodUsuModificacion")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.VNomParValor)
                    .HasColumnName("vNomParValor")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.ICodPar)
                    .WithMany(p => p.MctabParValor)
                    .HasForeignKey(d => new { d.ICodParametro, d.ICodParSeccion })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MCTABPARSECCION_FK_MCTABPARVALOR");
            });

            modelBuilder.Entity<MctabParametro>(entity =>
            {
                entity.HasKey(e => e.ICodParametro)
                    .HasName("PK_MCTABPARAMETRO");

                entity.ToTable("MCTabParametro");

                entity.Property(e => e.ICodParametro)
                    .HasColumnName("iCodParametro")
                    .ValueGeneratedNever();

                entity.Property(e => e.BEstRegistro).HasColumnName("bEstRegistro");

                entity.Property(e => e.CNomTerCreacion)
                    .HasColumnName("cNomTerCreacion")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CNomTerModificacion)
                    .HasColumnName("cNomTerModificacion")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SdFecCreacion)
                    .HasColumnName("sdFecCreacion")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.SdFecModificacion)
                    .HasColumnName("sdFecModificacion")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.VCodUsuCreacion)
                    .HasColumnName("vCodUsuCreacion")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.VCodUsuModificacion)
                    .HasColumnName("vCodUsuModificacion")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.VDesParametro)
                    .HasColumnName("vDesParametro")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.VNomParametro)
                    .HasColumnName("vNomParametro")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<McmovBanPt>(entity =>
            {
                entity.HasKey(e => new { e.INumIdPt, e.INumDetPt, e.INumDesBanPt })
                    .HasName("PK_MCMOVBANPT");

                entity.ToTable("MCMovBanPT");

                entity.Property(e => e.INumIdPt).HasColumnName("iNumIdPT");

                entity.Property(e => e.INumDetPt).HasColumnName("iNumDetPT");

                entity.Property(e => e.INumDesBanPt).HasColumnName("iNumDesBanPT");

                entity.Property(e => e.CTipBandeja).HasColumnName("cTipBandeja");

                entity.Property(e => e.CEstBandeja).HasColumnName("cEstBandeja");

                entity.Property(e => e.vContenido).HasColumnName("vContenido");


                entity.Property(e => e.ICodTraResponsable).HasColumnName("iCodTraResponsable");

                entity.Property(e => e.BEstRegistro).HasColumnName("bEstRegistro");

                entity.Property(e => e.SdFecIngreso)
                    .HasColumnName("sdFecIngreso")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.SdFecFinalizacion)
                    .HasColumnName("sdFecFinalizacion")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.CNomTerCreacion)
                    .HasColumnName("cNomTerCreacion")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CNomTerModificacion)
                    .HasColumnName("cNomTerModificacion")
                    .HasMaxLength(20)
                    .IsUnicode(false);


                entity.Property(e => e.SdFecCreacion)
                    .HasColumnName("sdFecCreacion")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.SdFecModificacion)
                    .HasColumnName("sdFecModificacion")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.VCodUsuCreacion)
                    .HasColumnName("vCodUsuCreacion")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.VCodUsuModificacion)
                    .HasColumnName("vCodUsuModificacion")
                    .HasMaxLength(25)
                    .IsUnicode(false);


                //entity.HasOne(d => d.INum)
                //    .WithMany(p => p.McmovBanPt)
                //    .HasForeignKey(d => new { d.INumIdPt, d.INumDetPt })
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_MCMOVESTPT_FK_MCDETPT");
            });

            modelBuilder.Entity<McmovIncPT>(entity =>
            {
                entity.HasKey(e => new { e.INumIdPt, e.INumDetPt, e.INumDetIncPt })
                    .HasName("PK_MCMOVINCPTT");

                entity.ToTable("McmovIncPT");

                entity.Property(e => e.INumIdPt).HasColumnName("iNumIdPT");

                entity.Property(e => e.INumDetPt).HasColumnName("iNumDetPT");

                entity.Property(e => e.INumDetIncPt).HasColumnName("iNumDetIncPT");

                entity.Property(e => e.ICodCatInconveniente).HasColumnName("iCodCatInconveniente");

                entity.Property(e => e.ICodMotInconveniente).HasColumnName("iCodMotInconveniente");

                entity.Property(e => e.vDesMotInconveniente).HasColumnName("vDesMotInconveniente");

                entity.Property(e => e.BEstRegistro).HasColumnName("bEstRegistro");

                entity.Property(e => e.CNomTerCreacion)
                    .HasColumnName("cNomTerCreacion")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CNomTerModificacion)
                    .HasColumnName("cNomTerModificacion")
                    .HasMaxLength(20)
                    .IsUnicode(false);


                entity.Property(e => e.SdFecCreacion)
                    .HasColumnName("sdFecCreacion")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.SdFecModificacion)
                    .HasColumnName("sdFecModificacion")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.VCodUsuCreacion)
                    .HasColumnName("vCodUsuCreacion")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.VCodUsuModificacion)
                    .HasColumnName("vCodUsuModificacion")
                    .HasMaxLength(25)
                    .IsUnicode(false);


                //entity.HasOne(d => d.INum)
                //    .WithMany(p => p.McmovBanPt)
                //    .HasForeignKey(d => new { d.INumIdPt, d.INumDetPt })
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_MCMOVESTPT_FK_MCDETPT");
            });

            modelBuilder.Entity<McmaeCargaTraForDos>(entity =>
            {
                entity.HasKey(e => new { e.INumCarga, e.INumDetCarga, e.ICodTrabjador })
                    .HasName("PK_MCMaeCargaTraForDos_1");

                entity.ToTable("MCMaeCargaTraForDos");

                entity.Property(e => e.INumCarga).HasColumnName("iNumCarga");

                entity.Property(e => e.INumDetCarga).HasColumnName("iNumDetCarga");

                entity.Property(e => e.ICodTrabjador).HasColumnName("iCodTrabajador");

                entity.Property(e => e.BEstRegistro).HasColumnName("bEstRegistro");

                entity.Property(e => e.CNomTerCreacion)
                    .HasColumnName("cNomTerCreacion")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CNomTerModificacion)
                    .HasColumnName("cNomTerModificacion")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SdFecCreacion)
                    .HasColumnName("sdFecCreacion")
                    .HasColumnType("smalldatetime")
                    .HasDefaultValueSql("(getdate())"); ;

                entity.Property(e => e.SdFecModificacion)
                    .HasColumnName("sdFecModificacion")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.VCodUsuCreacion)
                    .HasColumnName("vCodUsuCreacion")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.VCodUsuModificacion)
                    .HasColumnName("vCodUsuModificacion")
                    .HasMaxLength(25)
                    .IsUnicode(false);

            });
        }
    }
}
