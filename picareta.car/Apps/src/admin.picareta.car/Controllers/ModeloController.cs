using Admin.Picareta.Application.Dto;
using Admin.Picareta.Domain.Commands;
using Core.Picareta.Comunication;
using Microsoft.AspNetCore.Mvc;

namespace admin.picareta.car.Controllers
{
    [Route("api/modelo")]
    [ApiController]
    public class ModeloController : ControllerBase
    {
        private readonly IComunication _comunication;

        //controller provisória.
        public ModeloController(IComunication comunication)
        {
            _comunication = comunication;
        }
        public IActionResult Post([FromBody]ModeloDto modeloDto)
        {
            var adicionarModeloCommand = new AdicionarModeloCommand(modeloDto.Nome, modeloDto.ValorMinimo, modeloDto.ValorMaximo);
            if (adicionarModeloCommand.IsValid())
            {
                _comunication.EnviarComando(adicionarModeloCommand);
                return Ok();
            }

            return BadRequest(adicionarModeloCommand.ValidationResult.Errors);

        }
    }
}