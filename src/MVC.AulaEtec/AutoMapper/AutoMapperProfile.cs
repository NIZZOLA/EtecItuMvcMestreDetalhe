using AutoMapper;
using MVC.AulaEtec.Models;
using MVC.AulaEtec.ViewModel;

namespace MVC.AulaEtec.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ClienteFullViewModel, ClienteModel>();
            CreateMap<ClienteFullViewModel, ClienteEnderecoModel>();
        }
    }
}
