using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ukolnicek.Models
{
    [Table("vsechnyukoly")]
    public class Ukol
    {
        [Column("id")]
        public int Id { get; set; } = 0;
        [Required(ErrorMessage = "Zadej název úkolu")]
        [Column("nazev")]
        public string Nazev { get; set; } = "";
        [Required(ErrorMessage = "Zadej datum a čas")]
        [DataType(DataType.DateTime)]
        [Column("datum")]
        public DateTime Datum { get; set; } = DateTime.Now;
        [Column("hotovo")]
        public bool Hotovo { get; set; } = false;
        [Column("smazano")]
        public bool Smazano { get; set; } = false;


    }
}
