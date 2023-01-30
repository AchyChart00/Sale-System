﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVenta.DTO
{
    public class DTO_Venta
    {
        public int IdVenta { get; set; }

        public string? NumeroDocumento { get; set; }

        public string? TipoPago { get; set; }

        public decimal? Total { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public virtual ICollection<DTO_DetalleVenta> DetalleVenta { get; set; }
    }
}
