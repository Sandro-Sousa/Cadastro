using cadastro.service.DTOs;
using cadastro.service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace cadastro.api.Controllers
{
  [ApiController]
  [Route("api/cadastro")]
  public class CadastroController : Controller
  {
    private readonly ICadastroService _cadastroService;

    public CadastroController(ICadastroService cadastroService)
    {
      this._cadastroService = cadastroService;
    }

    [HttpGet("v1/clienteGetAll")]
    [SwaggerResponse(StatusCodes.Status200OK, "Sucesso", typeof(string))]
    [SwaggerResponse(StatusCodes.Status204NoContent, "Dados do Cabeçalho incorretos", typeof(string))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "Erro no Servidor", typeof(string))]
    public async Task<ActionResult> ClienteGetAll()
    {
      try
      {
        var result = await this._cadastroService.ClienteGetAll();
        if (result == null) return this.StatusCode(StatusCodes.Status204NoContent);

        return this.StatusCode(StatusCodes.Status200OK, result);
      }
      catch (Exception ex)
      {
        return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
      }
    }

    [HttpGet("v1/clientegetbyid/{id}")]
    [SwaggerResponse(StatusCodes.Status200OK, "Sucesso", typeof(string))]
    [SwaggerResponse(StatusCodes.Status204NoContent, "Dados do Cabeçalho incorretos", typeof(string))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "Erro no Servidor", typeof(string))]
    public async Task<ActionResult> ClienteGetById(int id)
    {
      try
      {
        var result = await this._cadastroService.ClienteGetById(id);

        if (result == null) return this.StatusCode(StatusCodes.Status204NoContent);

        return this.StatusCode(StatusCodes.Status200OK, result);
      }
      catch (Exception ex)
      {
        return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
      }
    }

    [HttpPost("v1/insertcliente")]
    [SwaggerResponse(StatusCodes.Status200OK, "Inserido com Sucesso", typeof(ClienteDTOInsert))]
    [SwaggerResponse(StatusCodes.Status204NoContent, "Dados do Cabeçalho incorretos", typeof(string))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "Erro no Servidor", typeof(string))]
    public async Task<ActionResult> InsertCliente(ClienteDTOInsert model)
    {
      try
      {
        var result = await this._cadastroService.ClienteInsert(model);

        return this.StatusCode(StatusCodes.Status200OK, result);
      }
      catch (Exception ex)
      {
        return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
      }
    }

    [HttpPut("v1/updatecliente/{id}")]
    [SwaggerResponse(StatusCodes.Status200OK, "Atualizado com Sucesso", typeof(ClienteDTO))]
    [SwaggerResponse(StatusCodes.Status204NoContent, "Dados do Cabeçalho incorretos", typeof(string))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "Erro no Servidor", typeof(string))]
    public async Task<ActionResult> UpdateCliente(int id, ClienteDTO model)
    {
      if (id != model.ClienteId)
      {
        return BadRequest("Id Invalido");
      }
      try
      {
        var result = await this._cadastroService.ClienteUpdate(model);

        return this.StatusCode(StatusCodes.Status200OK, result);
      }
      catch (Exception ex)
      {
        return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
      }
    }

    [HttpDelete("v1/clientedelete/{userid}")]
    [SwaggerResponse(StatusCodes.Status200OK, "Deletado com Sucesso", typeof(bool))]
    [SwaggerResponse(StatusCodes.Status204NoContent, "Dados do Cabeçalho incorretos", typeof(string))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "Erro no Servidor", typeof(string))]
    public async Task<ActionResult> ClienteDelete(int userid)
    {
      try
      {
        var result = await this._cadastroService.ClienteDelete(userid);

        if (result == false) return this.StatusCode(StatusCodes.Status204NoContent);

        return this.StatusCode(StatusCodes.Status200OK, result);
      }
      catch (Exception ex)
      {
        return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
      }
    }

    [HttpPost("v1/cadastroendereco")]
    [SwaggerResponse(StatusCodes.Status200OK, "Cadastrado com Sucesso", typeof(EnderecoDTOInsert))]
    [SwaggerResponse(StatusCodes.Status204NoContent, "Dados do Cabeçalho incorretos", typeof(string))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "Erro no Servidor", typeof(string))]
    public async Task<ActionResult> CadastroEndereco(EnderecoDTOInsert model)
    {
      try
      {
        var result = await this._cadastroService.EnderecoInsert(model);

        return this.StatusCode(StatusCodes.Status200OK, result);
      }
      catch (Exception ex)
      {
        return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
      }
    }

    [HttpGet("v1/enderecosGetAllByIdCliente/{id}")]
    [SwaggerResponse(StatusCodes.Status200OK, "Sucesso", typeof(string))]
    [SwaggerResponse(StatusCodes.Status204NoContent, "Dados do Cabeçalho incorretos", typeof(string))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "Erro no Servidor", typeof(string))]
    public async Task<ActionResult> EnderecosGetAllByIdCliente(int id)
    {
      try
      {
        var result = await this._cadastroService.EnderecosGetAllByIdCliente(id);
        if (result == null) return this.StatusCode(StatusCodes.Status204NoContent);

        return this.StatusCode(StatusCodes.Status200OK, result);
      }
      catch (Exception ex)
      {
        return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
      }
    }

    [HttpDelete("v1/enderecoDelete/{userid}")]
    [SwaggerResponse(StatusCodes.Status200OK, "Deletado com Sucesso", typeof(bool))]
    [SwaggerResponse(StatusCodes.Status204NoContent, "Dados do Cabeçalho incorretos", typeof(string))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "Erro no Servidor", typeof(string))]
    public async Task<ActionResult> EnderecoDelete(int userid)
    {
      try
      {
        var result = await this._cadastroService.EnderecoDelete(userid);

        if (result == false) return this.StatusCode(StatusCodes.Status204NoContent);

        return this.StatusCode(StatusCodes.Status200OK, result);
      }
      catch (Exception ex)
      {
        return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
      }
    }

    [HttpGet("v1/telefoneGetAll")]
    [SwaggerResponse(StatusCodes.Status200OK, "Sucesso", typeof(string))]
    [SwaggerResponse(StatusCodes.Status204NoContent, "Dados do Cabeçalho incorretos", typeof(string))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "Erro no Servidor", typeof(string))]
    public async Task<ActionResult> TelefoneGetAll()
    {
      try
      {
        var result = await this._cadastroService.TelefoneGetAll();
        if (result == null) return this.StatusCode(StatusCodes.Status204NoContent);

        return this.StatusCode(StatusCodes.Status200OK, result);
      }
      catch (Exception ex)
      {
        return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
      }
    }

    [HttpGet("v1/telefonesGetAllByIdCliente/{id}")]
    [SwaggerResponse(StatusCodes.Status200OK, "Sucesso", typeof(string))]
    [SwaggerResponse(StatusCodes.Status204NoContent, "Dados do Cabeçalho incorretos", typeof(string))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "Erro no Servidor", typeof(string))]
    public async Task<ActionResult> TelefonesGetAllByIdCliente(int id)
    {
      try
      {
        var result = await this._cadastroService.TelefonesGetAllByIdCliente(id);
        if (result == null) return this.StatusCode(StatusCodes.Status204NoContent);

        return this.StatusCode(StatusCodes.Status200OK, result);
      }
      catch (Exception ex)
      {
        return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
      }
    }

    [HttpPost("v1/cadastrotelefone")]
    [SwaggerResponse(StatusCodes.Status200OK, "Cadastrado com Sucesso", typeof(TelefoneDTOInsert))]
    [SwaggerResponse(StatusCodes.Status204NoContent, "Dados do Cabeçalho incorretos", typeof(string))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "Erro no Servidor", typeof(string))]
    public async Task<ActionResult> CadastroTelefone(List<TelefoneDTOInsert> model)
    {
      try
      {
        foreach (var item in model)
        {
          var result = await this._cadastroService.TelefoneInsert(item);
        }

        return this.StatusCode(StatusCodes.Status200OK, model);
      }
      catch (Exception ex)
      {
        return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
      }
    }

    [HttpDelete("v1/telefonedelete/{userid}")]
    [SwaggerResponse(StatusCodes.Status200OK, "Deletado com Sucesso", typeof(bool))]
    [SwaggerResponse(StatusCodes.Status204NoContent, "Dados do Cabeçalho incorretos", typeof(string))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "Erro no Servidor", typeof(string))]
    public async Task<ActionResult> TelefoneDelete(int userid)
    {
      try
      {
        var result = await this._cadastroService.TelefoneDelete(userid);

        if (result == false) return this.StatusCode(StatusCodes.Status204NoContent);

        return this.StatusCode(StatusCodes.Status200OK, result);
      }
      catch (Exception ex)
      {
        return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
      }
    }





    [HttpGet("v1/emailsGetAllByIdCliente/{id}")]
    [SwaggerResponse(StatusCodes.Status200OK, "Sucesso", typeof(string))]
    [SwaggerResponse(StatusCodes.Status204NoContent, "Dados do Cabeçalho incorretos", typeof(string))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "Erro no Servidor", typeof(string))]
    public async Task<ActionResult> EmailsGetAllByIdCliente(int id)
    {
      try
      {
        var result = await this._cadastroService.EmailsGetAllByIdCliente(id);
        if (result == null) return this.StatusCode(StatusCodes.Status204NoContent);

        return this.StatusCode(StatusCodes.Status200OK, result);
      }
      catch (Exception ex)
      {
        return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
      }
    }

    [HttpPost("v1/cadastroemail")]
    [SwaggerResponse(StatusCodes.Status200OK, "Cadastrado com Sucesso", typeof(EmailDTOInsert))]
    [SwaggerResponse(StatusCodes.Status204NoContent, "Dados do Cabeçalho incorretos", typeof(string))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "Erro no Servidor", typeof(string))]
    public async Task<ActionResult> CadastroEmail(List<EmailDTOInsert> model)
    {
      try
      {
        foreach (var item in model)
        {
          var result = await this._cadastroService.EmailInsert(item);
        }

        return this.StatusCode(StatusCodes.Status200OK, model);
      }
      catch (Exception ex)
      {
        return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
      }
    }

    [HttpDelete("v1/emaildelete/{userid}")]
    [SwaggerResponse(StatusCodes.Status200OK, "Deletado com Sucesso", typeof(bool))]
    [SwaggerResponse(StatusCodes.Status204NoContent, "Dados do Cabeçalho incorretos", typeof(string))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "Erro no Servidor", typeof(string))]
    public async Task<ActionResult> EmailDelete(int userid)
    {
      try
      {
        var result = await this._cadastroService.EmailDelete(userid);

        if (result == false) return this.StatusCode(StatusCodes.Status204NoContent);

        return this.StatusCode(StatusCodes.Status200OK, result);
      }
      catch (Exception ex)
      {
        return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
      }
    }
  }
}
