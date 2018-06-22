namespace PresupuestosUX.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CAJA_CHICA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CAJA_CHICA()
        {
            GASTOS_CAJAS = new HashSet<GASTOS_CAJAS>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(10)]
        public string MES { get; set; }

        public double SUELDO_CAJA { get; set; }

        public DateTime FECHA_CAJA { get; set; }

        public int? IDPRESUPUESTOMENSUAL { get; set; }

        public virtual PRESUPUESTO_MENSUAL PRESUPUESTO_MENSUAL { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GASTOS_CAJAS> GASTOS_CAJAS { get; set; }
    }
}
