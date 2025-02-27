using Desafio_PicPay.Models.Requisito;
using Desafio_PicPay.Services.Carteiras;
using Microsoft.AspNetCore.Mvc;

namespace Desafio_PicPay.Controllers;

[ApiController]
[Route("[controller]")]
public class CarteiraController : ControllerBase
{
    private readonly ICarteiraService _carteiraService;
    public CarteiraController(ICarteiraService carteiraService)
    {
        _carteiraService = carteiraService;
    }

    [HttpPost]
    [Route("CriarCarteira")]
    public async Task<IActionResult> PostCarteira(CarteiraRequest request)
    {
        var result = await _carteiraService.ExecuteAsync(request);

        if (!result.Success)
            return BadRequest(result);

        return Created();
    }
}
