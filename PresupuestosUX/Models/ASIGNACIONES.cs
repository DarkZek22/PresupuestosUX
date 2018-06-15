namespace PresupuestosUX
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ASIGNACIONES
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ASIGNACIONES()
        {
            ASIGNACIONES_LISTA = new HashSet<ASIGNACIONES_LISTA>();
        }

        public int ID { get; set; }

        public DateTime Fecha { get; set; }

        public int EMPLEADOID { get; set; }

        public int DEPARTAMENTOID { get; set; }

        public int PRECIOTOTAL { get; set; }

        public virtual DEPARTAMENTOS DEPARTAMENTOS { get; set; }

        public virtual EMPLEADOS EMPLEADOS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ASIGNACIONES_LISTA> ASIGNACIONES_LISTA { get; set; }
    }
}
