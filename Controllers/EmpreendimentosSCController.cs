using CRUDEmpreendimentosSC.Data;
using CRUDEmpreendimentosSC.DTO;
using CRUDEmpreendimentosSC.Enums;
using CRUDEmpreendimentosSC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Filters;
using CRUDEmpreendimentosSC.Examples;

namespace CRUDEmpreendimentosSC.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmpreendimentosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EmpreendimentosController(AppDbContext context)
        {
            _context = context;
        }

        // Buscar todos os empreendimentos
        // GET: api/Empreendimentos
        /// <summary>
        /// Lista todos os empreendimentos cadastrados, de forma paginada.
        /// </summary>
        /// <remarks>
        /// Retorna a lista completa de empreendimentos registrados no sistema.
        /// </remarks>
        /// <param name="municipio">Filtro por município (contém)</param>
        /// <param name="segmento">Filtro por segmento</param>
        /// <param name="page">Número da página</param>
        /// <param name="pageSize">Quantidade de registros por página (máximo 100)</param>
        /// <returns>Lista de empreendimentos paginada</returns>
        /// <response code="200">Lista retornada com sucesso</response>
        [HttpGet()]
        public async Task<ActionResult<IEnumerable<EmpreendimentoSC>>> Get([FromQuery] string? municipio, [FromQuery] int? segmento, int page = 1, int pageSize = 100)
        {
            if (page <= 0)
                page = 1;

            if (pageSize <= 0)
                pageSize = 10;

            if (pageSize > 100)
                pageSize = 100;

            var query = _context.EmpreendimentosSC.AsQueryable();

            if (!string.IsNullOrWhiteSpace(municipio))
            {
                query = query.Where(e => e.Municipio.ToLower().Contains(municipio.ToLower()));
            }

            if (segmento.HasValue)
            {
                if (!Enum.IsDefined(typeof(Segmento), segmento.Value))
                    throw new ArgumentException("Segmento inválido.");

                query = query.Where(e => e.Segmento == (Segmento)segmento.Value);
            }


            var total = await query.CountAsync();

            var empreendimentos = await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return Ok(new
            {
                total,
                page,
                pageSize,
                dados = empreendimentos
            });
        }

        // Buscar um empreendimento por ID
        // GET: api/Empreendimentos/id
        /// <summary>
        /// Retorna um empreendimento pelo identificador.
        /// </summary>
        /// <remarks>
        /// Retorna um único empreendimento a partir do identificador único (Id).
        /// </remarks>
        /// <param name="id">Identificador único do empreendimento</param>
        /// <returns>Dados do empreendimento</returns>
        /// <response code="200">Empreendimento encontrado</response>
        /// <response code="404">Empreendimento não encontrado</response>
        [HttpGet("{id}")]
        public async Task<ActionResult<EmpreendimentoSC>> Get(int id)
        {
            var empreendimento = await _context.EmpreendimentosSC.FindAsync(id);

            if (empreendimento == null)
            {
                throw new KeyNotFoundException("Empreendimento não encontrado.");
            }

            return empreendimento;
        }

        /// <summary>
        /// Retorna dados estatísticos dos empreendimentos cadastrados.
        /// </summary>
        /// <remarks>
        /// Retorna informações agregadas como:
        /// total de empreendimentos,
        /// quantidade de ativos e inativos,
        /// distribuição por segmento
        /// e distribuição por município.
        /// </remarks>
        /// <returns>Dados estatísticos</returns>
        /// <response code="200">Estatísticas retornadas com sucesso</response>
        [HttpGet("estatisticas")]
        public async Task<IActionResult> GetEstatisticas()
        {
            var total = await _context.EmpreendimentosSC.CountAsync();

            var ativos = await _context.EmpreendimentosSC
                .Where(e => e.Status)
                .CountAsync();

            var inativos = total - ativos;

            var porSegmento = await _context.EmpreendimentosSC
                .GroupBy(e => e.Segmento)
                .Select(g => new
                {
                    segmento = g.Key.ToString(),
                    quantidade = g.Count()
                })
                .ToListAsync();

            var porMunicipio = await _context.EmpreendimentosSC
                .GroupBy(e => e.Municipio)
                .Select(g => new
                {
                    municipio = g.Key,
                    quantidade = g.Count()
                })
                .OrderByDescending(x => x.quantidade)
                .ToListAsync();

            return Ok(new
            {
                totalEmpreendimentos = total,
                ativos,
                inativos,
                porSegmento,
                porMunicipio
            });
        }

        // Criar um novo empreendimento
        // POST: api/Empreendimentos
        /// <summary>
        /// Cadastra um novo empreendimento.
        /// </summary>
        /// <remarks>
        /// Cadastra um empreendimento a partir dos dados informados. Tem como retorno, os dados cadastrados e o identificador único, necessário para manipular o registro posteriormente.
        /// </remarks>
        /// <param name="dto">Objeto contendo os dados do empreendimento</param>
        /// <returns>Empreendimento criado</returns>
        /// <response code="201">Empreendimento criado com sucesso</response>
        /// <response code="400">Dados inválidos informados</response>
        [HttpPost]
        [SwaggerRequestExample(typeof(EmpreendimentoSCDto), typeof(EmpreendimentoExample))]
        public async Task<ActionResult> Post(EmpreendimentoSCDto dto)
        {

            if (!Enum.IsDefined(typeof(Segmento), dto.Segmento))
            {
                var valores = Enum.GetValues(typeof(Segmento))
                                 .Cast<Segmento>()
                                 .Select(x => $"{(int)x}-{x}");

                throw new ArgumentException($"Segmento inválido. Valores permitidos: {string.Join(", ", valores)}");
            }

            var empreendimento = new EmpreendimentoSC
            {
                NomeEmpreendimento = dto.NomeEmpreendimento,
                NomeEmpreendedor = dto.NomeEmpreendedor,
                Municipio = dto.Municipio,
                Segmento = (Segmento)dto.Segmento,
                Email = dto.Email,
                Status = dto.Status,
                Telefone = dto.Telefone,
                Observacao = dto.Observacao,
                PorteEmpresa = dto.PorteEmpresa,
                Website = dto.Website
            };

            _context.EmpreendimentosSC.Add(empreendimento);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = empreendimento.Id }, empreendimento);
        }

        // Atualizar um empreendimento existente
        // PUT: api/Empreendimentos/id
        /// <summary>
        /// Atualiza os dados de um empreendimento existente.
        /// </summary>
        /// <remarks>
        /// Atualiza os dados de um empreendimento existente, a partir da informação do identificador único.
        /// </remarks>
        /// <param name="id">Identificador do empreendimento</param>
        /// <param name="dto">Dados atualizados do empreendimento</param>
        /// <returns>Nenhum conteúdo</returns>
        /// <response code="204">Empreendimento atualizado com sucesso</response>
        /// <response code="400">Dados inválidos informados</response>
        /// <response code="404">Empreendimento não encontrado</response>
        [HttpPut("{id}")]
        [SwaggerRequestExample(typeof(EmpreendimentoSCDto), typeof(EmpreendimentoExample))]
        public async Task<IActionResult> Put(int id, EmpreendimentoSCDto dto)
        {
            var empreendimento = await _context.EmpreendimentosSC.FindAsync(id);

            if (empreendimento == null)
            {
                throw new KeyNotFoundException("Empreendimento não encontrado.");
            }

            if (!Enum.IsDefined(typeof(Segmento), dto.Segmento))
            {
                var valores = Enum.GetValues(typeof(Segmento))
                                 .Cast<Segmento>()
                                 .Select(x => $"{(int)x}-{x}");

                throw new ArgumentException($"Segmento inválido. Valores permitidos: {string.Join(", ", valores)}");
            }

            empreendimento.NomeEmpreendimento = dto.NomeEmpreendimento;
            empreendimento.NomeEmpreendedor = dto.NomeEmpreendedor;
            empreendimento.Municipio = dto.Municipio;
            empreendimento.Segmento = (Segmento)dto.Segmento;
            empreendimento.Email = dto.Email;
            empreendimento.Status = dto.Status;
            empreendimento.Telefone = dto.Telefone;
            empreendimento.Observacao = dto.Observacao;
            empreendimento.PorteEmpresa = dto.PorteEmpresa;
            empreendimento.Website = dto.Website;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // Excluir um empreendimento
        // DELETE: api/Empreendimentos/id
        /// <summary>
        /// Remove um empreendimento do sistema.
        /// </summary>
        /// <remarks>
        /// Remove um empreendimento a partir do identificador único.
        /// </remarks>
        /// <param name="id">Identificador do empreendimento</param>
        /// <returns>Nenhum conteúdo</returns>
        /// <response code="204">Empreendimento removido com sucesso</response>
        /// <response code="404">Empreendimento não encontrado</response>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var empreendimento = await _context.EmpreendimentosSC.FindAsync(id);

            if (empreendimento == null)
            {
                throw new KeyNotFoundException("Empreendimento não encontrado.");
            }

            _context.EmpreendimentosSC.Remove(empreendimento);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}

