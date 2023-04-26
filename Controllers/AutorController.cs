using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class AutorController : ControllerBase
{
    private readonly DataContext context;

    public AutorController(DataContext Context)
    {
        context = Context;
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] Autor model)
    {
        try
        {
            context.Autores.Add(model);
            await context.SaveChangesAsync();
            return Ok("Autor salvo com sucesso.");
        }
        catch
        {
            return BadRequest("Falha ao inserir o Autor.");
        }
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Autor>>> Get()
    {
        try
        {
            return Ok(await context.Autores.ToListAsync());
        }
        catch
        {
            return BadRequest("Erro ao obter os Autores.");
        }
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Put([FromRoute] int id, [FromBody] Autor model)
    {
        if (id != model.Id)
            return BadRequest();

        try
        {
            if (await context.Autores.AnyAsync(p => p.Id == id) == false)
                return NotFound();

            context.Autores.Update(model);
            await context.SaveChangesAsync();
            return Ok("Autor salvo com sucesso");
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
            Autor model = await context.Autores.FindAsync(id);

            if (model == null)
                return NotFound();

            context.Autores.Remove(model);
            await context.SaveChangesAsync();
            return Ok("Autor removido com sucesso");
        }
        catch
        {
            return BadRequest("Falha ao remover o Autor");
        }
    }

}