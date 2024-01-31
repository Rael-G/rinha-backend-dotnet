using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Rinha.Api;

public class PessoaRepository(ApplicationDbContext context) : IPessoaRepository
{
    private readonly ApplicationDbContext _context = context;

    public async Task<int> Count()
    {
        return await _context.Pessoas.CountAsync();
    }

    public async Task Create(Pessoa pessoa)
    {
        await _context.Pessoas.AddAsync(pessoa);
    }

    public async Task<Pessoa?> GetById(Guid id)
    {
        return await _context.Pessoas.Where(p => p.Id == id).FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<Pessoa>> Search(string termo)
    {
        return await _context.Pessoas.Where(p =>
            p.Apelido.Contains(termo) ||
            p.Nome.Contains(termo) ||
            p.Stack.Any(s => s.Contains(termo))
            ).Select(p => p).ToListAsync();
    }

    public async Task Commit()
    {
        await _context.SaveChangesAsync();
    }
}
