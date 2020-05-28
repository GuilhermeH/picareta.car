using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Admin.Picareta.Domain.Queries.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace admin.picareta.car.Controllers
{
    [Route("api/intencaovenda")]
    [ApiController]
    public class IntencaoVendaController : ControllerBase
    {
        private readonly IIntencaoVendaQuery _intencaoVendaQuery;
        public IntencaoVendaController(IIntencaoVendaQuery intencaoVendaQuery)
        {
            _intencaoVendaQuery = intencaoVendaQuery;
        }
        [HttpGet, Route("avaliacoes")]
        public IActionResult Get()
        {
            var intencoesVenda = _intencaoVendaQuery.GetIntencoesVendasParaAvaliacao();
            return Ok(intencoesVenda);
        }
    }
}