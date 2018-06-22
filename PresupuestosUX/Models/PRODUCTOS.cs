namespace PresupuestosUX.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PRODUCTOS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PRODUCTOS()
        {
            ALMACENs = new HashSet<ALMACENs>();
            ASIGNACIONES_LISTA = new HashSet<ASIGNACIONES_LISTA>();
            MOV_ENTRADA_LISTA = new HashSet<MOV_ENTRADA_LISTA>();
            MOV_SALIDA_LISTA = new HashSet<MOV_SALIDA_LISTA>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(15)]
        public string CODIGOBARRAS { get; set; }

        [Required]
        [StringLength(20)]
        public string NOMBRE { get; set; }

        public int PRECIO { get; set; }

        [StringLength(120)]
        public string UBICACION { get; set; }

        public int CATEGORIASID { get; set; }

        public int CANTIDAD { get; set; }

        [StringLength(150)]
        public string DESCRIPCION { get; set; }

        [StringLength(50)]
        public string SERIE { get; set; }

        [StringLength(30)]
        public string MARCA { get; set; }

        [StringLength(30)]
        public string MODELO { get; set; }

        [StringLength(120)]
        public string EMPLEADOASIGNACION { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ALMACENs> ALMACENs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ASIGNACIONES_LISTA> ASIGNACIONES_LISTA { get; set; }

        public virtual CAT_PRODUCTOS CAT_PRODUCTOS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MOV_ENTRADA_LISTA> MOV_ENTRADA_LISTA { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MOV_SALIDA_LISTA> MOV_SALIDA_LISTA { get; set; }
    }
}
