using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using System.Text.Json;

namespace Desafio_PicPay.Services.Autorizador;

public class AutorizadorService : IAutorizadorService
{

    private readonly HttpClient _httpClient;

    public AutorizadorService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    private const string url = "https://util.devi.tools/api/v2/authorize";

    public async Task<bool> AuthorizeAsync()
    {
        string content = string.Empty;

        var response = await _httpClient.GetAsync(url);

        if (!response.IsSuccessStatusCode)
            return false;

        response.EnsureSuccessStatusCode();

        content = await response.Content.ReadAsStringAsync();

        var result = JsonSerializer.Deserialize<ApiResponse>(content);

        return result?.status == "success";
    }

    private class ApiResponse
    {
        public string status { get; set; }
        public Response data { get; set; }
    }

    private class Response
    {
        public bool authorization { get; set; }
    }
}
