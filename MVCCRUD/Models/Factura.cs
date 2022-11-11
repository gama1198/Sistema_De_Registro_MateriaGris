using System;
using System.Collections.Generic;

namespace MVCCRUD.Models
{
    public partial class Factura
    {
        public Factura()
        {
            Stocks = new HashSet<Stock>();
        }

        public int IdFactura { get; set; }
        public int? IdProveedores { get; set; }
        public string? NombreProducto { get; set; }
        public DateTime? Fecha { get; set; }

        public virtual Proveedore? IdProveedoresNavigation { get; set; }
        public virtual ICollection<Stock> Stocks { get; set; }
    }
}
