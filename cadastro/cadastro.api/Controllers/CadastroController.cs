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

    [HttpGet("v1/getall")]
    [SwaggerResponse(StatusCodes.Status200OK, "Sucesso", typeof(string))]
    [SwaggerResponse(StatusCodes.Status204NoContent, "Dados do Cabeçalho incorretos", typeof(string))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "Erro no Servidor", typeof(string))]
    public async Task<ActionResult> GetAll()
    {
      try
      {
        var result = await this._cadastroService.GetAll();
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
      if (id != model.idCliente)
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
    [SwaggerResponse(StatusCodes.Status200OK, "Cadastrado com Sucesso", typeof(EnderecoDTO))]
    [SwaggerResponse(StatusCodes.Status204NoContent, "Dados do Cabeçalho incorretos", typeof(string))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "Erro no Servidor", typeof(string))]
    public async Task<ActionResult> CadastroEndereco(EnderecoDTO model)
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

    [HttpPost("v1/cadastrotelefone")]
    [SwaggerResponse(StatusCodes.Status200OK, "Cadastrado com Sucesso", typeof(TelefoneDTO))]
    [SwaggerResponse(StatusCodes.Status204NoContent, "Dados do Cabeçalho incorretos", typeof(string))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "Erro no Servidor", typeof(string))]
    public async Task<ActionResult> CadastroTelefone(List<TelefoneDTO> model)
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
  }
}
