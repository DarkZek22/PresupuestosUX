namespace PresupuestosUX
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MOV_SALIDA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MOV_SALIDA()
        {
            MOV_SALIDA_LISTA = new HashSet<MOV_SALIDA_LISTA>();
        }

        public int ID { get; set; }

        public DateTime Fecha { get; set; }

        public int EMPLEADOID { get; set; }

        public int DEPARTAMENTOID { get; set; }

        public int PRECIOTOTAL { get; set; }

        public virtual DEPARTAMENTOS DEPARTAMENTOS { get; set; }

        public virtual EMPLEADOS EMPLEADOS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MOV_SALIDA_LISTA> MOV_SALIDA_LISTA { get; set; }
    }
}
