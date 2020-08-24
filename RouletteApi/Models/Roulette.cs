using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RouletteApi.Models
{
    public class Roulette
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string Bets { get; set; }
    }
}