using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class ComentarioController : ControllerBase
{
    private readonly DataContext context;

    public ComentarioController(DataContext Context)
    {
        context = Context;
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] Comentario model)
    {
        try
        {
            context.Comentarios.Add(model);
            await context.SaveChangesAsync();
            return Ok("Comentário salvo com sucesso.");
        }
        catch
        {
            return BadRequest("Falha ao inserir o Comentário.");
        }
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Comentario>>> Get()
    {
        try
        {
            return Ok(await context.Comentarios.ToListAsync());
        }
        catch
        {
            return BadRequest("Erro ao obter os Comentários.");
        }
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Put([FromRoute] int id, [FromBody] Comentario model)
    {
        if (id != model.Id)
            return BadRequest();

        try
        {
            if (await context.Comentarios.AnyAsync(p => p.Id == id) == false)
                return NotFound();

            context.Comentarios.Update(model);
            await context.SaveChangesAsync();
            return Ok("Comentario salvo com sucesso.");
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
            Comentario model = await context.Comentarios.FindAsync(id);

            if (model == null)
                return NotFound();

            context.Comentarios.Remove(model);
            await context.SaveChangesAsync();
            return Ok("Comentário removido com sucesso.");
        }
        catch
        {
            return BadRequest("Falha ao remover o Comentário.");
        }
    }

}