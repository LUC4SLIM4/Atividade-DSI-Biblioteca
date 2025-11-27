using System.ComponentModel.DataAnnotations;

namespace BibliotecaApp.Application.Validations;

/// <summary>
/// Validação Personalizada 1: Valida se o autor tem pelo menos 18 anos
/// </summary>
public class DataNascimentoValidaAttribute : ValidationAttribute
{
    private const int IdadeMinimaAutor = 18;

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is DateTime dataNascimento)
        {
            var idade = DateTime.Now.Year - dataNascimento.Year;
            
            // Ajusta se ainda não fez aniversário este ano
            if (DateTime.Now.DayOfYear < dataNascimento.DayOfYear)
            {
                idade--;
            }

            if (idade < IdadeMinimaAutor)
            {
                return new ValidationResult(
                    $"O autor deve ter pelo menos {IdadeMinimaAutor} anos. Idade atual: {idade} anos.");
            }

            // Verifica se a data não é futura
            if (dataNascimento > DateTime.Now)
            {
                return new ValidationResult("A data de nascimento não pode ser uma data futura.");
            }

            return ValidationResult.Success;
        }

        return new ValidationResult("Data de nascimento inválida.");
    }
}

