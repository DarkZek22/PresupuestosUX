namespace PresupuestosUX
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class FACTURA_PROVEEDOR
    {
        public FACTURA_PROVEEDOR()
        {
            FECHA = DateTime.Now.ToString();
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

        public virtual ICollection<PAGO_PROVEEDOR> PAGO_PROVEEDOR { get; set; }

        public virtual PROVEEDORES PROVEEDORES { get; set; }
    }
}
