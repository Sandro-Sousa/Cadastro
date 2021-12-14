using AutoMapper;
using cadastro.domain.Entities;
using cadastro.repository.Interfaces;
using cadastro.service.DTOs;
using cadastro.service.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace cadastro.service
{
    public class CadastroService : ICadastroService
    {
        private readonly IMapper _mapper;
        private readonly ICadastroRepository _procedure;

        public CadastroService(ICadastroRepository procedure, IMapper mapper)
        {
            this._mapper = mapper;
            this._procedure = procedure;
        }

        public async Task<List<ClienteDTO>> GetAll()
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

        public async Task<ClienteDTO> ClienteGetById(int Id)
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

        public async Task<ClienteDTOInsert> ClienteInsert(ClienteDTOInsert  clienteDTOInsert)
        {
            try
            {
                var data = this._mapper.Map<Cliente>(clienteDTOInsert);

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

        public async Task<ClienteDTO> ClienteUpdate(ClienteDTO clienteDTO)
        {
            try
            {
                var data = this._mapper.Map<Cliente>(clienteDTO);

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

        public async Task<bool> ClienteDelete(int Id)
        {
            if (Id < 0)
            {
                return false;
            }
            try
            {
                var result = await this._procedure.ClienteDelete(Id);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<EnderecoDTO> EnderecoInsert(EnderecoDTO enderecoDTO)
        {
            try
            {
                var data = this._mapper.Map<Endereco>(enderecoDTO);

                var endereco = await this._procedure.EnderecoInsert(data);

                if (endereco == null) throw new Exception("Dados Inválidos");

                var result = this._mapper.Map<EnderecoDTO>(endereco);

                return result;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<TelefoneDTO> TelefoneInsert(TelefoneDTO telefoneDTO)
        {
            try
            {
                var data = this._mapper.Map<Telefone>(telefoneDTO);

                var telefone = await this._procedure.TelefoneInsert(data);

                if (telefone == null) throw new Exception("Dados Inválidos");

                var result = this._mapper.Map<TelefoneDTO>(telefone);

                return result;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
