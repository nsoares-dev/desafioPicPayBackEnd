using Desafio_PicPay.Models.Respostas;
using Desafio_PicPay.Models.Requisito;

namespace Desafio_PicPay.Services.Carteiras;

public interface ICarteiraService
{
    Task<Result<bool>> ExecuteAsync(CarteiraRequest request);
}
