using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVCCRUD.Models
{
    public partial class Proveedore
    {
        public Proveedore()
        {
            Facturas = new HashSet<Factura>();
        }
        [Display(Name = "ID de Proveedor")]
        [Required(ErrorMessage = "Se requiere un ID de Proveedores")]
        public int IdProveedores { get; set; }
        [Display(Name = "ID de la Factura")]
        [Required(ErrorMessage = "Se requiere un ID de factura")]
        public int IdFactura { get; set; }

        [Display(Name = "Nombre de Proveedor")]
        [Required(ErrorMessage = "Se requiere nombre del proveedor")]
        public string? NombreProveedor { get; set; }
        [Display(Name = "Rut del Proveedor")]
        [Required(ErrorMessage = "Se requiere Rut del proveedor")]
        public string? RutProveedor { get; set; }
        [Display(Name = "Teléfono del Proveedor")]
        [Required(ErrorMessage = "Se requiere Teléfono del proveedor")]
        public string? FonoProveedor { get; set; }

        public virtual ICollection<Factura> Facturas { get; set; }
    }
}
