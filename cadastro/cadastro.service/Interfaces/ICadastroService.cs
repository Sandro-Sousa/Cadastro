using cadastro.domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using static cadastro.service.DTOs.ControllerCadastroDTO;

namespace cadastro.service.Interfaces
{
    public interface ICadastroService
    {
        Task<List<ClienteDTO>> ClienteGetAllService();
        Task<ClienteDTO> ClienteGetByIdService(int Id);
        Task<ClienteDTOInsert> ClienteInsertService(ClienteDTOInsert clienteEntity);
        Task<ClienteDTO> ClienteUpdateService(ClienteDTO clienteDTO);
        Task<bool> ClienteDeleteService(int Id);
        Task<EnderecoEntity> EnderecoInsertService(EnderecoEntity enderecoEntity);
        Task<TelefoneEntity> TelefoneInsertService(TelefoneEntity telefoneEntity);
    }
}
