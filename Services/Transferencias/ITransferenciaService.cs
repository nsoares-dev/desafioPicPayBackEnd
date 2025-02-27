using Desafio_PicPay.Models;
using Desafio_PicPay.Models.Requisito;
using Desafio_PicPay.Repositorio;
using Desafio_PicPay.Models.Respostas;
using Desafio_PicPay.Models.DTOs;

namespace Desafio_PicPay.Services.Transferencias;

public interface ITransferenciaService
{
    Task<Result<TransferenciaDTO>> ExecuteAsync(TransferenciaRequest request);
}
