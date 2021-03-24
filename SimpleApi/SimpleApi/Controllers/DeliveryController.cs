using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using App.Core.Entity;
using App.Core.Enumeration;
using App.DataAccess.Repository;
using AutoMapper;
using SimpleApi.DataTransfer.DeliveriesDto;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SimpleApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveryController : ControllerBase
    {
        
        private readonly IRepository<Delivery> deliveryRepository;
        private readonly IMapper mapper;

        public DeliveryController(IRepository<Delivery> deliveryRepository, IMapper mapper)
        {
            this.deliveryRepository = deliveryRepository;
            this.mapper = mapper;
        }

        // GET api/<DeliveryController>/5
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var delivery = await this.deliveryRepository.GetByIdWithIncludesAsync(id);

            if (delivery == null)
            {
                return NotFound();
            }

            return new ObjectResult(delivery);
        }

        // POST api/<DeliveryController>
        [HttpPost]
        public async Task<IActionResult> Post(DeliveryCreateDto delivery)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(delivery);
            }

            var entity = this.mapper.Map<Delivery>(delivery);

            await this.deliveryRepository.CreateAsync(entity);

            return Ok(delivery);
        }

        // PUT api/<DeliveryController>/5
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id, DeliveryDto delivery)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(delivery);
            }

            if (id != delivery.Id)
            {
                return BadRequest();
            }

            var entity = await this.deliveryRepository.GetByIdWithIncludesAsync(delivery.Id, isNoTracking:false);

            if (entity == null)
            {
                return BadRequest();
            }

            entity.Address = delivery.Address;
            entity.TypeDelivery = (DeliveryType) delivery.TypeDelivery;

            await this.deliveryRepository.UpdateAsync(entity);

            return Ok(delivery);
        }
    }
}
