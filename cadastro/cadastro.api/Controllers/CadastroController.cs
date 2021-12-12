using cadastro.domain.Entities;
using cadastro.service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Threading.Tasks;
using static cadastro.service.DTOs.ControllerCadastroDTO;

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

        [HttpGet("v1/ClienteGet")]
        [SwaggerResponse(StatusCodes.Status200OK, "", null)]
        [SwaggerResponse(StatusCodes.Status204NoContent, "", null)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "", null)]
        public async Task<ActionResult> ClienteGet()
        {
            try
            {
                var result = await this._cadastroService.ClienteGetAllService();
                if (result == null) return this.StatusCode(StatusCodes.Status204NoContent);

                return this.StatusCode(StatusCodes.Status200OK, result);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("v1/ClienteGetById{userid}")]
        [SwaggerResponse(StatusCodes.Status200OK, "", null)]
        [SwaggerResponse(StatusCodes.Status204NoContent, "", null)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "", null)]
        public async Task<ActionResult> ClienteGetById(int userid)
        {
            try
            {
                var result = await this._cadastroService.ClienteGetByIdService(userid);

                if (result == null) return this.StatusCode(StatusCodes.Status204NoContent);

                return this.StatusCode(StatusCodes.Status200OK, result);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost("v1/InsertCliente")]
        [SwaggerResponse(StatusCodes.Status200OK, "", null)]
        [SwaggerResponse(StatusCodes.Status204NoContent, "", null)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "", typeof(string))]
        public async Task<ActionResult> InsertCliente(ClienteDTOInsert model)
        {
            try
            {
                var result = await this._cadastroService.ClienteInsertService(model);

                return this.StatusCode(StatusCodes.Status200OK, result);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost("v1/UpdateCliente")]
        [SwaggerResponse(StatusCodes.Status200OK, "", null)]
        [SwaggerResponse(StatusCodes.Status204NoContent, "", null)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "", typeof(string))]
        public async Task<ActionResult> UpdateCliente(ClienteDTO model)
        {
            try
            {
                var result = await this._cadastroService.ClienteUpdateService(model);

                return this.StatusCode(StatusCodes.Status200OK, result);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("v1/ClienteDelete{userid}")]
        [SwaggerResponse(StatusCodes.Status200OK, "", typeof(bool))]
        [SwaggerResponse(StatusCodes.Status204NoContent, "", null)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "", null)]
        public async Task<ActionResult> ClienteDelete(int userid)
        {
            try
            {
                var result = await this._cadastroService.ClienteDeleteService(userid);

                if (result == false) return this.StatusCode(StatusCodes.Status204NoContent);

                return this.StatusCode(StatusCodes.Status200OK, result);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost("v1/cadastroEndereco")]
        [SwaggerResponse(StatusCodes.Status200OK, "", null)]
        [SwaggerResponse(StatusCodes.Status204NoContent, "", null)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "", typeof(string))]
        public async Task<ActionResult> CadastroEndereco(EnderecoEntity model)
        {
            try
            {
                var result = await this._cadastroService.EnderecoInsertService(model);

                return this.StatusCode(StatusCodes.Status200OK, result);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost("v1/cadastroTelefone")]
        [SwaggerResponse(StatusCodes.Status200OK, "", null)]
        [SwaggerResponse(StatusCodes.Status204NoContent, "", null)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "", typeof(string))]
        public async Task<ActionResult> CadastroTelefone(TelefoneEntity model)
        {
            try
            {
                var result = await this._cadastroService.TelefoneInsertService(model);

                return this.StatusCode(StatusCodes.Status200OK, result);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
