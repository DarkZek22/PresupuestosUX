namespace PresupuestosUX
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PUESTOS
    {
        public int ID { get; set; }

        [Required]
        [StringLength(150)]
        public string NOMBRE { get; set; }

        [StringLength(20)]
        public string JEFE { get; set; }

        public bool ACTIVO { get; set; }

        public int DEPARTAMENTOID { get; set; }

        public virtual DEPARTAMENTOS DEPARTAMENTOS { get; set; }
    }
}
