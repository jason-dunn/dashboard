using System.ComponentModel.DataAnnotations;

namespace dashoard
{
    public class CodeFormModel
    {
        [Required]
        [MaxLength(6)]
        public string? Code { get; set; }

        [Required]
        [MaxLength(50)]
        public string? Token { get; set; }


    }
}

