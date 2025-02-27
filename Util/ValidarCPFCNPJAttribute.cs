using System.ComponentModel.DataAnnotations;

namespace Desafio_PicPay.Util;

public class ValidarCPFCNPJAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object value, ValidationContext validationContext)
    {
        var cpfCnpj = value as string;

        if (string.IsNullOrEmpty(cpfCnpj) || !ValidaCPFCNPJ.ValidCpfCnpj(cpfCnpj))
        {
            return new ValidationResult(ErrorMessage);
        }

        return ValidationResult.Success;
    }
}
