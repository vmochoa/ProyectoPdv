using System;
using System.Collections.Generic;

namespace ProyectoPDV.Models
{
    public partial class Insumo
    {
        public Insumo()
        {
            InsumosXProductoFinals = new HashSet<InsumosXProductoFinal>();
        }

        public int IdInsumo { get; set; }
        public string Nombre { get; set; } = null!;
        public decimal Costo { get; set; }
        public int? CantidadEnPaquete { get; set; }
        public decimal? CostoUnitario { get; set; }

        public virtual ICollection<InsumosXProductoFinal> InsumosXProductoFinals { get; set; }
    }
}
