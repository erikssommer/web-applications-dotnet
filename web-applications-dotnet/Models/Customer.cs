using System.ComponentModel.DataAnnotations;

namespace web_applications_dotnet.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [RegularExpression(@"^[a-zA-ZæøåÆØÅ. \-]{2,20}$")]
        public string FirstName { get; set; }
        [RegularExpression(@"^[a-zA-ZæøåÆØÅ. \-]{2,20}$")]
        public string LastName { get; set; }
        [RegularExpression(@"[0-9a-zA-ZæøåÆØÅ. \-]{2,50}")]
        public string Address { get; set; }
        [RegularExpression(@"^[0-9]{4}$")]
        public string Postnr { get; set; }
        [RegularExpression(@"^[a-zA-ZæøåÆØÅ. \-]{2,20}$")]
        public string PostOffice { get; set; }
    }
}