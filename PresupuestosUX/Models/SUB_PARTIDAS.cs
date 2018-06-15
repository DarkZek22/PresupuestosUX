namespace PresupuestosUX
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SUB_PARTIDAS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SUB_PARTIDAS()
        {
            GASTOS_CAJAS = new HashSet<GASTOS_CAJAS>();
            PAGOS_FIJOS = new HashSet<PAGOS_FIJOS>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(150)]
        public string DESC_SUBPARTIDA { get; set; }

        public int? IDPARTIDA { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GASTOS_CAJAS> GASTOS_CAJAS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PAGOS_FIJOS> PAGOS_FIJOS { get; set; }

        public virtual PARTIDAS PARTIDAS { get; set; }
    }
}
