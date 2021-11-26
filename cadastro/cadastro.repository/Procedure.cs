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
    public class Procedure : IProcedure
    {
        private string _connectionString;

        public Procedure()
        {
            this._connectionString = velesemail.cross.AppSettings.GetConnectionString("Cadastro");
        }

        public async Task<ClienteEntity> ClientGetById(int Id)
        {
            var parametros = new DynamicParameters();

            parametros.Add(@"IdCliente", Id, DbType.Int32, ParameterDirection.Input, null);

            using (SqlConnection db = new SqlConnection(this._connectionString))
            {
                var result = await db.QueryAsync<ClienteEntity>(
                    "[ClienteGetById]",
                    parametros,
                    commandType: CommandType.StoredProcedure);

                return result != null ? result.ToList().FirstOrDefault() : null;
            }
        }

        public async Task<ClienteEntity> ClientInsert(ClienteEntity clienteEntity)
        {
            var retorno = new ClienteEntity();
            var list = new List<ClienteEntity>();
            var parametros = new DynamicParameters();

            try
            {
                parametros.Add("@Nome", clienteEntity.Nome, DbType.String, ParameterDirection.Input, null);
                parametros.Add("@Cpf", clienteEntity.Cpf, DbType.String, ParameterDirection.Input, null);    

                using (SqlConnection db = new SqlConnection(this._connectionString))
                {
                    var result = await db.QueryAsync<ClienteEntity>(
                        "[ClienteInsert]",
                        parametros,
                        commandType: CommandType.StoredProcedure);

                    if (result != null)
                    {
                        list = result.ToList<ClienteEntity>();
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

        public async Task<EnderecoEntity> EnderecoInsert(EnderecoEntity enderecoEntity)
        {
            var retorno = new EnderecoEntity();
            var list = new List<EnderecoEntity>();
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
                    var result = await db.QueryAsync<EnderecoEntity>(
                        "[EnderecoInsert]",
                        parametros,
                        commandType: CommandType.StoredProcedure);

                    if (result != null)
                    {
                        list = result.ToList<EnderecoEntity>();
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

        public async Task<TelefoneEntity> TelefoneInsert(TelefoneEntity telefoneEntity)
        {
            var retorno = new TelefoneEntity();
            var list = new List<TelefoneEntity>();
            var parametros = new DynamicParameters();

            try
            {
                parametros.Add("@Telefone", telefoneEntity.Telefone, DbType.String, ParameterDirection.Input, null);
                parametros.Add("@IdCliente", telefoneEntity.IdCliente, DbType.String, ParameterDirection.Input, null);

                using (SqlConnection db = new SqlConnection(this._connectionString))
                {
                    var result = await db.QueryAsync<TelefoneEntity>(
                        "[TelefoneInsert]",
                        parametros,
                        commandType: CommandType.StoredProcedure);

                    if (result != null)
                    {
                        list = result.ToList<TelefoneEntity>();
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
