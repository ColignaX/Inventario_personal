using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventarioPersonal.Models
{
    [Table("inventario")]
    public class InventarioItem
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("categoria")]
        public string Categoria { get; set; } = string.Empty;

        [Required]
        [Column("item")]
        public string Item { get; set; } = string.Empty;

        [Column("cantidad")]
        public double Cantidad { get; set; }

        [Required]
        [Column("unidad")]
        public string Unidad { get; set; } = string.Empty;

        [Column("fecha_registro")]
        public DateTime FechaRegistro { get; set; } = DateTime.Now;
    }
}
