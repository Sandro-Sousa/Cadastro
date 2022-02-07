using cadastro.service.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace cadastro.service.Interfaces
{
  public interface ICadastroService
  {
    Task<List<ClienteDTO>> ClienteGetAll();
    Task<ClienteDTO> ClienteGetById(int Id);
    Task<ClienteDTOInsert> ClienteInsert(ClienteDTOInsert clienteEntity);
    Task<ClienteDTO> ClienteUpdate(ClienteDTO clienteDTO);
    Task<bool> ClienteDelete(int Id);
    Task<EnderecoDTOInsert> EnderecoInsert(EnderecoDTOInsert enderecoEntity);
    Task<List<EnderecoDTO>> EnderecosGetAllByIdCliente(int Id);
    Task<bool> EnderecoDelete(int id);
    Task<List<TelefoneDTO>> TelefoneGetAll();
    Task<List<TelefoneDTO>> TelefonesGetAllByIdCliente(int Id);
    Task<TelefoneDTOInsert> TelefoneInsert(TelefoneDTOInsert telefoneEntity);
    Task<bool> TelefoneDelete(int id);
    Task<List<EmailDTO>> EmailsGetAllByIdCliente(int Id);
    Task<EmailDTOInsert> EmailInsert(EmailDTOInsert emailEntity);
    Task<bool> EmailDelete(int id);
  }
}
