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

    public async Task<List<ClienteDTO>> ClienteGetAll()
    {
      try
      {
        var user = await this._procedure.ClienteGetAll();

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

    public async Task<ClienteDTOInsert> ClienteInsert(ClienteDTOInsert clienteDTOInsert)
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

    public async Task<EnderecoDTOInsert> EnderecoInsert(EnderecoDTOInsert enderecoDTO)
    {
      try
      {
        var data = this._mapper.Map<Endereco>(enderecoDTO);

        var endereco = await this._procedure.EnderecoInsert(data);

        if (endereco == null) throw new Exception("Dados Inválidos");

        var result = this._mapper.Map<EnderecoDTOInsert>(endereco);

        return result;
      }
      catch (Exception ex)
      {
        throw new Exception(ex.Message);
      }
    }

    public async Task<List<EnderecoDTO>> EnderecosGetAllByIdCliente(int Id)
    {
      try
      {
        var user = await this._procedure.EnderecosGetAllByIdCliente(Id);

        if (user == null) throw new Exception("Id inválido(s).");

        var result = this._mapper.Map<List<EnderecoDTO>>(user);

        return result;
      }
      catch (Exception ex)
      {
        throw new Exception(ex.Message);
      }
    }

    public async Task<bool> EnderecoDelete(int Id)
    {
      if (Id < 0)
      {
        return false;
      }
      try
      {
        var result = await this._procedure.EnderecoDelete(Id);
        return true;
      }
      catch (Exception ex)
      {
        throw new Exception(ex.Message);
      }
    }
    public async Task<List<TelefoneDTO>> TelefoneGetAll()
    {
      try
      {
        var user = await this._procedure.TelefoneGetAll();

        var result = this._mapper.Map<List<TelefoneDTO>>(user);

        if (user == null) throw new Exception("Dados Inválidos");

        return result;
      }
      catch (Exception ex)
      {
        throw new Exception(ex.Message);
      }
    }

    public async Task<List<TelefoneDTO>> TelefonesGetAllByIdCliente(int Id)
    {
      try
      {
        var user = await this._procedure.TelefonesGetAllByIdCliente(Id);

        if (user == null) throw new Exception("Id inválido(s).");

        var result = this._mapper.Map<List<TelefoneDTO>>(user);

        return result;
      }
      catch (Exception ex)
      {
        throw new Exception(ex.Message);
      }
    }

    public async Task<TelefoneDTOInsert> TelefoneInsert(TelefoneDTOInsert telefoneDTO)
    {
      try
      {
        var data = this._mapper.Map<Telefone>(telefoneDTO);

        var telefone = await this._procedure.TelefoneInsert(data);

        if (telefone == null) throw new Exception("Dados Inválidos");

        var result = this._mapper.Map<TelefoneDTOInsert>(telefone);

        return result;
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
      try
      {
        var result = await this._procedure.TelefoneDelete(Id);
        return true;
      }
      catch (Exception ex)
      {
        throw new Exception(ex.Message);
      }
    }

    public async Task<List<EmailDTO>> EmailsGetAllByIdCliente(int Id)
    {
      try
      {
        var user = await this._procedure.EmailsGetAllByIdCliente(Id);

        if (user == null) throw new Exception("Id inválido(s).");

        var result = this._mapper.Map<List<EmailDTO>>(user);

        return result;
      }
      catch (Exception ex)
      {
        throw new Exception(ex.Message);
      }
    }

    public async Task<EmailDTOInsert> EmailInsert(EmailDTOInsert emailDTO)
    {
      try
      {
        var data = this._mapper.Map<Email>(emailDTO);

        var email = await this._procedure.EmailInsert(data);

        if (email == null) throw new Exception("Dados Inválidos");

        var result = this._mapper.Map<EmailDTOInsert>(email);

        return result;
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
      try
      {
        var result = await this._procedure.EmailDelete(Id);
        return true;
      }
      catch (Exception ex)
      {
        throw new Exception(ex.Message);
      }
    }
  }
}
