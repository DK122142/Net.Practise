using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using App.Core.Entity;
using App.DataAccess.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SimpleApi.DataTransfer.ItemsDto;

namespace SimpleApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IRepository<Item> itemRepository;
        private readonly IMapper mapper;

        public ItemController(IRepository<Item> itemRepository, IMapper mapper)
        {
            this.itemRepository = itemRepository;
            this.mapper = mapper;
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var item = await this.itemRepository.GetByIdWithIncludesAsync(
                id,
                new List<Expression<Func<Item, dynamic>>>
                {
                    i => i.Contracts
                });

            if (item == null)
            {
                return NotFound();
            }

            foreach (var itemContract in item.Contracts)
            {
                itemContract.Items = itemContract.Items.Select(i=>new Item
                {
                    Id = i.Id,
                    Name = i.Name
                });
            }

            return new ObjectResult(item);
        }
        
        [HttpPost]
        public async Task<IActionResult> Post(ItemCreateDto item)
        {
            if (ModelState.IsValid)
            {
                var entity = this.mapper.Map<Item>(item);

                await this.itemRepository.CreateAsync(entity);

                return Ok(item);
            }

            return BadRequest(item);
        }
        
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id, ItemDto item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(item);
            }

            if (id != item.Id)
            {
                return BadRequest(item);
            }

            var entity = await this.itemRepository.GetByIdWithIncludesAsync(item.Id, isNoTracking:false);

            if (entity == null)
            {
                return BadRequest(item);
            }

            entity.Cost = item.Cost;
            entity.Description = item.Description;
            entity.Manufacturer = item.Manufacturer;
            entity.Name = item.Name;
            entity.Nds = item.Nds;
            entity.Refrigerate = item.Refrigerate;

            await this.itemRepository.UpdateAsync(entity);

            return Ok(item);
        }
    }
}
