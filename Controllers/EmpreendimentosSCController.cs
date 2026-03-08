using CRUDEmpreendimentosSC.Data;
using CRUDEmpreendimentosSC.DTO;
using CRUDEmpreendimentosSC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmpreendimentoSC>>> Get()
        {
            return await _context.EmpreendimentosSC.ToListAsync();
        }

        // Buscar um empreendimento por ID
        // GET: api/Empreendimentos/id
        [HttpGet("{id}")]
        public async Task<ActionResult<EmpreendimentoSC>> Get(int id)
        {
            var empreendimento = await _context.EmpreendimentosSC.FindAsync(id);

            if (empreendimento == null)
                return NotFound();

            return empreendimento;
        }

        // Criar um novo empreendimento
        // POST: api/Empreendimentos
        [HttpPost]
        public async Task<ActionResult> Post(EmpreendimentoSCDto dto)
        {
            var empreendimento = new EmpreendimentoSC
            {
                NomeEmpreendimento = dto.NomeEmpreendimento,
                NomeEmpreendedor = dto.NomeEmpreendedor,
                Municipio = dto.Municipio,
                Segmento = dto.Segmento,
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
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, EmpreendimentoSCDto dto)
        {
            var empreendimento = await _context.EmpreendimentosSC.FindAsync(id);

            if (empreendimento == null)
                return NotFound();

            empreendimento.NomeEmpreendimento = dto.NomeEmpreendimento;
            empreendimento.NomeEmpreendedor = dto.NomeEmpreendedor;
            empreendimento.Municipio = dto.Municipio;
            empreendimento.Segmento = dto.Segmento;
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
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var empreendimento = await _context.EmpreendimentosSC.FindAsync(id);

            if (empreendimento == null)
                return NotFound();

            _context.EmpreendimentosSC.Remove(empreendimento);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}

