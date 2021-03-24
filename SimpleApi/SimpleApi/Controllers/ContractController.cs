using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using App.Core.Entity;
using App.DataAccess.Repository;
using AutoMapper;
using SimpleApi.DataTransfer.ContractsDto;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SimpleApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractController : ControllerBase
    {
        private readonly IRepository<Contract> contractRepository;
        private readonly IRepository<Customer> customerRepository;
        private readonly IRepository<Delivery> deliveryRepository;
        private readonly IRepository<Item> itemRepository;
        private readonly IMapper mapper;

        public ContractController(IRepository<Contract> contractRepository, IRepository<Customer> customerRepository, IRepository<Delivery> deliveryRepository, IRepository<Item> itemRepository, IMapper mapper)
        {
            this.contractRepository = contractRepository;
            this.customerRepository = customerRepository;
            this.deliveryRepository = deliveryRepository;
            this.itemRepository = itemRepository;
            this.mapper = mapper;
        }

        // GET api/<ContractController>/5
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var contract = await this.contractRepository.GetByIdWithIncludesAsync(
                id,
                new List<Expression<Func<Contract, dynamic>>>
                {
                    c => c.Customer,
                    c => c.Delivery,
                    c => c.Items
                });

            if (contract == null)
            {
                return NotFound();
            }

            foreach (var contractItem in contract.Items)
            {
                contractItem.Contracts = contractItem.Contracts.Select(c => new Contract
                {
                    Id = c.Id,
                    CustomerId = c.CustomerId,
                    DeliveryId = c.DeliveryId
                });
            }

            return new ObjectResult(contract);
        }

        // POST api/<ContractController>
        [HttpPost]
        public async Task<IActionResult> Post(ContractCreateDto contractCreateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(contractCreateDto);
            }

            if (await this.customerRepository.GetByIdWithIncludesAsync(contractCreateDto.CustomerId) == null)
            {
                return BadRequest(contractCreateDto);
            }

            if (await this.deliveryRepository.GetByIdWithIncludesAsync(contractCreateDto.DeliveryId) == null)
            {
                return BadRequest(contractCreateDto);
            }

            var items = new List<Item>();

            foreach (var id in contractCreateDto.ItemId)
            {
                var item = await this.itemRepository.GetByIdWithIncludesAsync(id, isNoTracking:false);

                if (item == null)
                {
                    return BadRequest(contractCreateDto);
                }

                items.Add(item);
            }

            var contractEntity = this.mapper.Map<Contract>(contractCreateDto);

            contractEntity.Items = items;

            await this.contractRepository.CreateAsync(contractEntity);

            return Ok(contractCreateDto);

        }

        // PUT api/<ContractController>/5
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id, ContractCreateDto contractCreateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(contractCreateDto);
            }

            var contractEntity = await this.contractRepository.GetByIdWithIncludesAsync(
                id,
                isNoTracking: false);

            if (contractEntity == null)
            {
                return BadRequest();
            }
            
            if (await this.customerRepository.GetByIdWithIncludesAsync(contractCreateDto.CustomerId) == null)
            {
                return BadRequest(contractCreateDto);
            }

            if (await this.deliveryRepository.GetByIdWithIncludesAsync(contractCreateDto.DeliveryId) == null)
            {
                return BadRequest(contractCreateDto);
            }

            var items = new List<Item>();

            foreach (var itemId in contractCreateDto.ItemId)
            {
                var item = await this.itemRepository.GetByIdWithIncludesAsync(itemId);

                if (item == null)
                {
                    return BadRequest(contractCreateDto);
                }

                items.Add(item);
            }

            contractEntity.Items = new List<Item>();
            contractEntity.Items.ToList().AddRange(items);
            contractEntity.CustomerId = contractCreateDto.CustomerId;
            contractEntity.DeliveryId = contractCreateDto.DeliveryId;

            await this.contractRepository.UpdateAsync(contractEntity);

            return Ok(contractCreateDto);
        }
    }
}
