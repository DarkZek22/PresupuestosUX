namespace PresupuestosUX.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("INGRESO")]
    public partial class INGRESO
    {
        public int ID { get; set; }

        [Required]
        [StringLength(150)]
        public string DESC_INGRESO { get; set; }

        public double SALDO_INGRESO { get; set; }

        public DateTime FECHA_INGRESO { get; set; }

        public int? ID_PRESUPUESTOMENSUAL { get; set; }

        public int? ID_BANCO { get; set; }

        public virtual BANCOS BANCOS { get; set; }

        public virtual PRESUPUESTO_MENSUAL PRESUPUESTO_MENSUAL { get; set; }
    }
}
