using System.Data.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Rinha.Api;

[ApiController]
public class PessoasController(IPessoaRepository pessoas) : ControllerBase
{
    private readonly IPessoaRepository _pessoas = pessoas;

    [HttpPost]
    [Route("pessoas")]
    public async Task<IActionResult> Create(Pessoa pessoa)
    {
        if (!ModelState.IsValid)
            return UnprocessableEntity();

        await _pessoas.CreateAsync(pessoa);

        try
        {
            await _pessoas.CommitAsync();
        }
        catch(DbUpdateException)
        {
            return UnprocessableEntity();
        }

        return CreatedAtAction(nameof(GetById), new {id = pessoa.Id}, pessoa);
    }

    [HttpGet]
    [Route("pessoas/{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var pessoa = await _pessoas.GetByIdAsync(id);
        if (pessoa == null)
            return NotFound();

        return Ok(pessoa);
    }

    [HttpGet]
    [Route("pessoas")]
    public async Task<IActionResult> Search([FromQuery(Name = "t")] string termo) =>
        Ok(await _pessoas.SearchAsync(termo));

    [HttpGet]
    [Route("contagem-pessoas")]
    public async Task<IActionResult> Count() =>
        Ok(await _pessoas.CountAsync());

}