using System.ComponentModel.DataAnnotations;

public class Autor
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Nome é obrigatório")]
    [MinLength(3, ErrorMessage = "O Nome deve conter no mínimo 3 caracteres.")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "E-mail é obrigatório.")]
    [EmailAddress]
    public string Email { get; set; }

    [Required(ErrorMessage = "O apelido é Obrigatório.")]
    public string Apelido { get; set; }

    // [Required(ErrorMessage = "Data de Nascimento é obrigatória.")]
    [Range(typeof(DateTime), "01-01-1900", "31-12-2100")]
    public DateTime Nascimento { get; set; }

    [Required(ErrorMessage = "Senha é obrigatória.")]
    [MinLength(8, ErrorMessage = "A senha deve conter no mínimo 8 caracteres")]
    public string Senha { get; set; }

    // [Required(ErrorMessage = "O Status é Obrigatório.")]
    public string Status { get; set; }
}
