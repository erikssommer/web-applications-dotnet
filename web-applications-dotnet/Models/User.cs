using System.ComponentModel.DataAnnotations;

namespace web_applications_dotnet.Models
{
    public class User
    {
        [RegularExpression(@"^[a-zA-ZæøåÆØÅ. \-]{2,20}$")]
        public string Username { get; set; }
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{6,}$")]
        public string Password { get; set; }
    }
}