namespace BibliotecaApp.Domain.Entities;

public class Autor
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public DateTime DataNascimento { get; set; }
    public string Nacionalidade { get; set; } = string.Empty;
    public DateTime DataCriacao { get; set; }
    
    // Relacionamento 1:N - Um autor pode ter vários livros
    public virtual ICollection<Livro> Livros { get; set; } = new List<Livro>();
}

