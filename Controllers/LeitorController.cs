using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class LeitorController : ControllerBase
{
    private readonly DataContext context;

    public LeitorController(DataContext Context)
    {
        context = Context;
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] Leitor model)
    {
        try
        {
            context.Leitores.Add(model);
            await context.SaveChangesAsync();
            return Ok("Leitor salvo com sucesso");
        }
        catch
        {
            return BadRequest("Falha ao inserir o Leitor.");
        }
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Leitor>>> Get()
    {
        try
        {
            return Ok(await context.Leitores.ToListAsync());
        }
        catch
        {
            return BadRequest("Erro ao obter os Leitores.");
        }
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Put([FromRoute] int id, [FromBody] Leitor model)
    {
        if (id != model.Id)
            return BadRequest();

        try
        {
            if (await context.Leitores.AnyAsync(p => p.Id == id) == false)
                return NotFound();

            context.Leitores.Update(model);
            await context.SaveChangesAsync();
            return Ok("Leitor salvo com sucesso.");
        }
        catch
        {
            return BadRequest();
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete([FromRoute] int id)
    {
        try
        {
            Leitor model = await context.Leitores.FindAsync(id);

            if (model == null)
                return NotFound();

            context.Leitores.Remove(model);
            await context.SaveChangesAsync();
            return Ok("Leitor removido com sucesso.");
        }
        catch
        {
            return BadRequest("Falha ao remover o Leitor.");
        }
    }
}