namespace PresupuestosUX.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ALMACENs
    {
        public int ID { get; set; }

        public int CANTIDAD { get; set; }

        public int PRODUCTOSID { get; set; }

        public int Property { get; set; }

        public virtual PRODUCTOS PRODUCTOS { get; set; }
    }
}
