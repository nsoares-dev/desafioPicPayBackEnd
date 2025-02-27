using Desafio_PicPay.Models.Requisito;
using Desafio_PicPay.Services.Transferencias;
using Microsoft.AspNetCore.Mvc;

namespace Desafio_PicPay.Controllers;

[ApiController]
[Route("[controller]")]
public class TransferenciaController : ControllerBase
{
    private readonly ITransferenciaService _transferenciaService;

    public TransferenciaController(ITransferenciaService transferenciaService)
    {
        _transferenciaService = transferenciaService;
    }

    [HttpPost]
    public async Task<IActionResult> PostTransferencia(TransferenciaRequest request)
    {
        var result = await _transferenciaService.ExecuteAsync(request);

        if (!result.Success)
            return BadRequest(result);

        return Ok(result);
    }
}
