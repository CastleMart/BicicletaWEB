namespace BicicletaWEB.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Ventas
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idVenta { get; set; }

        [Column(TypeName = "date")]
        public DateTime? fecha { get; set; }

        public decimal? precioTotal { get; set; }
    }
}
