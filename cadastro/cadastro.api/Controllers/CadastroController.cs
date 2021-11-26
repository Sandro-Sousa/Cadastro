using cadastro.domain.Entities;
using cadastro.service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
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

        [HttpPost("v1/CadastroCliente")]
        [SwaggerResponse(StatusCodes.Status200OK, "", null)]
        [SwaggerResponse(StatusCodes.Status204NoContent, "", null)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "", typeof(string))]
        public async Task<ActionResult> CadastroCliente(ClienteEntity model)
        {
            try
            {
                var result = await this._cadastroService.ClientInsertService(model);

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
