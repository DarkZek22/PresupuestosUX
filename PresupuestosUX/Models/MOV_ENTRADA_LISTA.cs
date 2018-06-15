namespace PresupuestosUX
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MOV_ENTRADA_LISTA
    {
        public int ID { get; set; }

        public int CANTIDAD { get; set; }

        public int PRECIO { get; set; }

        public int PRODUCTOID { get; set; }

        public int MOV_ENTRADAID { get; set; }

        public virtual MOV_ENTRADA MOV_ENTRADA { get; set; }

        public virtual PRODUCTOS PRODUCTOS { get; set; }
    }
}
