using Desafio_PicPay.Models;
using Desafio_PicPay.Repositorio;

namespace Desafio_PicPay.Repositorio.Carteiras;

public interface ICarteiraRepository 
{
    Task AddAsync(CarteiraEntity carteira);

    Task UpdateAsync(CarteiraEntity carteira);

    Task<CarteiraEntity?> GetbyCpfCnpj(string cpfCnpf, string email);

    Task<CarteiraEntity?> GetById(int id);

    Task CommitAsync();
}
