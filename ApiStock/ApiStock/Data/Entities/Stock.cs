using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiStock.Data.Entities
{
    public class Stock
    {
        [Required]
        public int ID { get; set; }
        [Required]
        public int CodProducto { get; set; }
        [Required]
        public string Producto { get; set; }
        public string Descripcion { get; set; }
    }
}
