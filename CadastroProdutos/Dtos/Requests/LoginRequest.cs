using System.ComponentModel.DataAnnotations;

namespace CadastroProdutos.Dtos.Requests;

public class LoginRequest(string usuario, string senha)
{
    [Required] public string Usuario { get; set; } = usuario;
    [Required] public string Senha { get; set; } = senha;
}