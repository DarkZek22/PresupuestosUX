namespace PresupuestosUX.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AREAS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AREAS()
        {
            DEPARTAMENTOS = new HashSet<DEPARTAMENTOS>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(20)]
        public string NOMBRE { get; set; }

        public bool ACTIVO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DEPARTAMENTOS> DEPARTAMENTOS { get; set; }
    }
}
