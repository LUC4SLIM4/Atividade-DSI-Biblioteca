using System.ComponentModel.DataAnnotations;
using BibliotecaApp.Application.Validations;

namespace BibliotecaApp.Application.ViewModels;

public class AutorViewModel
{
    public int Id { get; set; }
    
    [Required(ErrorMessage = "O nome é obrigatório")]
    [StringLength(200, MinimumLength = 3, ErrorMessage = "O nome deve ter entre 3 e 200 caracteres")]
    public string Nome { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "O email é obrigatório")]
    [EmailAddress(ErrorMessage = "Email inválido")]
    public string Email { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "A data de nascimento é obrigatória")]
    [DataNascimentoValida(ErrorMessage = "O autor deve ter pelo menos 18 anos")]
    [Display(Name = "Data de Nascimento")]
    public DateTime DataNascimento { get; set; }
    
    [Required(ErrorMessage = "A nacionalidade é obrigatória")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "A nacionalidade deve ter entre 3 e 100 caracteres")]
    public string Nacionalidade { get; set; } = string.Empty;
    
    [Display(Name = "Data de Criação")]
    public DateTime DataCriacao { get; set; }
    
    public int QuantidadeLivros { get; set; }
}

