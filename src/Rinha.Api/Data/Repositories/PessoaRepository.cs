using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Rinha.Api;

public class PessoaRepository(ApplicationDbContext context) : IPessoaRepository
{
    private readonly ApplicationDbContext _context = context;

    public async Task CreateAsync(Pessoa pessoa) =>
        await _context.Pessoas.AddAsync(pessoa);

    public async Task<Pessoa?> GetByIdAsync(Guid id) =>
        await _context.Pessoas.Where(p => p.Id == id).FirstOrDefaultAsync();

    public async Task<IEnumerable<Pessoa>> SearchAsync(string termo) => await _context.Pessoas
            .Where(p =>
                p.Apelido.Contains(termo) ||
                p.Nome.Contains(termo) ||
                (p.Stack != null && p.Stack.Any(s => s.Contains(termo)))
            )
            .Take(50)
            .ToListAsync();

    public async Task<int> CountAsync() =>
        await _context.Pessoas.CountAsync();
    

    public async Task CommitAsync() =>
        await _context.SaveChangesAsync();
}
