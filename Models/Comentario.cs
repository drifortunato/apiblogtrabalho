using System.ComponentModel.DataAnnotations;

public class Comentario
{
    public int Id { get; set; }

    public int IdLeitor { get; set; }

    [Required(ErrorMessage = "O Comentário é obrigatório.")]
    [MinLength(10, ErrorMessage = "O Comentário deve conter no mínimo 10 caracteres.")]

    public string Texto { get; set; }
}
