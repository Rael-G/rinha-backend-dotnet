namespace Rinha.Api;

public interface IPessoaRepository
{
    Task<Pessoa?> GetById(Guid id);
    Task<IEnumerable<Pessoa>> Search(string termo);
    Task<int> Count();
    Task Create(Pessoa pessoa);
    Task Commit();
}
