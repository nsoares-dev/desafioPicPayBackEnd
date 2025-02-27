using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;

namespace Desafio_PicPay.Models.Requisito;

public class TransferenciaRequest
{

    #region Model
    [Required(ErrorMessage = "Este campo é obrigatório.")]
    public decimal Valor { get; set; }

    [Required(ErrorMessage = "Este campo é obrigatório.")]
    public int RemetenteId { get; set; }

    [Required(ErrorMessage = "Este campo é obrigatório.")]
    public int RecebedorId  { get; set; }
    #endregion

}
