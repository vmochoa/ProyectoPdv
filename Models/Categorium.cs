using System;
using System.Collections.Generic;

namespace ProyectoPDV.Models
{
    public partial class Categorium
    {
        public Categorium()
        {
            ProductosFinales = new HashSet<ProductosFinale>();
        }

        public int IdCategoria { get; set; }
        public string Descripcion { get; set; } = null!;
        public bool EsActivo { get; set; }
        public DateTime? FechaRegistro { get; set; }

        public virtual ICollection<ProductosFinale> ProductosFinales { get; set; }
    }
}
