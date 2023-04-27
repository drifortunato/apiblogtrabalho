using System.ComponentModel.DataAnnotations;

public class Noticia
{
    public int Id { get; set; }

    public int IdAutor { get; set; }

    [Required(ErrorMessage = "O Título é obrigatório.")]
    [MinLength(3)]
    [MaxLength(100, ErrorMessage = "O Título pode conter, no máximo, 100 caracteres.")]
    public string Titulo { get; set; }

    [Required(ErrorMessage = "O Subtítulo é obrigatório.")]
    [MinLength(3)]
    [MaxLength(100, ErrorMessage = "O Subtítulo pode conter, no máximo, 100 caracteres.")]
    public string Subtitulo { get; set; }

    [Required(ErrorMessage = "A notícia é obrigatória.")]
    [MinLength(3)]
    public string Texto { get; set; }

    //[Required(ErrorMessage = "Data da notícia é obrigatória.")]
    [Range(typeof(DateTime), "01-01-2023", "31-12-2100")]
    public DateTime Data { get; set; }
}
