namespace Desafio_PicPay.Models.Respostas;

public class Result<T>
{
    public bool Success { get; private set; }
    public string MensagemErro { get; private set; }
    public T Value { get; private set; }

    private Result(bool success, T value, string mensagemErro)
    {   
        Success = success;
        MensagemErro = mensagemErro;
        Value = value;
    }
    private Result(bool success)
    {
        Success = success;
    }

    public static Result<T> Sucess(T value) => new Result<T>(true, value, null);
    public static Result<T> Failure(string mensagemErro) => new Result<T>(false, default, mensagemErro);
}
