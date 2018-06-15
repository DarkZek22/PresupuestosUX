namespace PresupuestosUX
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PROVEEDORES
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PROVEEDORES()
        {
            FACTURA_PROVEEDOR = new HashSet<FACTURA_PROVEEDOR>();
            MOV_ENTRADA = new HashSet<MOV_ENTRADA>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(20)]
        public string NOMBRE { get; set; }

        [StringLength(20)]
        public string AP_PATERNO { get; set; }

        [StringLength(20)]
        public string AP_MATERNO { get; set; }

        [Required]
        [StringLength(60)]
        public string DIRECCION { get; set; }

        [Required]
        [StringLength(15)]
        public string TELEFONO { get; set; }

        [Required]
        [StringLength(20)]
        public string EMAIL { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FACTURA_PROVEEDOR> FACTURA_PROVEEDOR { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MOV_ENTRADA> MOV_ENTRADA { get; set; }
    }
}
