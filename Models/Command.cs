using System.ComponentModel.DataAnnotations;

namespace CommandWebApi.Models
{
    public class Command
    {
        public int Id { get; set; } // nere is new branch 

        [Required]
        public string HowTo { get; set; }
        
        [Required]
        public string Line { get; set; }

        [Required]
        public string Platform { get; set; }
    }
}