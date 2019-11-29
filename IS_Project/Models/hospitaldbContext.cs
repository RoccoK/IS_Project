using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace IS_Project.Models
{
    public partial class hospitaldbContext : DbContext
    {
        public hospitaldbContext()
        {
        }

        public hospitaldbContext(DbContextOptions<hospitaldbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Administratorius> Administratorius { get; set; }
        public virtual DbSet<Adresas> Adresas { get; set; }
        public virtual DbSet<Alergija> Alergija { get; set; }
        public virtual DbSet<AlergijaPacientas> AlergijaPacientas { get; set; }
        public virtual DbSet<Daktaras> Daktaras { get; set; }
        public virtual DbSet<DaktarasKabinetas> DaktarasKabinetas { get; set; }
        public virtual DbSet<Kabinetas> Kabinetas { get; set; }
        public virtual DbSet<KomplikacijosAlergijaVaistas> KomplikacijosAlergijaVaistas { get; set; }
        public virtual DbSet<Liga> Liga { get; set; }
        public virtual DbSet<LigonioVisitas> LigonioVisitas { get; set; }
        public virtual DbSet<NesuderinamasVaistas> NesuderinamasVaistas { get; set; }
        public virtual DbSet<Pacientas> Pacientas { get; set; }
        public virtual DbSet<Palata> Palata { get; set; }
        public virtual DbSet<Receptas> Receptas { get; set; }
        public virtual DbSet<Registracija> Registracija { get; set; }
        public virtual DbSet<UzimtumoTvarkarastis> UzimtumoTvarkarastis { get; set; }
        public virtual DbSet<Vaistas> Vaistas { get; set; }
        public virtual DbSet<VaistoVartojimas> VaistoVartojimas { get; set; }
        public virtual DbSet<Vartotojas> Vartotojas { get; set; }
        public virtual DbSet<Zinute> Zinute { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("Server=localhost;User Id=root;Password=;Database=hospitaldb;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Administratorius>(entity =>
            {
                entity.ToTable("administratorius");

                entity.Property(e => e.AdministratoriusId)
                    .HasColumnName("administratorius_id")
                    .HasColumnType("int(11)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.BaigtaDirbti)
                    .HasColumnName("baigta_dirbti")
                    .HasColumnType("datetime");

                entity.Property(e => e.Busena)
                    .HasColumnName("busena")
                    .HasColumnType("int(11)");

                entity.Property(e => e.PradetaDirbti)
                    .HasColumnName("pradeta_dirbti")
                    .HasColumnType("datetime");

                entity.Property(e => e.PrisijungimoAlias)
                    .IsRequired()
                    .HasColumnName("prisijungimo_alias")
                    .HasColumnType("varchar(100)");

                entity.HasOne(d => d.AdministratoriusNavigation)
                    .WithOne(p => p.Administratorius)
                    .HasForeignKey<Administratorius>(d => d.AdministratoriusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("administratorius_vartotojas_fk");
            });

            modelBuilder.Entity<Adresas>(entity =>
            {
                entity.ToTable("adresas");

                entity.Property(e => e.AdresasId)
                    .HasColumnName("adresas_id")
                    .HasColumnType("int(11)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Gatve)
                    .IsRequired()
                    .HasColumnName("gatve")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.Miestas)
                    .IsRequired()
                    .HasColumnName("miestas")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.NamoNr)
                    .HasColumnName("namo_nr")
                    .HasColumnType("int(11)");

                entity.Property(e => e.PastoKodas)
                    .HasColumnName("pasto_kodas")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.AdresasNavigation)
                    .WithOne(p => p.Adresas)
                    .HasForeignKey<Adresas>(d => d.AdresasId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("adresas_vartotojas_fk");
            });

            modelBuilder.Entity<Alergija>(entity =>
            {
                entity.ToTable("alergija");

                entity.Property(e => e.AlergijaId)
                    .HasColumnName("alergija_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Pavadinimas)
                    .IsRequired()
                    .HasColumnName("pavadinimas")
                    .HasColumnType("varchar(100)");
            });

            modelBuilder.Entity<AlergijaPacientas>(entity =>
            {
                entity.HasKey(e => new { e.FkAlergijaId, e.FkPacientasId })
                    .HasName("PRIMARY");

                entity.ToTable("alergija_pacientas");

                entity.HasIndex(e => e.FkPacientasId)
                    .HasName("alergija_pacientas_pacientas_fk");

                entity.Property(e => e.FkAlergijaId)
                    .HasColumnName("fk_alergija_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FkPacientasId)
                    .HasColumnName("fk_pacientas_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Busena)
                    .HasColumnName("busena")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UzfiksuotaData)
                    .HasColumnName("uzfiksuota_data")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.FkAlergija)
                    .WithMany(p => p.AlergijaPacientas)
                    .HasForeignKey(d => d.FkAlergijaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("alergija_pacientas_alergija_fk");

                entity.HasOne(d => d.FkPacientas)
                    .WithMany(p => p.AlergijaPacientas)
                    .HasForeignKey(d => d.FkPacientasId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("alergija_pacientas_pacientas_fk");
            });

            modelBuilder.Entity<Daktaras>(entity =>
            {
                entity.ToTable("daktaras");

                entity.Property(e => e.DaktarasId)
                    .HasColumnName("daktaras_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.BaigtaDirbti)
                    .HasColumnName("baigta_dirbti")
                    .HasColumnType("datetime");

                entity.Property(e => e.Busena)
                    .HasColumnName("busena")
                    .HasColumnType("int(11)");

                entity.Property(e => e.PradetaDirbti)
                    .HasColumnName("pradeta_dirbti")
                    .HasColumnType("datetime");

                entity.Property(e => e.Specializacija)
                    .HasColumnName("specializacija")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.DaktarasNavigation)
                    .WithOne(p => p.Daktaras)
                    .HasForeignKey<Daktaras>(d => d.DaktarasId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("daktaras_vartotojas_fk");
            });

            modelBuilder.Entity<DaktarasKabinetas>(entity =>
            {
                entity.HasKey(e => new { e.FkDaktarasId, e.FkKabinetasId })
                    .HasName("PRIMARY");

                entity.ToTable("daktaras_kabinetas");

                entity.HasIndex(e => e.FkKabinetasId)
                    .HasName("daktaras_kabinetas_kabinetas_fk");

                entity.Property(e => e.FkDaktarasId)
                    .HasColumnName("fk_daktaras_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FkKabinetasId)
                    .HasColumnName("fk_kabinetas_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.FkDaktaras)
                    .WithMany(p => p.DaktarasKabinetas)
                    .HasForeignKey(d => d.FkDaktarasId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("daktaras_kabinetas_daktaras_fk");

                entity.HasOne(d => d.FkKabinetas)
                    .WithMany(p => p.DaktarasKabinetas)
                    .HasForeignKey(d => d.FkKabinetasId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("daktaras_kabinetas_kabinetas_fk");
            });

            modelBuilder.Entity<Kabinetas>(entity =>
            {
                entity.ToTable("kabinetas");

                entity.Property(e => e.KabinetasId)
                    .HasColumnName("kabinetas_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.KabNr)
                    .HasColumnName("kab_nr")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<KomplikacijosAlergijaVaistas>(entity =>
            {
                entity.HasKey(e => new { e.FkVaistasId, e.FkAlergijaId })
                    .HasName("PRIMARY");

                entity.ToTable("komplikacijos_alergija_vaistas");

                entity.HasIndex(e => e.FkAlergijaId)
                    .HasName("komplikacijos_alergija_vaistas_alergija_fk");

                entity.Property(e => e.FkVaistasId)
                    .HasColumnName("fk_vaistas_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FkAlergijaId)
                    .HasColumnName("fk_alergija_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.FkAlergija)
                    .WithMany(p => p.KomplikacijosAlergijaVaistas)
                    .HasForeignKey(d => d.FkAlergijaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("komplikacijos_alergija_vaistas_alergija_fk");

                entity.HasOne(d => d.FkVaistas)
                    .WithMany(p => p.KomplikacijosAlergijaVaistas)
                    .HasForeignKey(d => d.FkVaistasId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("komplikacijos_alergija_vaistas_vaistas_fk");
            });

            modelBuilder.Entity<Liga>(entity =>
            {
                entity.HasKey(e => e.LilgaId)
                    .HasName("PRIMARY");

                entity.ToTable("liga");

                entity.Property(e => e.LilgaId)
                    .HasColumnName("lilga_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IprastaTrukmeD)
                    .HasColumnName("iprasta_trukme_d")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Pavadinimas)
                    .IsRequired()
                    .HasColumnName("pavadinimas")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.Simptomai)
                    .IsRequired()
                    .HasColumnName("simptomai")
                    .HasColumnType("varchar(1024)");
            });

            modelBuilder.Entity<LigonioVisitas>(entity =>
            {
                entity.ToTable("ligonio_visitas");

                entity.HasIndex(e => e.FkLigaId)
                    .HasName("ligonio_visitas_liga_fk");

                entity.HasIndex(e => e.FkPacientasId)
                    .HasName("ligonio_visitas_pacientas_fk");

                entity.HasIndex(e => e.FkPalataId)
                    .HasName("ligonio_visitas_palata_fk");

                entity.Property(e => e.LigonioVisitasId)
                    .HasColumnName("ligonio_visitas_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DataIki)
                    .HasColumnName("data_iki")
                    .HasColumnType("datetime");

                entity.Property(e => e.DataNuo)
                    .HasColumnName("data_nuo")
                    .HasColumnType("datetime");

                entity.Property(e => e.FkLigaId)
                    .HasColumnName("fk_liga_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FkPacientasId)
                    .HasColumnName("fk_pacientas_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FkPalataId)
                    .HasColumnName("fk_palata_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Komentarai)
                    .HasColumnName("komentarai")
                    .HasColumnType("varchar(1024)");

                entity.HasOne(d => d.FkLiga)
                    .WithMany(p => p.LigonioVisitas)
                    .HasForeignKey(d => d.FkLigaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ligonio_visitas_liga_fk");

                entity.HasOne(d => d.FkPacientas)
                    .WithMany(p => p.LigonioVisitas)
                    .HasForeignKey(d => d.FkPacientasId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ligonio_visitas_pacientas_fk");

                entity.HasOne(d => d.FkPalata)
                    .WithMany(p => p.LigonioVisitas)
                    .HasForeignKey(d => d.FkPalataId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ligonio_visitas_palata_fk");
            });

            modelBuilder.Entity<NesuderinamasVaistas>(entity =>
            {
                entity.HasKey(e => new { e.FkVaistasId1, e.FkVaistasId2 })
                    .HasName("PRIMARY");

                entity.ToTable("nesuderinamas_vaistas");

                entity.HasIndex(e => e.FkVaistasId2)
                    .HasName("nesuderinamas_vaistas_vaistas_fk_1");

                entity.Property(e => e.FkVaistasId1)
                    .HasColumnName("fk_vaistas_id1")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FkVaistasId2)
                    .HasColumnName("fk_vaistas_id2")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.FkVaistasId1Navigation)
                    .WithMany(p => p.NesuderinamasVaistasFkVaistasId1Navigation)
                    .HasForeignKey(d => d.FkVaistasId1)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("nesuderinamas_vaistas_vaistas_fk");

                entity.HasOne(d => d.FkVaistasId2Navigation)
                    .WithMany(p => p.NesuderinamasVaistasFkVaistasId2Navigation)
                    .HasForeignKey(d => d.FkVaistasId2)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("nesuderinamas_vaistas_vaistas_fk_1");
            });

            modelBuilder.Entity<Pacientas>(entity =>
            {
                entity.ToTable("pacientas");

                entity.Property(e => e.PacientasId)
                    .HasColumnName("pacientas_id")
                    .HasColumnType("int(11)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.DraudimoNr)
                    .HasColumnName("draudimo_nr")
                    .HasColumnType("int(11)");

                entity.Property(e => e.GimLigoninėsPav)
                    .IsRequired()
                    .HasColumnName("gim_ligoninės_pav")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.GimimoData)
                    .HasColumnName("gimimo_data")
                    .HasColumnType("date");

                entity.Property(e => e.GimimoLaikas)
                    .HasColumnName("gimimo_laikas")
                    .HasColumnType("time");

                entity.Property(e => e.GimimoMiestas)
                    .IsRequired()
                    .HasColumnName("gimimo_miestas")
                    .HasColumnType("varchar(100)");

                entity.HasOne(d => d.PacientasNavigation)
                    .WithOne(p => p.Pacientas)
                    .HasForeignKey<Pacientas>(d => d.PacientasId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("pacientas_vartotojas_fk");
            });

            modelBuilder.Entity<Palata>(entity =>
            {
                entity.ToTable("palata");

                entity.Property(e => e.PalataId)
                    .HasColumnName("palata_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.PalataNr)
                    .HasColumnName("palata_nr")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UzimtaVietu)
                    .HasColumnName("uzimta_vietu")
                    .HasColumnType("int(11)");

                entity.Property(e => e.VietuSkaicius)
                    .HasColumnName("vietu_skaicius")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<Receptas>(entity =>
            {
                entity.HasKey(e => e.ReceptoNr)
                    .HasName("PRIMARY");

                entity.ToTable("receptas");

                entity.HasIndex(e => e.FkPacientasId)
                    .HasName("receptas_pacientas_fk");

                entity.HasIndex(e => e.FkVaistasId)
                    .HasName("receptas_vaistas_fk");

                entity.Property(e => e.ReceptoNr)
                    .HasColumnName("recepto_nr")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Data)
                    .HasColumnName("data")
                    .HasColumnType("date");

                entity.Property(e => e.FkPacientasId)
                    .HasColumnName("fk_pacientas_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FkVaistasId)
                    .HasColumnName("fk_vaistas_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Laikas)
                    .HasColumnName("laikas")
                    .HasColumnType("time");

                entity.HasOne(d => d.FkPacientas)
                    .WithMany(p => p.Receptas)
                    .HasForeignKey(d => d.FkPacientasId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("receptas_pacientas_fk");

                entity.HasOne(d => d.FkVaistas)
                    .WithMany(p => p.Receptas)
                    .HasForeignKey(d => d.FkVaistasId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("receptas_vaistas_fk");
            });

            modelBuilder.Entity<Registracija>(entity =>
            {
                entity.ToTable("registracija");

                entity.HasIndex(e => e.FkDaktarasId)
                    .HasName("registracija_daktaras_fk");

                entity.HasIndex(e => e.FkPacientasId)
                    .HasName("registracija_pacientas_fk");

                entity.Property(e => e.RegistracijaId)
                    .HasColumnName("registracija_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Busena)
                    .HasColumnName("busena")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FkDaktarasId)
                    .HasColumnName("fk_daktaras_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FkPacientasId)
                    .HasColumnName("fk_pacientas_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.KviestaGreitoji)
                    .HasColumnName("kviesta_greitoji")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.PateikimoData)
                    .HasColumnName("pateikimo_data")
                    .HasColumnType("datetime");

                entity.Property(e => e.VisitoData)
                    .HasColumnName("visito_data")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.FkDaktaras)
                    .WithMany(p => p.Registracija)
                    .HasForeignKey(d => d.FkDaktarasId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("registracija_daktaras_fk");

                entity.HasOne(d => d.FkPacientas)
                    .WithMany(p => p.Registracija)
                    .HasForeignKey(d => d.FkPacientasId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("registracija_pacientas_fk");
            });

            modelBuilder.Entity<UzimtumoTvarkarastis>(entity =>
            {
                entity.ToTable("uzimtumo_tvarkarastis");

                entity.HasIndex(e => e.FkDaktarasId)
                    .HasName("uzimtumo_tvarkarastis_daktaras_fk");

                entity.Property(e => e.UzimtumoTvarkarastisId)
                    .HasColumnName("uzimtumo_tvarkarastis_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FkDaktarasId)
                    .HasColumnName("fk_daktaras_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TrukmeMin)
                    .HasColumnName("trukme_min")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.FkDaktaras)
                    .WithMany(p => p.UzimtumoTvarkarastis)
                    .HasForeignKey(d => d.FkDaktarasId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("uzimtumo_tvarkarastis_daktaras_fk");
            });

            modelBuilder.Entity<Vaistas>(entity =>
            {
                entity.ToTable("vaistas");

                entity.Property(e => e.VaistasId)
                    .HasColumnName("vaistas_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Kaina).HasColumnName("kaina");

                entity.Property(e => e.Pavadinimas)
                    .IsRequired()
                    .HasColumnName("pavadinimas")
                    .HasColumnType("varchar(100)");
            });

            modelBuilder.Entity<VaistoVartojimas>(entity =>
            {
                entity.HasKey(e => new { e.FkVaistasId, e.FkPacientasId })
                    .HasName("PRIMARY");

                entity.ToTable("vaisto_vartojimas");

                entity.HasIndex(e => e.FkPacientasId)
                    .HasName("vaisto_vartojimas_pacientas_fk");

                entity.Property(e => e.FkVaistasId)
                    .HasColumnName("fk_vaistas_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FkPacientasId)
                    .HasColumnName("fk_pacientas_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.VartotaIki)
                    .HasColumnName("vartota_iki")
                    .HasColumnType("datetime");

                entity.Property(e => e.VartotaNuo)
                    .HasColumnName("vartota_nuo")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.FkPacientas)
                    .WithMany(p => p.VaistoVartojimas)
                    .HasForeignKey(d => d.FkPacientasId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("vaisto_vartojimas_pacientas_fk");

                entity.HasOne(d => d.FkVaistas)
                    .WithMany(p => p.VaistoVartojimas)
                    .HasForeignKey(d => d.FkVaistasId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("vaisto_vartojimas_vaistas_fk");
            });

            modelBuilder.Entity<Vartotojas>(entity =>
            {
                entity.ToTable("vartotojas");

                entity.Property(e => e.VartotojasId)
                    .HasColumnName("vartotojas_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Elpastas)
                    .IsRequired()
                    .HasColumnName("elpastas")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.Pavarde)
                    .IsRequired()
                    .HasColumnName("pavarde")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.TelNr)
                    .IsRequired()
                    .HasColumnName("tel_nr")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.Vardas)
                    .IsRequired()
                    .HasColumnName("vardas")
                    .HasColumnType("varchar(100)");
            });

            modelBuilder.Entity<Zinute>(entity =>
            {
                entity.ToTable("zinute");

                entity.HasIndex(e => e.FkAdministratoriusId)
                    .HasName("zinute_administratorius_fk");

                entity.HasIndex(e => e.FkVartotojasId)
                    .HasName("zinute_vartotojas_fk");

                entity.Property(e => e.ZinuteId)
                    .HasColumnName("zinute_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Data)
                    .HasColumnName("data")
                    .HasColumnType("datetime");

                entity.Property(e => e.FkAdministratoriusId)
                    .HasColumnName("fk_administratorius_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FkVartotojasId)
                    .HasColumnName("fk_vartotojas_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Tekstas)
                    .IsRequired()
                    .HasColumnName("tekstas")
                    .HasColumnType("varchar(1024)");

                entity.HasOne(d => d.FkAdministratorius)
                    .WithMany(p => p.Zinute)
                    .HasForeignKey(d => d.FkAdministratoriusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("zinute_administratorius_fk");

                entity.HasOne(d => d.FkVartotojas)
                    .WithMany(p => p.Zinute)
                    .HasForeignKey(d => d.FkVartotojasId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("zinute_vartotojas_fk");
            });
        }
    }
}
