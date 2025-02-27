namespace Desafio_PicPay.Models.DTOs;

public record TransferenciaDTO(Guid TransferenciaId, CarteiraEntity Remetente, CarteiraEntity Recebedor, decimal ValorTransferido);
