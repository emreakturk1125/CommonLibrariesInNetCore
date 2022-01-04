using AutoMapper;
using NetCoreLibraries.AutoMapper.Web.DTOs;
using NetCoreLibraries.AutoMapper.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreLibraries.AutoMapper.Web.Mapping
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            //CreateMap<Customer, CustomerDto>();
            //CreateMap<CustomerDto, Customer>();

            CreateMap<Customer, CustomerDto>()
                .ForMember(dest => dest.CCValidDate,opt => opt.MapFrom(x => x.CreditCard.ValidDate))
                .ReverseMap(); // Üstteki ile aynı işe yarar

            // Aşağıdaki gibi bir manuel mapping önerilmez örnek amaçlı yaptık, Mapping yapılacak classların property name leri aynı olursa daha performanslı olur

            CreateMap<Customer, CustomerDtoT>()
                .ForMember(dest => dest.Isim, opt => opt.MapFrom(x => x.Name))  // Classlar içideki property isimleri farklı ise bu şekilde  belirtilmesi gerekir.
                .ForMember(dest => dest.Eposta, opt => opt.MapFrom(x => x.Email))
                .ForMember(dest => dest.Yas, opt => opt.MapFrom(x => x.Age))
                .ForMember(dest => dest.TumAd2, opt => opt.MapFrom(x => x.TumAd2()));  // metod eşlemesi

        }
    }
}
