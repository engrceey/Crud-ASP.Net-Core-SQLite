using System.ComponentModel.DataAnnotations;

namespace Commander.Dtos
{
    public class CommandReadDto {
        
        public int Id { get; set; }
        [Required]
        [MaxLength(250)]
        public string Howto { get; set; }
        [Required]
        public string Line { get; set; }
    }
}