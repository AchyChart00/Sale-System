using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVenta.DTO
{
    public class DTO_Dashboard
    {
        public int TotalVentas { get; set; }
        public string? TotalIngresos { get; set; }
        public List<DTO_VentaSemana>? VentasUltimaSemana { get; set; }
    }
}
