using System.ComponentModel.DataAnnotations;

namespace itservicecenter.Helper;

public class ValidatorLozinka : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        var lozinka = value as string;
        if (string.IsNullOrEmpty(lozinka) || lozinka.Length < 8 || !lozinka.Any(char.IsDigit))
            return new ValidationResult(
                "Lozinka mora imati najmanje 8 znakova i najmanje jednu cifru.");
        return ValidationResult.Success;
    }
}

public class ValidatorLozinkaOpcionalna : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        var lozinka = value as string;
        if (lozinka.Length < 8 || !lozinka.Any(char.IsDigit))
            return new ValidationResult(
                "Lozinka mora imati najmanje 8 znakova i najmanje jednu cifru.");
        return ValidationResult.Success;
    }
}