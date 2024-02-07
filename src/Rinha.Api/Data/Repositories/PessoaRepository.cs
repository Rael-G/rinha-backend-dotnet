using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Rinha.Api;

public class PessoaRepository(ApplicationDbContext context) : IPessoaRepository
{
    private readonly ApplicationDbContext _context = context;

    public async Task CreateAsync(Pessoa pessoa) =>
        await _context.Pessoas.AddAsync(pessoa);

    public async Task<PessoaViewModel?> GetByIdAsync(Guid id) =>
        await _context.Pessoas.Where(p => p.Id == id)
        .Select(p => new PessoaViewModel
        {
            Id = p.Id,
            Apelido = p.Apelido,
            Nome = p.Nome,
            Nascimento = p.Nascimento,
            Stack = p.Stack
        })
        .FirstOrDefaultAsync();

    public async Task<IEnumerable<PessoaViewModel>> SearchAsync(string termo) => 
        await _context.Pessoas
            .Where(p =>
                p.Searchable.Contains(termo.ToLower())
            )
            .Select(p => new PessoaViewModel
            {
                Id = p.Id,
                Apelido = p.Apelido,
                Nome = p.Nome,
                Nascimento = p.Nascimento,
                Stack = p.Stack
            })
            .Take(50)
            .ToListAsync();

    public async Task<int> CountAsync() =>
        await _context.Pessoas.CountAsync();
    

    public async Task CommitAsync() =>
        await _context.SaveChangesAsync();
}
