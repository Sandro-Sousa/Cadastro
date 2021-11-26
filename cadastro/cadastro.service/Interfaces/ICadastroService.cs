using cadastro.domain.Entities;
using System.Threading.Tasks;
using static cadastro.service.DTOs.ControllerCadastroDTO;

namespace cadastro.service.Interfaces
{
    public interface ICadastroService
    {
        Task<ClienteEntity> ClientInsertService(ClienteEntity clienteEntity);
        Task<ClienteEntity> ClientGetByIdService(int Id);
        Task<EnderecoEntity> EnderecoInsertService(EnderecoEntity enderecoEntity);
        Task<TelefoneEntity> TelefoneInsertService(TelefoneEntity telefoneEntity);
    }
}
