using System;
using System.Collections.Generic;

namespace MVCCRUD.Models
{
    public partial class SubProducto
    {
        public SubProducto()
        {
            Stocks = new HashSet<Stock>();
        }

        public int IdSubProducto { get; set; }
        public int? IdStock { get; set; }
        public int? IdProducto { get; set; }
        public string? NombreSubProducto { get; set; }
        public string? DescripcionSubProducto { get; set; }

        public virtual Producto? IdProductoNavigation { get; set; }
        public virtual ICollection<Stock> Stocks { get; set; }
    }
}
