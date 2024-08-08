using CRMApiClient.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRMApiClient.Controllers
{
    // Controller zur Bearbeitung von HTTP-Anfragen für Kundenvorgänge
    public class CustomersController : Controller
    {
        private readonly HttpClient _httpClient;

        public CustomersController(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://localhost:44394/api/");
        }

        // Aktion zur Auflistung aller Kunden
        public async Task<IActionResult> Index()
        {
            var CustomersData = await _httpClient.GetFromJsonAsync<List<Customer>>("customers/LoadAllCustomerRecords");
            if (CustomersData == null)
            {
                return NotFound("There are no Customers");
            }
            return View(CustomersData);
        }

        // Aktion zur Anzeige von Details zu einem bestimmten Kunden
        public async Task<IActionResult> Details(int id)
        {
            var CustomerData = await _httpClient.GetFromJsonAsync<Customer>($"customers/LoadCustomerById/id/{id}");
            if (CustomerData == null)
                return NotFound();

            return View(CustomerData);
            

        }

        // Aktion zur Anzeige des Formulars "Kunden anlegen" (GET)
        [HttpGet]
        public async Task<IActionResult> CreateCustomer()
        {
            return View();
        }

        // Aktion für die Übermittlung des Formulars "Kunden anlegen" (POST)
        [HttpPost]
        public async Task<IActionResult> CreateCustomer(Customer customerModel)
        {

            if (ModelState.IsValid)
            {
                var OperationResult = await _httpClient.PostAsJsonAsync("customers/RegisterNewCustomer", customerModel);
                if (OperationResult.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                
            }
            return View();
        }


        // Aktion zur Anzeige des Formulars zum Bearbeiten von Kunden (GET)
        public async Task<IActionResult> Edit(int id)
        {
            var CustomerData = await _httpClient.GetFromJsonAsync<Customer>($"customers/LoadCustomerById/id/{id}");
            if (CustomerData == null)
            {
                return NotFound();
            }
            return View(CustomerData);
        }

        // Aktion für die Übermittlung des Formulars zum Bearbeiten von Kunden (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Customer customerModel)
        {
            if (id != customerModel.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                var result = await _httpClient.PutAsJsonAsync($"customers/UpdateCurrentCustomer/{id}", customerModel);
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(customerModel);
        }

        // Aktion zur Anzeige der Kundenlöschbestätigung (GET)
        public async Task<IActionResult> Delete(int id)
        {
            var CustomerData = await _httpClient.GetFromJsonAsync<Customer>($"customers/LoadCustomerById/id/{id}");
            if (CustomerData == null)
            {
                return NotFound();
            }
            return View(CustomerData);

        }

        // Aktion für die Übermittlung des Formulars zum Löschen von Kunden (POST)
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var result = await _httpClient.DeleteAsync($"customers/DeleteCustomerById/id/{id}");
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                var CustomerData = await _httpClient.GetFromJsonAsync<Customer>($"customers/LoadCustomerById/id/{id}");
                return View(CustomerData);
            }

        }
    }
}
