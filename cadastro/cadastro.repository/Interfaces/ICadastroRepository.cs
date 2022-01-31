using cadastro.domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace cadastro.repository.Interfaces
{
  public interface ICadastroRepository
  {
    Task<List<Cliente>> ClienteGetAll();
    Task<Cliente> ClienteGetById(int Id);
    Task<Cliente> ClienteInsert(Cliente clienteEntity);
    Task<Cliente> ClienteUpdate(Cliente clienteEntity);
    Task<bool> ClienteDelete(int id);
    Task<Endereco> EnderecoInsert(Endereco enderecoEntity);
    Task<List<Telefone>> TelefoneGetAll();
    Task<List<Telefone>> TelefonesGetAllByIdCliente(int Id);
    Task<Telefone> TelefoneInsert(Telefone telefoneEntity);
    Task<bool> TelefoneDelete(int id);
  }
}
