namespace Rinha.Api;

public interface IPessoaRepository
{
    Task<PessoaViewModel?> GetByIdAsync(Guid id);
    Task<IEnumerable<PessoaViewModel>> SearchAsync(string termo);
    Task<int> CountAsync();
    Task CreateAsync(Pessoa pessoa);
    Task CommitAsync();
}
