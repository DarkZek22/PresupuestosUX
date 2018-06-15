namespace PresupuestosUX
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PAGO_PROVEEDOR
    {
        public int ID { get; set; }

        public int SALDO { get; set; }

        public DateTime FECHA_PAGO { get; set; }

        public int? IDESTATUS { get; set; }

        public int? IDPRESUPUESTOMENSUAL { get; set; }

        public int? IDFACTURA { get; set; }

        public virtual ESTATUS_PAGO_PROVEEDOR ESTATUS_PAGO_PROVEEDOR { get; set; }

        public virtual PRESUPUESTO_MENSUAL PRESUPUESTO_MENSUAL { get; set; }

        public virtual FACTURA_PROVEEDOR FACTURA_PROVEEDOR{ get; set; }
    }
}
