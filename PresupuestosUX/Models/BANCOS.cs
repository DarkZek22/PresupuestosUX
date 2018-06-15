namespace PresupuestosUX
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BANCOS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BANCOS()
        {
            INGRESO = new HashSet<INGRESO>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(20)]
        public string NOMBRE { get; set; }

        [Required]
        [StringLength(20)]
        public string CUENTA { get; set; }

        public double SALDO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INGRESO> INGRESO { get; set; }
    }
}
