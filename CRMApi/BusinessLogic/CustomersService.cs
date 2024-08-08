using CRMApi.DBContext;
using CRMApi.Models;

namespace CRMApi.BusinessLogic
{
    public class CustomersService
    {
        // Dependency Injection für den Datenbankkontext
        private readonly ApplicationDbContext _dBContext;

        public CustomersService(ApplicationDbContext dBContext)
        {
            _dBContext = dBContext;
        }

        // Methode zum Abrufen aller Kunden aus der Datenbank
        public List<Customer> GetAllCustomers()
        {
            return _dBContext.customers.ToList();
        }

        // Methode zur Ermittlung eines einzelnen Kunden anhand seiner ID
        public Customer GetCustomerById(int id)
        {
            return _dBContext.customers.FirstOrDefault(x=>x.Id ==id); 
            
        }

        // Methode zur Ermittlung eines Kunden anhand seines Vor- oder Nachnamens
        public Customer GetCustomerByName(string name)
        {
            return _dBContext.customers.FirstOrDefault(x => x.Vorname == name || x.Nachname == name);
        }

        // Methode zum Hinzufügen eines neuen Kunden in die Datenbank
        public void AddCustomer (Customer customer)
        { 
            _dBContext.customers.Add(customer);
            _dBContext.SaveChanges();
        }

        // Methode zur Aktualisierung der Daten eines bestehenden Kunden
        public void UpdateCustomer(Customer customer)
        {
            var customerToUpdate = _dBContext.customers.Find(customer.Id);
            if (customerToUpdate != null)
            {
                customerToUpdate.Vorname = customer.Vorname;
                customerToUpdate.Nachname= customer.Nachname;
                customerToUpdate.Address = customer.Address;
                customerToUpdate.Wohnort = customer.Wohnort;
                customerToUpdate.Postleitzahl = customer.Postleitzahl;
                customerToUpdate.EmailAdresse = customer.EmailAdresse;
                customerToUpdate.Telephonenummer = customer.Telephonenummer;
                customerToUpdate.Änderungsdatum = DateTime.Now;
                customerToUpdate.Interest_Name = customer.Interest_Name;
            }
            _dBContext.SaveChanges ();
        }

        // Methode zum Löschen eines Kunden aus der Datenbank anhand seiner ID
        public void DeleteCustomer(int id)
        {
            var Customer = _dBContext.customers.FirstOrDefault(x=>x.Id == id);
            if (Customer != null)
            {
                _dBContext.customers.Remove(Customer);
                _dBContext.SaveChanges();
            }
        }
    }
}
