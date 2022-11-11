using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVCCRUD.Models
{
    public partial class Stock
    {
        [Display(Name = "ID de Stock")]
        [Required(ErrorMessage = "Se requiere Valos de costo")]
        public int IdStock { get; set; }
        public int? IdFactura { get; set; }
        public int? IdSubProducto { get; set; }
        [Required(ErrorMessage = "Se requiere Valos de costo")]
        public int? ValorCosto { get; set; }
        [Required(ErrorMessage = "Se requiere Valos de venta")]
        public int? ValorVenta { get; set; }
        [Required(ErrorMessage = "Se requiere cantidad de stock")]
        public int? CantidadStock { get; set; }

        public virtual Factura? IdFacturaNavigation { get; set; }
        public virtual SubProducto? IdSubProductoNavigation { get; set; }
    }
}
