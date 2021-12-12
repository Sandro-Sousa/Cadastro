using AutoMapper;
using cadastro.domain.Entities;
using cadastro.repository.Interfaces;
using cadastro.service.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static cadastro.service.DTOs.ControllerCadastroDTO;

namespace cadastro.service
{
    public class CadastroService : ICadastroService
    {
        private readonly IMapper _mapper;
        private readonly IProcedure _procedure;

        public CadastroService(IProcedure procedure, IMapper mapper)
        {
            this._mapper = mapper;
            this._procedure = procedure;
        }

        public async Task<List<ClienteDTO>> ClienteGetAllService()
        {
            try
            {
                var user = await this._procedure.ClienteGet();

                var result = this._mapper.Map<List<ClienteDTO>>(user);

                if (user == null) throw new Exception("Dados Inválidos");

                return result;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<ClienteDTO> ClienteGetByIdService(int Id)
        {
            try
            {
                var user = await this._procedure.ClienteGetById(Id);

                if (user == null) throw new Exception("Id inválido(s).");

                var result = this._mapper.Map<ClienteDTO>(user);

                return result;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<ClienteDTOInsert> ClienteInsertService(ClienteDTOInsert clienteDTO)
        {
            try
            {
                var data = this._mapper.Map<ClienteEntity>(clienteDTO);

                var user = await this._procedure.ClienteInsert(data);

                var result = this._mapper.Map<ClienteDTOInsert>(user);

                if (user == null) throw new Exception("Dados Inválidos");

                return result;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<ClienteDTO> ClienteUpdateService(ClienteDTO clienteDTO)
        {
            try
            {
                var data = this._mapper.Map<ClienteEntity>(clienteDTO);

                var user = await this._procedure.ClienteUpdate(data);

                var result = this._mapper.Map<ClienteDTO>(user);

                if (user == null) throw new Exception("Dados Inválidos");

                return result;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> ClienteDeleteService(int Id)
        {
            if (Id < 0)
            {
                return false;
            }
            try
            {
                var result =  await this._procedure.ClienteDelete(Id);
                return true;
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

                var user = await this._procedure.EnderecoInsert(enderecoEntity);

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
                var user = await this._procedure.TelefoneInsert(telefoneEntity);

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
