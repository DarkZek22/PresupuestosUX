namespace PresupuestosUX.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext()
            : base("name=ApplicationDBContext")
        {
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<ALMACENs> ALMACENs { get; set; }
        public virtual DbSet<AREAS> AREAS { get; set; }
        public virtual DbSet<ASIGNACIONES> ASIGNACIONES { get; set; }
        public virtual DbSet<ASIGNACIONES_LISTA> ASIGNACIONES_LISTA { get; set; }
        public virtual DbSet<BANCO_SALDOS> BANCO_SALDOS { get; set; }
        public virtual DbSet<BANCOS> BANCOS { get; set; }
        public virtual DbSet<CAJA_CHICA> CAJA_CHICA { get; set; }
        public virtual DbSet<CAT_PRODUCTOS> CAT_PRODUCTOS { get; set; }
        public virtual DbSet<DEPARTAMENTOS> DEPARTAMENTOS { get; set; }
        public virtual DbSet<EMPLEADOS> EMPLEADOS { get; set; }
        public virtual DbSet<ESTATUS_PAGO_PROVEEDOR> ESTATUS_PAGO_PROVEEDOR { get; set; }
        public virtual DbSet<FACTURA_PROVEEDOR> FACTURA_PROVEEDOR { get; set; }
        public virtual DbSet<FACTURA_RECIBO_PAGO> FACTURA_RECIBO_PAGO { get; set; }
        public virtual DbSet<GASTOS_CAJAS> GASTOS_CAJAS { get; set; }
        public virtual DbSet<INGRESO> INGRESO { get; set; }
        public virtual DbSet<MOV_ENTRADA> MOV_ENTRADA { get; set; }
        public virtual DbSet<MOV_ENTRADA_LISTA> MOV_ENTRADA_LISTA { get; set; }
        public virtual DbSet<MOV_SALIDA> MOV_SALIDA { get; set; }
        public virtual DbSet<MOV_SALIDA_LISTA> MOV_SALIDA_LISTA { get; set; }
        public virtual DbSet<PAGO_PROVEEDOR> PAGO_PROVEEDOR { get; set; }
        public virtual DbSet<PAGOS_FIJOS> PAGOS_FIJOS { get; set; }
        public virtual DbSet<PARTIDAS> PARTIDAS { get; set; }
        public virtual DbSet<PRESUPUESTO_MENSUAL> PRESUPUESTO_MENSUAL { get; set; }
        public virtual DbSet<PRODUCTOS> PRODUCTOS { get; set; }
        public virtual DbSet<PROVEEDORES> PROVEEDORES { get; set; }
        public virtual DbSet<PUESTOS> PUESTOS { get; set; }
        public virtual DbSet<SUB_PARTIDAS> SUB_PARTIDAS { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<TIPO_EMPLEADOS> TIPO_EMPLEADOS { get; set; }
        public virtual DbSet<TRABAJADORESUXes> TRABAJADORESUXes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AREAS>()
                .HasMany(e => e.DEPARTAMENTOS)
                .WithRequired(e => e.AREAS)
                .HasForeignKey(e => e.AREAID);

            modelBuilder.Entity<ASIGNACIONES>()
                .HasMany(e => e.ASIGNACIONES_LISTA)
                .WithRequired(e => e.ASIGNACIONES)
                .HasForeignKey(e => e.ASIGNACIONID);

            modelBuilder.Entity<BANCOS>()
                .Property(e => e.NOMBRE)
                .IsUnicode(false);

            modelBuilder.Entity<BANCOS>()
                .Property(e => e.CUENTA)
                .IsUnicode(false);

            modelBuilder.Entity<BANCOS>()
                .HasMany(e => e.BANCO_SALDOS)
                .WithOptional(e => e.BANCOS)
                .HasForeignKey(e => e.ID_BANCO);

            modelBuilder.Entity<BANCOS>()
                .HasMany(e => e.FACTURA_RECIBO_PAGO)
                .WithOptional(e => e.BANCOS)
                .HasForeignKey(e => e.ID_BANCO);

            modelBuilder.Entity<BANCOS>()
                .HasMany(e => e.INGRESO)
                .WithOptional(e => e.BANCOS)
                .HasForeignKey(e => e.ID_BANCO);

            modelBuilder.Entity<CAJA_CHICA>()
                .Property(e => e.MES)
                .IsUnicode(false);

            modelBuilder.Entity<CAJA_CHICA>()
                .HasMany(e => e.GASTOS_CAJAS)
                .WithOptional(e => e.CAJA_CHICA)
                .HasForeignKey(e => e.IDCAJACHICA);

            modelBuilder.Entity<CAT_PRODUCTOS>()
                .HasMany(e => e.PRODUCTOS)
                .WithRequired(e => e.CAT_PRODUCTOS)
                .HasForeignKey(e => e.CATEGORIASID);

            modelBuilder.Entity<DEPARTAMENTOS>()
                .HasMany(e => e.ASIGNACIONES)
                .WithRequired(e => e.DEPARTAMENTOS)
                .HasForeignKey(e => e.DEPARTAMENTOID);

            modelBuilder.Entity<DEPARTAMENTOS>()
                .HasMany(e => e.MOV_SALIDA)
                .WithRequired(e => e.DEPARTAMENTOS)
                .HasForeignKey(e => e.DEPARTAMENTOID);

            modelBuilder.Entity<DEPARTAMENTOS>()
                .HasMany(e => e.PUESTOS)
                .WithRequired(e => e.DEPARTAMENTOS)
                .HasForeignKey(e => e.DEPARTAMENTOID);

            modelBuilder.Entity<DEPARTAMENTOS>()
                .HasMany(e => e.TRABAJADORESUXes)
                .WithRequired(e => e.DEPARTAMENTOS)
                .HasForeignKey(e => e.DEPARTAMENTOID);

            modelBuilder.Entity<EMPLEADOS>()
                .HasMany(e => e.ASIGNACIONES)
                .WithRequired(e => e.EMPLEADOS)
                .HasForeignKey(e => e.EMPLEADOID);

            modelBuilder.Entity<EMPLEADOS>()
                .HasMany(e => e.MOV_ENTRADA)
                .WithRequired(e => e.EMPLEADOS)
                .HasForeignKey(e => e.EMPLEADOID);

            modelBuilder.Entity<EMPLEADOS>()
                .HasMany(e => e.MOV_SALIDA)
                .WithRequired(e => e.EMPLEADOS)
                .HasForeignKey(e => e.EMPLEADOID);

            modelBuilder.Entity<ESTATUS_PAGO_PROVEEDOR>()
                .Property(e => e.DESC_ESTATUS)
                .IsUnicode(false);

            modelBuilder.Entity<ESTATUS_PAGO_PROVEEDOR>()
                .HasMany(e => e.PAGO_PROVEEDOR)
                .WithOptional(e => e.ESTATUS_PAGO_PROVEEDOR)
                .HasForeignKey(e => e.IDESTATUS);

            modelBuilder.Entity<FACTURA_PROVEEDOR>()
                .Property(e => e.DESC_FACTURA)
                .IsUnicode(false);

            modelBuilder.Entity<FACTURA_PROVEEDOR>()
                .Property(e => e.FOLIO)
                .IsUnicode(false);

            modelBuilder.Entity<FACTURA_PROVEEDOR>()
                .Property(e => e.FECHA)
                .IsUnicode(false);

            modelBuilder.Entity<FACTURA_PROVEEDOR>()
                .HasMany(e => e.FACTURA_RECIBO_PAGO)
                .WithOptional(e => e.FACTURA_PROVEEDOR)
                .HasForeignKey(e => e.ID_FACTURA);

            modelBuilder.Entity<FACTURA_PROVEEDOR>()
                .HasMany(e => e.PAGO_PROVEEDOR)
                .WithOptional(e => e.FACTURA_PROVEEDOR)
                .HasForeignKey(e => e.ID_FACTURA);

            modelBuilder.Entity<INGRESO>()
                .Property(e => e.DESC_INGRESO)
                .IsUnicode(false);

            modelBuilder.Entity<PARTIDAS>()
                .Property(e => e.DESC_PARTIDA)
                .IsUnicode(false);

            modelBuilder.Entity<PARTIDAS>()
                .HasMany(e => e.GASTOS_CAJAS)
                .WithOptional(e => e.PARTIDAS)
                .HasForeignKey(e => e.IDPARTIDAS);

            modelBuilder.Entity<PARTIDAS>()
                .HasMany(e => e.PAGOS_FIJOS)
                .WithOptional(e => e.PARTIDAS)
                .HasForeignKey(e => e.IDPARTIDA);

            modelBuilder.Entity<PARTIDAS>()
                .HasMany(e => e.SUB_PARTIDAS)
                .WithOptional(e => e.PARTIDAS)
                .HasForeignKey(e => e.IDPARTIDA);

            modelBuilder.Entity<PRESUPUESTO_MENSUAL>()
                .Property(e => e.MES)
                .IsUnicode(false);

            modelBuilder.Entity<PRESUPUESTO_MENSUAL>()
                .HasMany(e => e.CAJA_CHICA)
                .WithOptional(e => e.PRESUPUESTO_MENSUAL)
                .HasForeignKey(e => e.IDPRESUPUESTOMENSUAL);

            modelBuilder.Entity<PRESUPUESTO_MENSUAL>()
                .HasMany(e => e.INGRESO)
                .WithOptional(e => e.PRESUPUESTO_MENSUAL)
                .HasForeignKey(e => e.ID_PRESUPUESTOMENSUAL);

            modelBuilder.Entity<PRESUPUESTO_MENSUAL>()
                .HasMany(e => e.PAGO_PROVEEDOR)
                .WithOptional(e => e.PRESUPUESTO_MENSUAL)
                .HasForeignKey(e => e.IDPRESUPUESTOMENSUAL);

            modelBuilder.Entity<PRESUPUESTO_MENSUAL>()
                .HasMany(e => e.PAGOS_FIJOS)
                .WithOptional(e => e.PRESUPUESTO_MENSUAL)
                .HasForeignKey(e => e.IDPRESUPUESTOMENSUAL);

            modelBuilder.Entity<PRODUCTOS>()
                .HasMany(e => e.ASIGNACIONES_LISTA)
                .WithRequired(e => e.PRODUCTOS)
                .HasForeignKey(e => e.PRODUCTOID);

            modelBuilder.Entity<PRODUCTOS>()
                .HasMany(e => e.MOV_ENTRADA_LISTA)
                .WithRequired(e => e.PRODUCTOS)
                .HasForeignKey(e => e.PRODUCTOID);

            modelBuilder.Entity<PRODUCTOS>()
                .HasMany(e => e.MOV_SALIDA_LISTA)
                .WithRequired(e => e.PRODUCTOS)
                .HasForeignKey(e => e.PRODUCTOID);

            modelBuilder.Entity<PROVEEDORES>()
                .HasMany(e => e.FACTURA_PROVEEDOR)
                .WithOptional(e => e.PROVEEDORES)
                .HasForeignKey(e => e.IDPROVEEDOR);

            modelBuilder.Entity<PROVEEDORES>()
                .HasMany(e => e.MOV_ENTRADA)
                .WithRequired(e => e.PROVEEDORES)
                .HasForeignKey(e => e.PROVEEDORID);

            modelBuilder.Entity<SUB_PARTIDAS>()
                .Property(e => e.DESC_SUBPARTIDA)
                .IsUnicode(false);

            modelBuilder.Entity<SUB_PARTIDAS>()
                .HasMany(e => e.GASTOS_CAJAS)
                .WithOptional(e => e.SUB_PARTIDAS)
                .HasForeignKey(e => e.IDSUBPARTIDAS);

            modelBuilder.Entity<SUB_PARTIDAS>()
                .HasMany(e => e.PAGOS_FIJOS)
                .WithOptional(e => e.SUB_PARTIDAS)
                .HasForeignKey(e => e.IDSUBPARTIDA);

            modelBuilder.Entity<TIPO_EMPLEADOS>()
                .HasMany(e => e.EMPLEADOS)
                .WithRequired(e => e.TIPO_EMPLEADOS)
                .HasForeignKey(e => e.TIPO_EMPLEADOID);
        }
    }
}
