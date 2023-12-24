using System;
using System.Collections.Generic;

namespace ProyectoPDV.Models
{
    public partial class ProductosFinale
    {
        public ProductosFinale()
        {
            DetalleVenta = new HashSet<DetalleVentum>();
            InsumosXProductoFinals = new HashSet<InsumosXProductoFinal>();
        }

        public int IdProducto { get; set; }
        public string? Codigo { get; set; }
        public string? Descripcion { get; set; }
        public int? IdCategoria { get; set; }
        public int? Stock { get; set; }
        public decimal? Precio { get; set; }
        public bool? EsActivo { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public decimal? Costo { get; set; }
        public decimal? Factor { get; set; }
        public decimal? PrecioVenta { get; set; }
        public decimal? GananciaBruta { get; set; }

        public virtual Categorium? IdCategoriaNavigation { get; set; }
        public virtual ICollection<DetalleVentum> DetalleVenta { get; set; }
        public virtual ICollection<InsumosXProductoFinal> InsumosXProductoFinals { get; set; }
    }
}
