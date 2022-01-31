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
    Task<EnderecoDTO> EnderecoInsert(EnderecoDTO enderecoEntity);
    Task<List<TelefoneDTO>> TelefoneGetAll();
    Task<List<TelefoneDTO>> TelefonesGetAllByIdCliente(int Id);
    Task<TelefoneDTO> TelefoneInsert(TelefoneDTO telefoneEntity);
    Task<bool> TelefoneDelete(int id);
  }
}
