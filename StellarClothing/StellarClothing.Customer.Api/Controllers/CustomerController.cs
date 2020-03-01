using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StellarClothing.Customer.Api.Domain.CustomerAggregate;

namespace StellarClothing.Customer.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ILogger<CustomerController> _logger;

        public CustomerController(
            ICustomerRepository customerRepository,
            ILogger<CustomerController> logger)
        {
            _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        // GET api/customers
        [HttpGet]
        public async Task<IEnumerable<Domain.CustomerAggregate.Customer>> Get()
        {
            _logger.LogDebug("Getting all customers");
            return await _customerRepository.GetAll();
        }

        // GET api/customers/5
        [HttpGet("{id}")]
        public async Task<Domain.CustomerAggregate.Customer> Get(int id)
        {
            _logger.LogDebug($"Returning customer with id '{id}'");

            return await _customerRepository.GetByID(id);
        }

        // POST api/customers
        [HttpPost]
        public async Task Post([FromBody]Domain.CustomerAggregate.Customer value)
        {
            await _customerRepository.Add(value);
        }

        // PUT api/customers/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody]Domain.CustomerAggregate.Customer value)
        {
            var customer = Get(id);
            if(customer != null)
                await _customerRepository.Update(value);
        }

        // DELETE api/customers/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            var customer = Get(id);
            if (customer != null)
                await _customerRepository.Delete(id);
        }
    }
}