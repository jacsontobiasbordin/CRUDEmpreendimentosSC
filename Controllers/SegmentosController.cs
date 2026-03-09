using Microsoft.AspNetCore.Mvc;
using CRUDEmpreendimentosSC.Enums;
using System.ComponentModel;
using System.Reflection;

namespace CRUDEmpreendimentosSC.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SegmentosController : ControllerBase
    {
        // Listar todos os segmentos
        // GET: api/Segmentos
        /// <summary>
        /// Retorna a lista de segmentos disponíveis.
        /// </summary>
        /// <remarks>
        /// Retorna a lista com todos os segmentos disponíveis.
        /// </remarks>
        /// <returns>Lista de segmentos com identificador e descrição</returns>
        /// <response code="200">Lista retornada com sucesso</response>
        [HttpGet]
        public IActionResult Get()
        {
            var segmentos = Enum.GetValues(typeof(Segmento))
                .Cast<Segmento>()
                .Select(s => new
                {
                    id = (int)s,
                    descricao = GetEnumDescription(s)
                });

            return Ok(segmentos);
        }

        private string GetEnumDescription(Enum value)
        {
            var field = value.GetType().GetField(value.ToString());

            var attribute = field?
                .GetCustomAttribute<DescriptionAttribute>();

            return attribute?.Description ?? value.ToString();
        }
    }
}
