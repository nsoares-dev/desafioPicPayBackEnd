using Desafio_PicPay.Models.Enum;
using Desafio_PicPay.Util;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Desafio_PicPay.Models.Requisito;

public class CarteiraRequest
{

    #region Model

    [Required(ErrorMessage = "Seu nome completo é obrigatório.")]
    public string NomeCompleto { get; set; }

    [Required(ErrorMessage = "O CPF/CNPJ é obrigatório.")]
    [ValidarCPFCNPJ(ErrorMessage = "CPF/CNPJ deve ser válido")]
    public string CPFCNPJ { get; set; }

    [Required(ErrorMessage = "O e-mail é obrigatório.")]
    public string Email { get; set; }

    [Required(ErrorMessage = "A senha é obrigatória.")]
    public string Senha { get; set; }

    [Required(ErrorMessage = "É necessário nos passar o valor.")]
    public decimal SaldoConta { get; set; }
    [Required(ErrorMessage = "Você é usuário ou vendedor?")]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public TipoUsuario TipoUsuario { get; set; }

    #endregion

}
