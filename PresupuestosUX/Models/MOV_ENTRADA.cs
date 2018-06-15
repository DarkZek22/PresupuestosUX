namespace PresupuestosUX
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MOV_ENTRADA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MOV_ENTRADA()
        {
            MOV_ENTRADA_LISTA = new HashSet<MOV_ENTRADA_LISTA>();
        }

        public int ID { get; set; }

        public DateTime Fecha { get; set; }

        public int EMPLEADOID { get; set; }

        public int PROVEEDORID { get; set; }

        public int PRECIOTOTAL { get; set; }

        public virtual EMPLEADOS EMPLEADOS { get; set; }

        public virtual PROVEEDORES PROVEEDORES { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MOV_ENTRADA_LISTA> MOV_ENTRADA_LISTA { get; set; }
    }
}
