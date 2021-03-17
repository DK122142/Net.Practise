using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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
        
        private IRepository<Delivery> repository;
        private IMapper mapper;

        public DeliveryController(IRepository<Delivery> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        // GET api/<DeliveryController>/5
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var delivery = await this.repository.GetByIdWithIncludesAsync(id);

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
            if (delivery == null)
            {
                return BadRequest();
            }

            var entity = this.mapper.Map<Delivery>(delivery);

            await this.repository.CreateAsync(entity);

            return Ok(delivery);
        }

        // PUT api/<DeliveryController>/5
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id, DeliveryDto delivery)
        {
            if (id != delivery.Id)
            {
                return BadRequest();
            }

            var entity = await this.repository.GetByIdWithIncludesAsync(delivery.Id, isNoTracking:false);

            if (entity == null)
            {
                return BadRequest();
            }

            entity.Address = delivery.Address;
            entity.TypeDelivery = (DeliveryType) delivery.TypeDelivery;

            await this.repository.UpdateAsync(entity);

            return Ok(delivery);
        }
    }
}
