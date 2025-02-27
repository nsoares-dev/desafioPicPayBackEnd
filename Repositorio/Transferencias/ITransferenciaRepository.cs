using Desafio_PicPay.Models;
using Microsoft.EntityFrameworkCore.Storage;

namespace Desafio_PicPay.Repositorio.Transferencias;

public interface ITransferenciaRepository
{

    Task AddTransaction(TransferenciaEntity transferenciaEntity);

    Task CommitAsync();

    Task<IDbContextTransaction> BeginTransactionAsync();
    
}
