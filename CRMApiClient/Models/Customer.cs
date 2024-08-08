namespace CRMApiClient.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public string Address { get; set; }
        public string Wohnort { get; set; }
        public int Postleitzahl { get; set; }
        public string EmailAdresse { get; set; }
        public string Telephonenummer { get; set; }
        public DateTime? Erstellungsdatum { get; set; }
        public DateTime? Änderungsdatum { get; set; }
        public string? Interest_Name { get; set; }
    }
}
