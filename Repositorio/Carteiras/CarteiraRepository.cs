using Desafio_PicPay.DB;
using Desafio_PicPay.Models;
using Microsoft.EntityFrameworkCore;

namespace Desafio_PicPay.Repositorio.Carteiras;

public class CarteiraRepository : ICarteiraRepository
{
    private readonly AppDbContext _context;
    public CarteiraRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(CarteiraEntity carteira)
    {
        await _context.AddAsync(carteira);
    }
    public async Task UpdateAsync(CarteiraEntity carteira)
    {
        _context.Update(carteira);
    }
    public async Task<CarteiraEntity?> GetbyCpfCnpj(string cpfCnpj, string email)
    {
        return await _context.Carteiras
            .FirstOrDefaultAsync(carteira => carteira.CPFCNPJ.Equals(cpfCnpj)
            || carteira.Email.Equals(email));
    }
    public async Task<CarteiraEntity?> GetById(int id)
    {
        return await _context.Carteiras.FindAsync(id);
    }

    public async Task CommitAsync()
    {
        await _context.SaveChangesAsync();
    }
}
