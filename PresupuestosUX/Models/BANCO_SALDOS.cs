namespace PresupuestosUX.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BANCO_SALDOS
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        public double SALDO { get; set; }

        public DateTime? FECHA_SALDO { get; set; }

        public int? ID_BANCO { get; set; }

        public virtual BANCOS BANCOS { get; set; }
    }
}
