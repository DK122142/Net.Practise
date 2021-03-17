using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using App.Core.Entity;
using App.DataAccess.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SimpleApi.DataTransfer.DeliveriesDto;
using SimpleApi.DataTransfer.ItemsDto;

namespace SimpleApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private IRepository<Item> repository;
        private IMapper mapper;

        public ItemController(IRepository<Item> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var item = await this.repository.GetByIdWithIncludesAsync(
                id,
                new List<Expression<Func<Item, dynamic>>>
                {
                    i=>i.Contracts
                });

            if (item == null)
            {
                return NotFound();
            }

            return new ObjectResult(item);
        }
        
        [HttpPost]
        public async Task<IActionResult> Post(ItemCreateDto item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            var entity = this.mapper.Map<Item>(item);

            await this.repository.CreateAsync(entity);

            return Ok(item);
        }
        
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id, ItemDto item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }

            var entity = await this.repository.GetByIdWithIncludesAsync(item.Id, isNoTracking:false);

            if (entity == null)
            {
                return BadRequest();
            }

            entity.Cost = item.Cost;
            entity.Description = item.Description;
            entity.Manufacturer = item.Manufacturer;
            entity.Name = item.Name;
            entity.Nds = item.Nds;
            entity.Refrigerate = item.Refrigerate;

            await this.repository.UpdateAsync(entity);

            return Ok(item);
        }
    }
}
