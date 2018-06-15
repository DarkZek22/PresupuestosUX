namespace PresupuestosUX
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TRABAJADORESUXes
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string NOMBRE { get; set; }

        [Required]
        [StringLength(50)]
        public string AP_PATERNO { get; set; }

        [Required]
        [StringLength(50)]
        public string AP_MATERNO { get; set; }

        public int DEPARTAMENTOID { get; set; }

        public virtual DEPARTAMENTOS DEPARTAMENTOS { get; set; }
    }
}
