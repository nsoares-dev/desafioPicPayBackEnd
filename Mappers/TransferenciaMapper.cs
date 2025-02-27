using Desafio_PicPay.Models;
using Desafio_PicPay.Models.DTOs;

namespace Desafio_PicPay.Mappers;

public static class TransferenciaMapper
{
    public static TransferenciaDTO ToTransferenciaDTO(this TransferenciaEntity transferencia)
    {
        return new TransferenciaDTO(
        transferencia.TransferenciaId,
        transferencia.Remetente,
        transferencia.Recebedor,
        transferencia.Valor
            );
    }
}
