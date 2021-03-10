using System.Linq;
using AutoMapper;
using PhoneBook.Models;
using PhoneBook.ViewModels;

namespace PhoneBook.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserViewModel>()
                .ForMember(vm => vm.PhoneNumbers, c => c.MapFrom(u => u.PhoneNumbers.Select(pn => pn.Number)))
                .ReverseMap();

            CreateMap<PhoneNumber, PhoneNumberViewModel>()
                .ForMember(vm => vm.Status, c => c.MapFrom(pn => pn.Status.StatusType))
                .ForMember(vm=>vm.CreatorId,c=>c.MapFrom(pn=>pn.Creator.Id))
                .ReverseMap();


        }
    }
}
