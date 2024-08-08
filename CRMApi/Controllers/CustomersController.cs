using CRMApi.BusinessLogic;
using CRMApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRMApi.Controllers
{
    // Customers controller class für die Bearbeitung von API-Anfragen
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {

        private readonly CustomersService _customersService;

        public CustomersController(CustomersService customersService)
        {
            _customersService = customersService;
        }

        // GET: api/customers
        [HttpGet]
        public ActionResult<IEnumerable<Customer>> LoadAllCustomerRecords()
        {
            var CustomerRecords = _customersService.GetAllCustomers();
            if (CustomerRecords == null)
            {
                return NoContent();
            }
            else
            {
                return CustomerRecords;
            }
        }

        // GET: api/customers/id/{id}
        [HttpGet("id/{id}")]
        public ActionResult<Customer> LoadCustomerById(int id)
        {
            var CustomerRecord = _customersService.GetCustomerById(id);
            if (CustomerRecord != null)
            {
                return Ok(CustomerRecord);
            }
            else
            {
                return NotFound($"There are no CustomerRecord with This Id:{id}");

            }

        }

        // GET: api/customers/name/{name}
        [HttpGet("name/{name}")]
        public ActionResult<Customer> LoadCustomerByName(string name)
        {
            var CustomerRecord = _customersService.GetCustomerByName(name);
            if (CustomerRecord != null)
            {
                return Ok(CustomerRecord);
            }
            else
            {
                return NotFound($"There are no CustomerRecord with This Name:{name}");

            }
        }

        // POST: api/customers
        [HttpPost]
        public ActionResult<Customer> RegisterNewCustomer(Customer customer)
        {
            if (customer == null)
            {
                return BadRequest("Customer Data is null, Please add The Data");
            }
            else
            {
                _customersService.AddCustomer(customer);
                return CreatedAtAction(nameof(RegisterNewCustomer), new { id = customer.Id }, customer);
            }
            
        }

        // PUT: api/customers/{id}
        [HttpPut("{id}")]
        public ActionResult<Customer> UpdateCurrentCustomer(int id, Customer customerModel)
        {
            if (customerModel==null)
            {
                return BadRequest();
            }
            if (id == customerModel.Id)
            {
                _customersService.UpdateCustomer(customerModel);
                return Ok(customerModel);   
            }
            else
            {
                return BadRequest();
            }

           
        }

        // DELETE: api/customers/id/{id}
        [HttpDelete("id/{id}")]
        public ActionResult<Customer> DeleteCustomerById(int id)
        {
            _customersService.DeleteCustomer(id);
            return Ok();
        }

    }
}
