using cadastro.domain.Entities;
using cadastro.repository.Interfaces;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace cadastro.repository
{
  public class CadastroRepository : ICadastroRepository
  {
    private string _connectionString;

    public CadastroRepository()
    {
      this._connectionString = velesemail.cross.AppSettings.GetConnectionString("Cadastro");
    }

    public async Task<List<Cliente>> ClienteGet()
    {

      var resultado = new List<Cliente>();

      using (SqlConnection db = new SqlConnection(this._connectionString))
      {
        var result = await db.QueryAsync<Cliente>(
            "[ClienteGet]",
            commandType: CommandType.StoredProcedure);

        if (result != null)
        {
          resultado = result.ToList<Cliente>();
        }
      }
      return (resultado);
    }

    public async Task<Cliente> ClienteGetById(int Id)
    {
      var parametros = new DynamicParameters();

      parametros.Add(@"IdCliente", Id, DbType.Int32, ParameterDirection.Input, null);

      using (SqlConnection db = new SqlConnection(this._connectionString))
      {
        var result = await db.QueryAsync<Cliente>(
            "[ClienteGetById]",
            parametros,
            commandType: CommandType.StoredProcedure);

        return result != null ? result.ToList().FirstOrDefault() : null;
      }
    }

    public async Task<Cliente> ClienteInsert(Cliente clienteEntity)
    {
      var retorno = new Cliente();
      var list = new List<Cliente>();
      var parametros = new DynamicParameters();

      try
      {
        parametros.Add("@Nome", clienteEntity.Nome, DbType.String, ParameterDirection.Input, null);
        parametros.Add("@Cpf", clienteEntity.Cpf, DbType.String, ParameterDirection.Input, null);

        using (SqlConnection db = new SqlConnection(this._connectionString))
        {
          var result = await db.QueryAsync<Cliente>(
              "[ClienteInsert]",
              parametros,
              commandType: CommandType.StoredProcedure);

          if (result != null)
          {
            list = result.ToList<Cliente>();
          }
        }

        if ((list != null) &&
            (list.Count > 0))
        {
          retorno = list.First();
        }

        return retorno;
      }
      catch (Exception ex)
      {

        throw new Exception(ex.Message);
      }

    }

    public async Task<Cliente> ClienteUpdate(Cliente clienteEntity)
    {
      var retorno = new Cliente();
      var list = new List<Cliente>();
      var parametros = new DynamicParameters();

      try
      {
        parametros.Add("@IdCliente", clienteEntity.IdCliente, DbType.Int32, ParameterDirection.Input, null);
        parametros.Add("@Nome", clienteEntity.Nome, DbType.String, ParameterDirection.Input, null);
        parametros.Add("@Cpf", clienteEntity.Cpf, DbType.String, ParameterDirection.Input, null);

        using (SqlConnection db = new SqlConnection(this._connectionString))
        {
          var result = await db.QueryAsync<Cliente>(
              "[ClienteUpdate]",
              parametros,
              commandType: CommandType.StoredProcedure);

          if (result != null)
          {
            list = result.ToList<Cliente>();
          }
        }

        if ((list != null) &&
            (list.Count > 0))
        {
          retorno = list.First();
        }

        return retorno;
      }
      catch (Exception ex)
      {

        throw new Exception(ex.Message);
      }
    }

    public async Task<bool> ClienteDelete(int Id)
    {
      if (Id < 0)
      {
        return false;
      }
      var parametros = new DynamicParameters();

      parametros.Add(@"IdCliente", Id, DbType.Int32, ParameterDirection.Input, null);

      using (SqlConnection db = new SqlConnection(this._connectionString))
      {
        var result = await db.QueryAsync<Cliente>(
            "[ClienteDelete]",
            parametros,
            commandType: CommandType.StoredProcedure);
      }
      return true;
    }

    public async Task<Endereco> EnderecoInsert(Endereco enderecoEntity)
    {
      var retorno = new Endereco();
      var list = new List<Endereco>();
      var parametros = new DynamicParameters();

      try
      {
        parametros.Add("@Logradouro", enderecoEntity.Logradouro, DbType.String, ParameterDirection.Input, null);
        parametros.Add("@Bairro", enderecoEntity.Bairro, DbType.String, ParameterDirection.Input, null);
        parametros.Add("@Cidade", enderecoEntity.Cidade, DbType.String, ParameterDirection.Input, null);
        parametros.Add("@Uf", enderecoEntity.Uf, DbType.String, ParameterDirection.Input, null);
        parametros.Add("@IdCliente", enderecoEntity.IdCliente, DbType.Int32, ParameterDirection.Input, null);

        using (SqlConnection db = new SqlConnection(this._connectionString))
        {
          var result = await db.QueryAsync<Endereco>(
              "[EnderecoInsert]",
              parametros,
              commandType: CommandType.StoredProcedure);

          if (result != null)
          {
            list = result.ToList<Endereco>();
          }
        }

        if ((list != null) &&
            (list.Count > 0))
        {
          retorno = list.First();
        }

        return retorno;
      }
      catch (Exception ex)
      {

        throw new Exception(ex.Message);
      }
    }

    public async Task<Telefone> TelefoneInsert(Telefone telefoneEntity)
    {
      var retorno = new Telefone();
      var list = new List<Telefone>();
      var parametros = new DynamicParameters();

      try
      {
        parametros.Add("@Numero", telefoneEntity.Numero, DbType.String, ParameterDirection.Input, null);

        parametros.Add("@IdCliente", telefoneEntity.IdCliente, DbType.Int32, ParameterDirection.Input, null);

        using (SqlConnection db = new SqlConnection(this._connectionString))
        {
          var result = await db.QueryAsync<Telefone>(
              "[TelefoneInsert]",
              parametros,
              commandType: CommandType.StoredProcedure);

          if (result != null)
          {
            list = result.ToList<Telefone>();
          }
        }

        if ((list != null) &&
            (list.Count > 0))
        {
          retorno = list.First();
        }

        return retorno;
      }
      catch (Exception ex)
      {

        throw new Exception(ex.Message);
      }
    }
  }
}
