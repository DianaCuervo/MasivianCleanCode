using System.ComponentModel.DataAnnotations;

namespace RouletteApi.DTOs
{
    public class RouletteUpdateDTO
    {
        [Required]
        public string State { get; set; }
        public string Bets { get; set; }
    }
}