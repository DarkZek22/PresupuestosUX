namespace PresupuestosUX.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class FACTURA_PROVEEDOR
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FACTURA_PROVEEDOR()
        {
            FACTURA_RECIBO_PAGO = new HashSet<FACTURA_RECIBO_PAGO>();
            PAGO_PROVEEDOR = new HashSet<PAGO_PROVEEDOR>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(150)]
        public string DESC_FACTURA { get; set; }

        public double SALDO { get; set; }

        [Required]
        [StringLength(20)]
        public string FOLIO { get; set; }

        [Required]
        [StringLength(50)]
        public string FECHA { get; set; }

        public int? IDPROVEEDOR { get; set; }

        public virtual PROVEEDORES PROVEEDORES { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FACTURA_RECIBO_PAGO> FACTURA_RECIBO_PAGO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PAGO_PROVEEDOR> PAGO_PROVEEDOR { get; set; }
    }
}
