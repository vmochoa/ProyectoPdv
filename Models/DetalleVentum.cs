﻿using System;
using System.Collections.Generic;

namespace ProyectoPDV.Models
{
    public partial class DetalleVentum
    {
        public int IdDetalleVenta { get; set; }
        public int? IdVenta { get; set; }
        public int? IdProducto { get; set; }
        public int? Cantidad { get; set; }
        public decimal? Precio { get; set; }
        public decimal? Total { get; set; }

        public virtual ProductosFinale? IdProductoNavigation { get; set; }
        public virtual Ventum? IdVentaNavigation { get; set; }
    }
}
