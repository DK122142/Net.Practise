using System.Threading.Tasks;
using App.Core.Entity;
using App.DataAccess.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SimpleApi.DataTransfer.CustomersDto;

namespace SimpleApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IRepository<Customer> customerRepository;
        private readonly IMapper mapper;

        public CustomerController(IRepository<Customer> customerRepository, IMapper mapper)
        {
            this.customerRepository = customerRepository;
            this.mapper = mapper;
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var customer = await this.customerRepository.GetByIdWithIncludesAsync(id);

            if (customer == null)
            {
                return NotFound();
            }
            
            return new ObjectResult(customer);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CustomerCreateDto customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(customer);
            }

            var customerEntity = this.mapper.Map<Customer>(customer);

            await this.customerRepository.CreateAsync(customerEntity);

            return Ok(customer);
        }
        
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id, CustomerDto customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(customer);
            }

            if (id != customer.Id)
            {
                return BadRequest(customer);
            }

            var customerEntity = await this.customerRepository.GetByIdWithIncludesAsync(customer.Id, isNoTracking:false);

            if (customerEntity == null)
            {
                return BadRequest();
            }

            customerEntity.Email = customer.Email;
            customerEntity.FullName = customer.FullName;
            customerEntity.PhoneNumber = customer.PhoneNumber;

            await this.customerRepository.UpdateAsync(customerEntity);

            return Ok(customer);
        }
    }
}
