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
