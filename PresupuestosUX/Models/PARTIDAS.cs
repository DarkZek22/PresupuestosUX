namespace PresupuestosUX
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PARTIDAS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PARTIDAS()
        {
            GASTOS_CAJAS = new HashSet<GASTOS_CAJAS>();
            PAGOS_FIJOS = new HashSet<PAGOS_FIJOS>();
            SUB_PARTIDAS = new HashSet<SUB_PARTIDAS>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(150)]
        public string DESC_PARTIDA { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GASTOS_CAJAS> GASTOS_CAJAS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PAGOS_FIJOS> PAGOS_FIJOS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SUB_PARTIDAS> SUB_PARTIDAS { get; set; }
    }
}
