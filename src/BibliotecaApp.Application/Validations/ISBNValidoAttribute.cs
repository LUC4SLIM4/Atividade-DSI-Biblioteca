using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace BibliotecaApp.Application.Validations;

/// <summary>
/// Validação Personalizada 2: Valida o formato do ISBN (10 ou 13 dígitos)
/// </summary>
public class ISBNValidoAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is string isbn)
        {
            // Remove hífens e espaços
            isbn = Regex.Replace(isbn, @"[\s-]", "");

            // Verifica se tem 10 ou 13 dígitos
            if (isbn.Length != 10 && isbn.Length != 13)
            {
                return new ValidationResult(
                    "O ISBN deve conter 10 ou 13 dígitos (hífens e espaços são permitidos).");
            }

            // Verifica se contém apenas dígitos (ISBN-10 pode ter X no final)
            if (isbn.Length == 10)
            {
                if (!Regex.IsMatch(isbn, @"^\d{9}[\dX]$"))
                {
                    return new ValidationResult(
                        "ISBN-10 deve conter 9 dígitos seguidos de um dígito ou X.");
                }
                
                // Validação do checksum ISBN-10
                if (!ValidarISBN10(isbn))
                {
                    return new ValidationResult("ISBN-10 inválido (falha na verificação do dígito verificador).");
                }
            }
            else // ISBN-13
            {
                if (!Regex.IsMatch(isbn, @"^\d{13}$"))
                {
                    return new ValidationResult("ISBN-13 deve conter apenas 13 dígitos.");
                }
                
                // Validação do checksum ISBN-13
                if (!ValidarISBN13(isbn))
                {
                    return new ValidationResult("ISBN-13 inválido (falha na verificação do dígito verificador).");
                }
            }

            return ValidationResult.Success;
        }

        return new ValidationResult("ISBN inválido.");
    }

    private bool ValidarISBN10(string isbn)
    {
        int soma = 0;
        for (int i = 0; i < 9; i++)
        {
            soma += (isbn[i] - '0') * (10 - i);
        }
        
        char ultimoCaractere = isbn[9];
        int digitoVerificador = ultimoCaractere == 'X' ? 10 : (ultimoCaractere - '0');
        soma += digitoVerificador;
        
        return soma % 11 == 0;
    }

    private bool ValidarISBN13(string isbn)
    {
        int soma = 0;
        for (int i = 0; i < 12; i++)
        {
            int digito = isbn[i] - '0';
            soma += (i % 2 == 0) ? digito : digito * 3;
        }
        
        int digitoVerificador = isbn[12] - '0';
        int calculado = (10 - (soma % 10)) % 10;
        
        return digitoVerificador == calculado;
    }
}

