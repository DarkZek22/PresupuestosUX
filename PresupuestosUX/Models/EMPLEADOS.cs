namespace PresupuestosUX
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class EMPLEADOS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EMPLEADOS()
        {
            ASIGNACIONES = new HashSet<ASIGNACIONES>();
            MOV_ENTRADA = new HashSet<MOV_ENTRADA>();
            MOV_SALIDA = new HashSet<MOV_SALIDA>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(20)]
        public string USERNAME { get; set; }

        [Required]
        [StringLength(20)]
        public string PASSWORD { get; set; }

        [Required]
        [StringLength(20)]
        public string NOMBRE { get; set; }

        [Required]
        [StringLength(20)]
        public string AP_PATERNO { get; set; }

        [Required]
        [StringLength(20)]
        public string AP_MATERNO { get; set; }

        public int TIPO_EMPLEADOID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ASIGNACIONES> ASIGNACIONES { get; set; }

        public virtual TIPO_EMPLEADOS TIPO_EMPLEADOS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MOV_ENTRADA> MOV_ENTRADA { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MOV_SALIDA> MOV_SALIDA { get; set; }
    }
}
