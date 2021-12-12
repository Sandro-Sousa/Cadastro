using cadastro.domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace cadastro.repository.Interfaces
{
    public interface IProcedure
    {
        Task <List<ClienteEntity>> ClienteGet();
        Task<ClienteEntity> ClienteGetById(int Id);
        Task<ClienteEntity> ClienteInsert(ClienteEntity clienteEntity);
        Task<ClienteEntity> ClienteUpdate(ClienteEntity clienteEntity);
        Task<bool> ClienteDelete(int id);
        Task<EnderecoEntity> EnderecoInsert(EnderecoEntity enderecoEntity);
        Task<TelefoneEntity> TelefoneInsert(TelefoneEntity telefoneEntity);
    }
}
