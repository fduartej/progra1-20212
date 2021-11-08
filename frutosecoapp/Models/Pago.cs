using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace frutosecoapp.Models
{
    //CARRITO
    [Table("t_pago")]
    public class Pago
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }
        public DateTime PaymentDate { get; set; }
        public String NombreTarjeta { get; set; }
        
        public String NumeroTarjeta { get; set; }
        
        [NotMapped]
        public String DueDateYYMM { get; set; }
        [NotMapped]
        public String Cvv { get; set; }
        public Decimal MontoTotal{ get; set; }
        public String UserID{ get; set; }
  
    }
}