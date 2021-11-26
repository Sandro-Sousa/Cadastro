using AutoMapper;
using cadastro.domain.Entities;
using cadastro.repository.Interfaces;
using cadastro.service.DTOs;
using cadastro.service.Interfaces;
using System;
using System.Threading.Tasks;
using static cadastro.service.DTOs.ControllerCadastroDTO;

namespace cadastro.service
{
    public class CadastroService : ICadastroService
    {
        private readonly IMapper _mapper;
        private readonly IProcedure _procedure;

        public CadastroService(IProcedure  procedure, IMapper mapper)
        {
            this._mapper = mapper;
            this._procedure = procedure;
        }

        public async Task<ClienteEntity> ClientGetByIdService(int Id)
        {
            try
            {

                var user = await this._procedure.ClientGetById(Id);

                if (user == null) throw new Exception("Id inválido(s).");

                return user;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<ClienteDTO> ClientInsertService(ClienteDTO  clienteDTO)
        {
            try
            {
                var result = this._mapper.Map<ClienteEntity>(clienteDTO);

                var user = await this._procedure.ClientInsert(result);

                if (user == null) throw new Exception("Dados Inválidos");

                return result;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<EnderecoEntity> EnderecoInsertService(EnderecoEntity enderecoEntity)
        {
            try
            {
                var userById = await this._procedure.ClientGetById(enderecoEntity.IdCliente);

                var user = await this._procedure.EnderecoInsert(enderecoEntity);

                user.IdCliente = userById.IdCliente;

                if (user == null) throw new Exception("Dados Inválidos");

                return user;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<TelefoneEntity> TelefoneInsertService(TelefoneEntity telefoneEntity)
        {
            try
            {
                var userById = await this._procedure.ClientGetById(telefoneEntity.IdCliente);

                var user = await this._procedure.TelefoneInsert(telefoneEntity);

                user.IdCliente = userById.IdCliente;

                if (user == null) throw new Exception("Dados Inválidos");

                return user;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
