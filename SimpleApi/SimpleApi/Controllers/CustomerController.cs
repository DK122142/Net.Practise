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
        private IRepository<Customer> repository;
        private IMapper mapper;

        public CustomerController(IRepository<Customer> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var customer = await this.repository.GetByIdWithIncludesAsync(id);

            if (customer == null)
            {
                return NotFound();
            }

            // var resultCustomer = this.mapper.Map<CustomerDto>(customer);

            return new ObjectResult(customer);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CustomerCreateDto customer)
        {
            if (customer == null)
            {
                return BadRequest();
            }

            var customerEntity = this.mapper.Map<Customer>(customer);

            await this.repository.CreateAsync(customerEntity);

            return Ok(customer);
        }
        
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id, CustomerDto customer)
        {
            if (id != customer.Id)
            {
                return BadRequest();
            }

            var customerEntity = await this.repository.GetByIdWithIncludesAsync(customer.Id, isNoTracking:false);

            if (customerEntity == null)
            {
                return BadRequest();
            }

            customerEntity.Email = customer.Email;
            customerEntity.FullName = customer.FullName;
            customerEntity.PhoneNumber = customer.PhoneNumber;

            await this.repository.UpdateAsync(customerEntity);

            return Ok(customer);
        }
    }
}
