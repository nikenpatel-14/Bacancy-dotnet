using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssignmeentWebApi.DTOs
{
    public class UserLoginDTO
    {
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string Name { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
