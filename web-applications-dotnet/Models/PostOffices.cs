using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace web_applications_dotnet.Models
{
    public class PostOffices
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Postnr { get; set; }
        public string PostOffice { get; set; }
        
        public virtual List<Customers> Customers { get; set; }
    }
}