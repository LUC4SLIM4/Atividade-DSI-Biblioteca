using System.ComponentModel.DataAnnotations;
using BibliotecaApp.Application.Validations;

namespace BibliotecaApp.Application.ViewModels;

public class LivroViewModel
{
    public int Id { get; set; }
    
    [Required(ErrorMessage = "O título é obrigatório")]
    [StringLength(300, MinimumLength = 1, ErrorMessage = "O título deve ter entre 1 e 300 caracteres")]
    public string Titulo { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "O ISBN é obrigatório")]
    [ISBNValido(ErrorMessage = "ISBN inválido. Deve ter 10 ou 13 dígitos")]
    public string ISBN { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "O ano de publicação é obrigatório")]
    [Range(1450, 2100, ErrorMessage = "Ano de publicação inválido")]
    [Display(Name = "Ano de Publicação")]
    public int AnoPublicacao { get; set; }
    
    [Required(ErrorMessage = "O gênero é obrigatório")]
    [StringLength(100, ErrorMessage = "O gênero deve ter no máximo 100 caracteres")]
    public string Genero { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "O número de páginas é obrigatório")]
    [Range(1, 10000, ErrorMessage = "O número de páginas deve estar entre 1 e 10000")]
    [Display(Name = "Número de Páginas")]
    public int NumeroPaginas { get; set; }
    
    [Required(ErrorMessage = "O preço é obrigatório")]
    [Range(0.01, 999999.99, ErrorMessage = "O preço deve ser maior que zero")]
    [DataType(DataType.Currency)]
    public decimal Preco { get; set; }
    
    [Required(ErrorMessage = "O autor é obrigatório")]
    [Display(Name = "Autor")]
    public int AutorId { get; set; }
    
    public string? AutorNome { get; set; }
    
    [Display(Name = "Data de Criação")]
    public DateTime DataCriacao { get; set; }
}

