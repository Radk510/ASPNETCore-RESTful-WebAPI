using System.ComponentModel.DataAnnotations;

namespace CommandWebApi.DTOs
{
    public class CommandUpdateDto
    {
        [Required]
        public string HowTo { get; set; }
        
        [Required]
        public string Line { get; set; }

        [Required]
        public string Platform { get; set; }
    }
}