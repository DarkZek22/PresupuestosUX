namespace PresupuestosUX
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ESTATUS_PAGO_PROVEEDOR
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ESTATUS_PAGO_PROVEEDOR()
        {
            PAGO_PROVEEDOR = new HashSet<PAGO_PROVEEDOR>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(150)]
        public string DESC_ESTATUS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PAGO_PROVEEDOR> PAGO_PROVEEDOR { get; set; }
    }
}
