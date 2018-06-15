namespace PresupuestosUX
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ASIGNACIONES_LISTA
    {
        public int ID { get; set; }

        public int PRECIO { get; set; }

        public int PRODUCTOID { get; set; }

        public int ASIGNACIONID { get; set; }

        public int CANTIDAD { get; set; }

        public virtual ASIGNACIONES ASIGNACIONES { get; set; }

        public virtual PRODUCTOS PRODUCTOS { get; set; }
    }
}
