using cadastro.domain.Entities;
using System.Threading.Tasks;

namespace cadastro.repository.Interfaces
{
    public interface IProcedure
    {
        Task<ClienteEntity> ClientInsert(ClienteEntity clienteEntity);
        Task<ClienteEntity> ClientGetById(int Id);
        Task<EnderecoEntity> EnderecoInsert(EnderecoEntity enderecoEntity);
        Task<TelefoneEntity> TelefoneInsert(TelefoneEntity telefoneEntity);
    }
}
