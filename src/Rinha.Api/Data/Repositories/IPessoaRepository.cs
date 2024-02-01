namespace Rinha.Api;

public interface IPessoaRepository
{
    Task<Pessoa?> GetByIdAsync(Guid id);
    Task<IEnumerable<Pessoa>> SearchAsync(string termo);
    Task<int> CountAsync();
    Task CreateAsync(Pessoa pessoa);
    Task CommitAsync();
}
