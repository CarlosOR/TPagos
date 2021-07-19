using AutoMapper;
using Tuya.Pagos.Models.Dtos;
using Tuya.Pagos.Models.Entities;

namespace Tuya.Pagos.Startapp
{
    public class GeneralMapper: Profile
    {
        public GeneralMapper()
        {
            CreateMap<DtoProducts, Product>()
                .ForMember(p => p.IdProduct, p => p.MapFrom(p => p.IdProducto))
                .ForMember(p => p.Price, p => p.MapFrom(p => p.Price))
                .ForMember(p => p.Name, p => p.MapFrom(p => p.Name))
                .ReverseMap();
        }
    }
}
