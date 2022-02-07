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

    public async Task<List<Cliente>> ClienteGetAll()
    {

      var resultado = new List<Cliente>();

      using (SqlConnection db = new SqlConnection(this._connectionString))
      {
        var result = await db.QueryAsync<Cliente>(
            "[ClienteGetAll]",
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

      parametros.Add(@"ClienteId", Id, DbType.Int32, ParameterDirection.Input, null);

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
        parametros.Add("@ClienteId", clienteEntity.ClienteId, DbType.Int32, ParameterDirection.Input, null);
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

      parametros.Add(@"ClienteId", Id, DbType.Int32, ParameterDirection.Input, null);

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
        parametros.Add("@ClienteId", enderecoEntity.ClienteId, DbType.Int32, ParameterDirection.Input, null);

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

    public async Task<List<Endereco>> EnderecosGetAllByIdCliente(int Id)
    {
      var parametros = new DynamicParameters();
      var resultado = new List<Endereco>();

      parametros.Add(@"ClienteId", Id, DbType.Int32, ParameterDirection.Input, null);

      using (SqlConnection db = new SqlConnection(this._connectionString))
      {
        var result = await db.QueryAsync<Endereco>(
            "[EnderecosGetAllByIdCliente]",
            parametros,
            commandType: CommandType.StoredProcedure);

        if (result != null)
        {
          resultado = result.ToList<Endereco>();
        }
      }
      return (resultado);
    }

    public async Task<bool> EnderecoDelete(int Id)
    {
      if (Id < 0)
      {
        return false;
      }
      var parametros = new DynamicParameters();

      parametros.Add(@"EnderecoId", Id, DbType.Int32, ParameterDirection.Input, null);

      using (SqlConnection db = new SqlConnection(this._connectionString))
      {
        var result = await db.QueryAsync<Endereco>(
            "[EnderecoDelete]",
            parametros,
            commandType: CommandType.StoredProcedure);
      }
      return true;
    }

    public async Task<List<Telefone>> TelefoneGetAll()
    {
      var resultado = new List<Telefone>();

      using (SqlConnection db = new SqlConnection(this._connectionString))
      {
        var result = await db.QueryAsync<Telefone>(
            "[TelefoneGetAll]",
            commandType: CommandType.StoredProcedure);

        if (result != null)
        {
          resultado = result.ToList<Telefone>();
        }
      }
      return (resultado);
    }

    public async Task<List<Telefone>> TelefonesGetAllByIdCliente(int Id)
    {
      var parametros = new DynamicParameters();
      var resultado = new List<Telefone>();

      parametros.Add(@"ClienteId", Id, DbType.Int32, ParameterDirection.Input, null);

      using (SqlConnection db = new SqlConnection(this._connectionString))
      {
        var result = await db.QueryAsync<Telefone>(
            "[TelefonesGetAllByIdCliente]",
            parametros,
            commandType: CommandType.StoredProcedure);

        if (result != null)
        {
          resultado = result.ToList<Telefone>();
        }
      }
      return (resultado);
    }

    public async Task<Telefone> TelefoneInsert(Telefone telefoneEntity)
    {
      var retorno = new Telefone();
      var list = new List<Telefone>();
      var parametros = new DynamicParameters();

      try
      {
        parametros.Add("@ClienteId", telefoneEntity.ClienteId, DbType.Int32, ParameterDirection.Input, null);

        parametros.Add("@Ddd", telefoneEntity.Ddd, DbType.String, ParameterDirection.Input, null);

        parametros.Add("@Numero", telefoneEntity.Numero, DbType.String, ParameterDirection.Input, null);

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

    public async Task<bool> TelefoneDelete(int Id)
    {
      if (Id < 0)
      {
        return false;
      }
      var parametros = new DynamicParameters();

      parametros.Add(@"TelefoneId", Id, DbType.Int32, ParameterDirection.Input, null);

      using (SqlConnection db = new SqlConnection(this._connectionString))
      {
        var result = await db.QueryAsync<Telefone>(
            "[TelefoneDelete]",
            parametros,
            commandType: CommandType.StoredProcedure);
      }
      return true;
    }

    public async Task<List<Email>> EmailsGetAllByIdCliente(int Id)
    {
      var parametros = new DynamicParameters();
      var resultado = new List<Email>();

      parametros.Add(@"ClienteId", Id, DbType.Int32, ParameterDirection.Input, null);

      using (SqlConnection db = new SqlConnection(this._connectionString))
      {
        var result = await db.QueryAsync<Email>(
            "[EmailsGetAllByIdCliente]",
            parametros,
            commandType: CommandType.StoredProcedure);

        if (result != null)
        {
          resultado = result.ToList<Email>();
        }
      }
      return (resultado);
    }

    public async Task<Email> EmailInsert(Email emailEntity)
    {
      var retorno = new Email();
      var list = new List<Email>();
      var parametros = new DynamicParameters();

      try
      {
        parametros.Add("@_Email", emailEntity._Email, DbType.String, ParameterDirection.Input, null);

        parametros.Add("@ClienteId", emailEntity.ClienteId, DbType.Int32, ParameterDirection.Input, null);

        using (SqlConnection db = new SqlConnection(this._connectionString))
        {
          var result = await db.QueryAsync<Email>(
              "[EmailInsert]",
              parametros,
              commandType: CommandType.StoredProcedure);

          if (result != null)
          {
            list = result.ToList<Email>();
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

    public async Task<bool> EmailDelete(int Id)
    {
      if (Id < 0)
      {
        return false;
      }
      var parametros = new DynamicParameters();

      parametros.Add(@"EmailId", Id, DbType.Int32, ParameterDirection.Input, null);

      using (SqlConnection db = new SqlConnection(this._connectionString))
      {
        var result = await db.QueryAsync<Email>(
            "[EmailDelete]",
            parametros,
            commandType: CommandType.StoredProcedure);
      }
      return true;
    }
  }
}
