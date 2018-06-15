namespace PresupuestosUX
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PAGOS_FIJOS
    {
        public int ID { get; set; }

        public double SALDO { get; set; }

        public DateTime FECHA_PAGO { get; set; }

        public int? IDPARTIDA { get; set; }

        public int? IDSUBPARTIDA { get; set; }

        public int? IDPRESUPUESTOMENSUAL { get; set; }

        public virtual PARTIDAS PARTIDAS { get; set; }

        public virtual PRESUPUESTO_MENSUAL PRESUPUESTO_MENSUAL { get; set; }

        public virtual SUB_PARTIDAS SUB_PARTIDAS { get; set; }
    }
}
