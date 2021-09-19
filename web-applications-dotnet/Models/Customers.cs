namespace web_applications_dotnet.Models
{
    public sealed class Customers
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public PostOffices PostOffice { get; set; }
    }
}