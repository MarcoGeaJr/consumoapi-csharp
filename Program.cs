using ConsumoAPI.Models;
using Newtonsoft.Json;

Console.WriteLine("Informe seu CEP: ");
var cep = Console.ReadLine();
Console.WriteLine("");

var client = new HttpClient
{
    BaseAddress = new System.Uri("https://viacep.com.br/")
};

var response = client.GetAsync($"ws/{cep}/json").Result;

if (response.IsSuccessStatusCode)
{
    Endereco endereco = JsonConvert.DeserializeObject<Endereco>(response.Content.ReadAsStringAsync().Result) ?? new Endereco();
    Console.WriteLine(endereco.ToString());
}