using Desafio_PicPay.Models;
using Desafio_PicPay.Models.Requisito;
using Desafio_PicPay.Models.Respostas;
using Desafio_PicPay.Repositorio.Carteiras;
using Desafio_PicPay.DB;

namespace Desafio_PicPay.Services.Carteiras;

public class CarteiraService : ICarteiraService
{
    private readonly ICarteiraRepository _repository;

    public CarteiraService(ICarteiraRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<bool>> ExecuteAsync(CarteiraRequest request)
    {
        try
        {
            var carteiraExiste = await _repository.GetbyCpfCnpj(request.CPFCNPJ, request.Email);

            if (carteiraExiste != null)
                return Result<bool>.Failure("Essa carteira já existe");

            var carteira = new CarteiraEntity(
                request.NomeCompleto,
                request.CPFCNPJ,
                request.Email,
                request.Senha,
                request.TipoUsuario,
                request.SaldoConta
                );

            await _repository.AddAsync(carteira);
            await _repository.CommitAsync();

            return Result<bool>.Sucess(true);
        }
        catch (Exception ex)
        {
            return Result<bool>.Failure(ex.ToString());
        }
    }
}