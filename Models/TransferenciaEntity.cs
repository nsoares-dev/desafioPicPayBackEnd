namespace Desafio_PicPay.Models;

public class TransferenciaEntity
{
    #region Model
    public Guid TransferenciaId { get; set; }
    public int RemetenteId { get; set; }
    public CarteiraEntity Remetente { get; set; }
    public int RecebedorId { get; set; }
    public CarteiraEntity Recebedor { get; set; }
    public decimal Valor { get; set; }

    #endregion

    #region CTOR
    public TransferenciaEntity(int remetenteId, int recebedorId, decimal valor)
    {
        TransferenciaId = Guid.NewGuid();
        RemetenteId = remetenteId;
        RecebedorId = recebedorId;
        Valor = valor;
    }
    #endregion

    private TransferenciaEntity() { }
}
