using Desafio_PicPay.Models.Enum;
using System.ComponentModel.DataAnnotations;

namespace Desafio_PicPay.Models;

public class CarteiraEntity
{
    #region Model
    [Key]
    public int CarteiraId { get; set; }
    public string NomeCompleto { get; set; }
    public string CPFCNPJ { get; set; }
    public string Email { get; set; }
    public string Senha { get; set; }
    public decimal SaldoConta { get; set; }
    public TipoUsuario TipoUsuario { get; set; }

    #endregion Model

    private CarteiraEntity() { }

    #region CTOR

    public CarteiraEntity(string nomeCompleto, string cpfcnpj, string email, string senha, TipoUsuario tipoUsuario, decimal saldoConta = 0)
    {
        NomeCompleto = nomeCompleto;
        CPFCNPJ = cpfcnpj;
        Email = email;
        Senha = senha;
        TipoUsuario = tipoUsuario;
        SaldoConta = saldoConta;

    }

    #endregion

    #region Função Debitar
    public void DebitarSaldo(decimal valor)
    {
        SaldoConta -= valor;
    }

    #endregion

    #region Função Creditar
    public void CreditarSaldo(decimal valor)
    {
        SaldoConta += valor;
    }

    #endregion
}