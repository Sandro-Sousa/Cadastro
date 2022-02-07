using AutoMapper;
using cadastro.domain;
using cadastro.domain.Entities;
using cadastro.service.DTOs;

namespace cadastro.service.Helpers
{
  public class CadastroProfile : Profile
  {
    public CadastroProfile()
    {
      CreateMap<Cliente, ClienteDTO>().ReverseMap();
      CreateMap<Cliente, ClienteDTOInsert>().ReverseMap();
      CreateMap<Endereco, EnderecoDTO>().ReverseMap();
      CreateMap<Endereco, EnderecoDTOInsert>().ReverseMap();
      CreateMap<Telefone, TelefoneDTO>().ReverseMap();
      CreateMap<Telefone, TelefoneDTOInsert>().ReverseMap();
      CreateMap<Email, EmailDTOInsert>().ReverseMap();
    }
  }
}
