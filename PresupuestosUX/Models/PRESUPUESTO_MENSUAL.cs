namespace PresupuestosUX
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PRESUPUESTO_MENSUAL
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PRESUPUESTO_MENSUAL()
        {
            CAJA_CHICA = new HashSet<CAJA_CHICA>();
            INGRESO = new HashSet<INGRESO>();
            PAGO_PROVEEDOR = new HashSet<PAGO_PROVEEDOR>();
            PAGOS_FIJOS = new HashSet<PAGOS_FIJOS>();
        }

        public int ID { get; set; }

        public double SALDO { get; set; }

        public double SALDOPROP { get; set; }

        public int ANIO { get; set; }

        [Column(TypeName = "date")]
        public DateTime FECHA_PRES { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CAJA_CHICA> CAJA_CHICA { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INGRESO> INGRESO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PAGO_PROVEEDOR> PAGO_PROVEEDOR { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PAGOS_FIJOS> PAGOS_FIJOS { get; set; }
    }
}
