namespace Desafio_PicPay.Services.Autorizador;

public interface IAutorizadorService
{
    Task<bool> AuthorizeAsync();
}
