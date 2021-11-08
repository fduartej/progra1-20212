using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace demomvc.Models
{
    [Table("t_contacto")]
    public class Contacto
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }
        [Column("email")]
        public string Email { get; set; }
        [Column("phone")]
        public string Phone { get; set; }
        [Column("name")]
        public string Name {get; set;}
        [Column("comment")]
        public string Comment {get; set; }     
        public DateTime BirthDate { get; set; }
        [Column("gender")]
        public string Gender { get; set; }

    }
}