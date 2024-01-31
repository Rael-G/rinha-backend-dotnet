using Microsoft.AspNetCore.Mvc;

namespace Rinha.Api;

[ApiController]
[Route("pessoas")]
public class PessoasController : ControllerBase
{
    private readonly IPessoaRepository _pessoas;
    public PessoasController(IPessoaRepository pessoas)
    {
        _pessoas = pessoas;
    }

    [HttpPost]
    public async Task<IActionResult> Create(Pessoa pessoa)
    {
        if (!ModelState.IsValid)
            return BadRequest();
        await _pessoas.Create(pessoa);
        await _pessoas.Commit();
        return Ok();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var pessoa = await _pessoas.GetById(id);
        if (pessoa == null)
            return NotFound();

        return Ok(pessoa);
    }

    [HttpGet]
    public async Task<IActionResult> Search([FromQuery(Name = "t")] string termo)
    {
        return Ok(await _pessoas.Search(termo));
    }

    [HttpGet]
    [Route("contagem-pessoas")]
    public async Task<IActionResult> Count()
    {
        return Ok(await _pessoas.Count());
    }

}