namespace PresupuestosUX.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MOV_SALIDA_LISTA
    {
        public int ID { get; set; }

        public int CANTIDAD { get; set; }

        public int PRECIO { get; set; }

        public int PRODUCTOID { get; set; }

        public int MOV_SALIDAID { get; set; }

        public virtual MOV_SALIDA MOV_SALIDA { get; set; }

        public virtual PRODUCTOS PRODUCTOS { get; set; }
    }
}
