using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Rinha.Api;

[Index(nameof(Apelido), IsUnique = true)]
public class Pessoa(string apelido, string nome, DateTime nascimento, string[]? stack)
{
    public Guid Id {get; private set;}

    [Required]
    [MaxLength(32)]
    public string Apelido {get; private set;} = apelido;

    [Required]
    [MaxLength(100)]
    public string Nome {get; private set;} = nome;

    [Required]
    public DateTime Nascimento {get; private set;} = nascimento.ToUniversalTime();
    
    [MaxLength(32)]
    public string[]? Stack {get; private set;} = stack;

    public string Searchable
    {
        get { return $"{Nome.ToLower()} {Apelido.ToLower()} {(Stack != null ? string.Join(" ", Stack).ToLower() : string.Empty)}"; }
        private set {}
    }
}
