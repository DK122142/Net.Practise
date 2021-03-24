using App.Core.Entity;
using AutoMapper;
using SimpleApi.DataTransfer.ContractsDto;
using SimpleApi.DataTransfer.CustomersDto;
using SimpleApi.DataTransfer.DeliveriesDto;
using SimpleApi.DataTransfer.ItemsDto;

namespace SimpleApi.MappingProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ContractCreateDto, Contract>()
                .ReverseMap();

            CreateMap<CustomerCreateDto, Customer>()
                .Include<CustomerDto, Customer>()
                .ReverseMap();

            CreateMap<CustomerDto, Customer>()
                .ReverseMap();

            CreateMap<DeliveryCreateDto, Delivery>()
                .Include<DeliveryDto, Delivery>()
                .ReverseMap();

            CreateMap<DeliveryDto, Delivery>()
                .ReverseMap();

            CreateMap<ItemCreateDto, Item>()
                .Include<ItemDto, Item>()
                .ReverseMap();

            CreateMap<ItemDto, Item>()
                .ReverseMap();
        }   
    }
}
