using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class NoticiaController : ControllerBase
{

    private readonly DataContext context;

    public NoticiaController(DataContext Context)
    {
        context = Context;
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] Noticia model)
    {
        try
        {
            context.Noticias.Add(model);
            await context.SaveChangesAsync();
            return Ok("Notícia salva com sucesso.");
        }
        catch
        {
            return BadRequest("Falha ao inserir a Notícia.");
        }
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Noticia>>> Get()
    {
        try
        {
            return Ok(await context.Noticias.ToListAsync());
        }
        catch
        {
            return BadRequest("Erro ao obter as Notícias.");
        }
    }

 [HttpPut("{id}")]
    public async Task<ActionResult> Put([FromRoute] int id, [FromBody] Noticia model)
    {
        if (id != model.Id)
            return BadRequest();

        try
        {
            if (await context.Noticias.AnyAsync(p => p.Id == id) == false)
                return NotFound();

            context.Noticias.Update(model);
            await context.SaveChangesAsync();
            return Ok("Notícia salva com sucesso.");
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
            Noticia model = await context.Noticias.FindAsync(id);

            if (model == null)
                return NotFound();

            context.Noticias.Remove(model);
            await context.SaveChangesAsync();
            return Ok("Notícia removida com sucesso.");
        }
        catch
        {
            return BadRequest("Falha ao remover a Notícia.");
        }
    }

}