using Desafio_PicPay.DB;
using Desafio_PicPay.Models;
using Microsoft.EntityFrameworkCore.Storage;

namespace Desafio_PicPay.Repositorio.Transferencias;

public class TransferenciaRepository : ITransferenciaRepository
{

    private readonly AppDbContext _context;
    public TransferenciaRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddTransaction(TransferenciaEntity transferenciaEntity)
    {
        await _context.Transferencias.AddAsync(transferenciaEntity);
    }

    public async Task CommitAsync()
    {
        await _context.SaveChangesAsync();
    }

    public async Task<IDbContextTransaction> BeginTransactionAsync()
    {
        return await _context.Database.BeginTransactionAsync();
    }
}
