using AutoMapper;
using cadastro.domain.Entities;
using static cadastro.service.DTOs.ControllerCadastroDTO;

namespace cadastro.service.Helpers
{
    public class CadastroProfile : Profile
    {
        public CadastroProfile()
        {
            CreateMap<ClienteEntity, ClienteDTO>().ReverseMap();
            CreateMap<EnderecoEntity, EnderecoDTO>().ReverseMap();
            CreateMap<TelefoneEntity, TelefoneDTO>().ReverseMap();
        }
    }
}
