using System;
using System.Collections.Generic;

namespace ProyectoPDV.Models
{
    public partial class InsumosXProductoFinal
    {
        public int Id { get; set; }
        public int IdProductoFinal { get; set; }
        public int IdInsumo { get; set; }
        public decimal? CantidadInsumos { get; set; }
        public decimal? CostoTotal { get; set; }

        public virtual Insumo IdInsumoNavigation { get; set; } = null!;
        public virtual ProductosFinale IdProductoFinalNavigation { get; set; } = null!;
    }
}
