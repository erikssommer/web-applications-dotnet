using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace web_applications_dotnet.Models
{
    public sealed class PostOffices
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Postnr { get; set; }
        public string PostOffice { get; set; }
        
        public List<Customers> Customers { get; set; }
    }
}