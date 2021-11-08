using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace frutosecoapp.Models
{
    [Table("t_order_detail")]
    public class DetallePedido
    {    
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int ID {get; set;}

        public Product Producto {get; set;}

        public int Quantity{get; set;}
        public Decimal Price { get; set; }
        public Pedido pedido {get; set;}

        
    }
}