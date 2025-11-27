namespace BibliotecaApp.Domain.Entities;

public class Livro
{
    public int Id { get; set; }
    public string Titulo { get; set; } = string.Empty;
    public string ISBN { get; set; } = string.Empty;
    public int AnoPublicacao { get; set; }
    public string Genero { get; set; } = string.Empty;
    public int NumeroPaginas { get; set; }
    public decimal Preco { get; set; }
    public DateTime DataCriacao { get; set; }
    
    // Chave estrangeira explícita
    public int AutorId { get; set; }
    
    // Propriedade de navegação
    public virtual Autor Autor { get; set; } = null!;
}

