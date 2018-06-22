namespace PresupuestosUX.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class FACTURA_RECIBO_PAGO
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        public double MONTO_PAGO { get; set; }

        public double MONTO_RESTANTE { get; set; }

        public int NUMERO_PAGO { get; set; }

        public int? ID_FACTURA { get; set; }

        public int? ID_BANCO { get; set; }

        public virtual BANCOS BANCOS { get; set; }

        public virtual FACTURA_PROVEEDOR FACTURA_PROVEEDOR { get; set; }
    }
}
