namespace PresupuestosUX.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DEPARTAMENTOS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DEPARTAMENTOS()
        {
            ASIGNACIONES = new HashSet<ASIGNACIONES>();
            MOV_SALIDA = new HashSet<MOV_SALIDA>();
            PUESTOS = new HashSet<PUESTOS>();
            TRABAJADORESUXes = new HashSet<TRABAJADORESUXes>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(60)]
        public string NOMBRE { get; set; }

        public int AREAID { get; set; }

        public virtual AREAS AREAS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ASIGNACIONES> ASIGNACIONES { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MOV_SALIDA> MOV_SALIDA { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PUESTOS> PUESTOS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TRABAJADORESUXes> TRABAJADORESUXes { get; set; }
    }
}
