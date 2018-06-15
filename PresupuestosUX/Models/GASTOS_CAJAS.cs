namespace PresupuestosUX
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class GASTOS_CAJAS
    {
        public int ID { get; set; }

        public double SALDO { get; set; }

        public DateTime FECHA_GASTO { get; set; }

        public int? IDCAJACHICA { get; set; }

        public int? IDPARTIDAS { get; set; }

        public int? IDSUBPARTIDAS { get; set; }

        public virtual CAJA_CHICA CAJA_CHICA { get; set; }

        public virtual PARTIDAS PARTIDAS { get; set; }

        public virtual SUB_PARTIDAS SUB_PARTIDAS { get; set; }
    }
}
