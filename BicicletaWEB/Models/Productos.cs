namespace BicicletaWEB.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Productos
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idProducto { get; set; }

        [StringLength(80)]
        public string nombreProducto { get; set; }

        [StringLength(50)]
        public string Categoria { get; set; }

        public decimal? Precio { get; set; }

        public int? Existencia { get; set; }

        [Column(TypeName = "text")]
        public string Descripcion { get; set; }
    }
}
