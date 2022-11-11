using MessagePack;
using Microsoft.Build.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using KeyAttribute = System.ComponentModel.DataAnnotations.KeyAttribute;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace MVCCRUD.Models
{
    public partial class Producto
    {
       
        public Producto()
        {
            SubProductos = new HashSet<SubProducto>();
        }
        [Display(Name = "ID de Producto")]
        [Required(ErrorMessage = "Se requiere un ID para Producto")]
        public int IdProducto { get; set; }
        [Display(Name = "ID Sub Producto")]
        [Required(ErrorMessage = "Se requiere un ID para Sub Producto")]
        public int? IdSubProducto { get; set; }
        [Display(Name = "Nombre del Producto")]
        [Required(ErrorMessage = "Se requiere Nombre Producto")]
        public string? NombreProducto { get; set; }

        public virtual ICollection<SubProducto> SubProductos { get; set; }
    }
}
