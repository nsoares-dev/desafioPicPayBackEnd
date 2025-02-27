namespace Desafio_PicPay.Util;

public static class ValidaCPFCNPJ
{
    public static bool Cpf(string cpf)
    {
        return Valid(cpf, 11, new int[] { 10, 9, 8, 7, 6, 5, 4, 3, 2 }, new int[] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 });
    }

    public static bool Cnpj(string cnpj)
    {
        return Valid(cnpj, 14, new int[] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 }, new int[] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 });
    }
    public static bool ValidCpfCnpj(string cpfCnpj)
    {
        return cpfCnpj.Length == 11 ? Cpf(cpfCnpj) : (cpfCnpj.Length == 14 ? Cnpj(cpfCnpj) : false);
    }
    private static bool Valid(string value, int expectedLength, int[] firstMultipliers, int[] secondMultipliers)
    {
        if (value.Length != expectedLength || !long.TryParse(value, out _))
            return false;

        int firstSum = 0, secondSum = 0;

        // calcular os dois dígitos verificadores em uma única iteração
        for (int i = 0; i < expectedLength - 2; i++)
        {
            var digit = int.Parse(value[i].ToString());
            firstSum += digit * firstMultipliers[i];
            secondSum += digit * secondMultipliers[i];
        }

        // primeiro dígito verificador
        var firstVerifier = Verificador(firstSum);

        // adiciona o primeiro dígito para o cálculo do segundo verificador
        secondSum += firstVerifier * secondMultipliers[expectedLength - 2];

        // segundo dígito verificador
        var secondVerifier = Verificador(secondSum);

        // comparação final
        return value.EndsWith(firstVerifier.ToString() + secondVerifier.ToString());
    }
    private static int Verificador(int sum)
    {
        var remainder = sum % 11;
        return remainder < 2 ? 0 : 11 - remainder;
    }
}
