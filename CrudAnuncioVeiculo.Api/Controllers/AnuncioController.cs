using CrudAnuncioVeiculo.Domain.Commands;
using CrudAnuncioVeiculo.Domain.DTOs;
using CrudAnuncioVeiculo.Domain.Services.Anuncio;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CrudAnuncioVeiculo.Api.Controllers
{
    [Route("api/v1/[controller]")]
    public class AnuncioController : Controller
    {
        #region Anúncios
        /// <summary>
        /// Obtém a lista de anúncios
        /// </summary>
        [HttpGet("")]
        [ProducesResponseType(typeof(List<AnuncioWebMotorsDTO>), 200)]
        public async Task<IActionResult> Obter([FromServices] IAnuncioService service)
        {
            return Ok(await service.Obter());
        }

        /// <summary>
        /// Cria um anúncio
        /// </summary>
        [HttpPost("")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> Criar(
        [FromBody] CriarAnuncioCommand command,
        [FromServices] IMediator mediator)
        {
            return Ok(await mediator.Send(command));
        }


        /// <summary>
        /// Altera um anúncio
        /// </summary>
        [HttpPut("")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> Alterar(
        [FromBody] AlterarAnuncioCommand command,
        [FromServices] IMediator mediator)
        {
            return Ok(await mediator.Send(command));
        }

        /// <summary>
        /// Deleta um anúncio
        /// </summary>
        [HttpDelete("{idAnuncio:int}")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> Deletar([FromRoute] int idAnuncio, [FromServices] IAnuncioService service)
        {
            return Ok(await service.Deletar(idAnuncio));
        }

        #endregion Anúncios
    }
}
