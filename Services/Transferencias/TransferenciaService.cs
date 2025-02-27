using Desafio_PicPay.Mappers;
using Desafio_PicPay.Models;
using Desafio_PicPay.Models.DTOs;
using Desafio_PicPay.Models.Enum;
using Desafio_PicPay.Models.Requisito;
using Desafio_PicPay.Models.Respostas;
using Desafio_PicPay.Repositorio.Carteiras;
using Desafio_PicPay.Repositorio.Transferencias;
using Desafio_PicPay.Services.Autorizador;
using Desafio_PicPay.Services.Notificacao;


namespace Desafio_PicPay.Services.Transferencias;

public class TransferenciaService : ITransferenciaService
{
    private readonly ICarteiraRepository _carteiraRepository;
    private readonly ITransferenciaRepository _transferenciaRepository;
    private readonly IAutorizadorService _autorizadorService;
    private readonly INotificacaoService _notificacaoService;

    public TransferenciaService(ICarteiraRepository carteiraRepository, ITransferenciaRepository transferenciaRepository, IAutorizadorService AutorizadorService, INotificacaoService notificacaoService)
    {
        _carteiraRepository = carteiraRepository;
        _transferenciaRepository = transferenciaRepository;
        _autorizadorService = AutorizadorService;
        _notificacaoService = notificacaoService;
    }

    public async Task<Result<TransferenciaDTO>> ExecuteAsync(TransferenciaRequest request)
    {
        if (!await _autorizadorService.AuthorizeAsync())
            return Result<TransferenciaDTO>.Failure("Não Autorizado");

        var pagador = await _carteiraRepository.GetById(request.RemetenteId);
        var recebedor = await _carteiraRepository.GetById(request.RecebedorId);

        if (pagador == null || recebedor == null)
            return Result<TransferenciaDTO>.Failure("Nenhum Usuário encontrado.");

        if (pagador.SaldoConta < request.Valor || pagador.SaldoConta == 0)
            return Result<TransferenciaDTO>.Failure("Saldo insuficiente");

        if (pagador.TipoUsuario == TipoUsuario.Vendedor)
            return Result<TransferenciaDTO>.Failure("Seu tipo de usuário não tem permissão para realizar transferência.");

        pagador.DebitarSaldo(request.Valor);
        recebedor.CreditarSaldo(request.Valor);

        var transferencia = new TransferenciaEntity(
            pagador.CarteiraId,
            recebedor.CarteiraId,
            request.Valor
            );

        using (var transferenciaRetorno = await _transferenciaRepository.BeginTransactionAsync())
        {
            try
            {
                var updateTasks = new List<Task>
                {
                    _carteiraRepository.UpdateAsync(pagador),
                    _carteiraRepository.UpdateAsync(recebedor),
                    _transferenciaRepository.AddTransaction(transferencia)
                };

                await Task.WhenAll(updateTasks);
                
                await _carteiraRepository.CommitAsync();
                await _transferenciaRepository.CommitAsync();
                
                await transferenciaRetorno.CommitAsync();

            }
            catch (Exception ex)
            {
                await transferenciaRetorno.RollbackAsync();
                return Result<TransferenciaDTO>.Failure("Error ao realizar a transferência: " + ex.Message);
            }
            //return;
        }
        await _notificacaoService.MandarNotificacao();
        return Result<TransferenciaDTO>.Sucess(transferencia.ToTransferenciaDTO());
    }
}