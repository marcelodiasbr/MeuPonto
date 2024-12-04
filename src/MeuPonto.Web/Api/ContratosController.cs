using MeuPonto.Data;
using MeuPonto.Models.Contratos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MeuPonto.Api;

[Route("api/[controller]")]
[ApiController]
public class ContratosController : ControllerBase
{
    private readonly MeuPontoDbContext _db;

    public ContratosController(MeuPontoDbContext db)
    {
        _db = db;
    }

    // GET: api/Contratos
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Contrato>>> GetContratos()
    {
        return await _db.Contratos.ToListAsync();
    }

    // POST: api/Contratos
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Contrato>> PostContrato(Contrato contrato)
    {
        _db.Contratos.Add(contrato);

        await _db.SaveChangesAsync();

        return CreatedAtAction("GetContrato", new { id = contrato.Id }, contrato);
    }

    // GET: api/Contratos/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Contrato>> GetContrato(Guid? id)
    {
        var contrato = await _db.Contratos.FindAsync(id);

        if (contrato == null)
        {
            return NotFound();
        }

        return contrato;
    }

    // PUT: api/Contratos/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutContrato(Guid? id, Contrato contrato)
    {
        if (id != contrato.Id)
        {
            return BadRequest();
        }

        _db.Entry(contrato).State = EntityState.Modified;

        try
        {
            await _db.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ContratoExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    // DELETE: api/Contratos/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteContrato(Guid? id)
    {
        var contrato = await _db.Contratos.FindAsync(id);

        if (contrato == null)
        {
            return NotFound();
        }

        _db.Contratos.Remove(contrato);

        await _db.SaveChangesAsync();

        return NoContent();
    }

    private bool ContratoExists(Guid? id)
    {
        return _db.Contratos.Any(e => e.Id == id);
    }
}
