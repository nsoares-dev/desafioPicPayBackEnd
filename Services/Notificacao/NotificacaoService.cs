namespace Desafio_PicPay.Services.Notificacao;

public class NotificacaoService : INotificacaoService
{
    public async Task MandarNotificacao()
    {
        await Task.Delay(1000);
        Console.WriteLine("Notificação Enviada");
    }
}
