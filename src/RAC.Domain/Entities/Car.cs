using RAC.Domain.Enum;

namespace RAC.Domain.Entities;

public class Car
{
    public long Id { get; set; }
    public string Marca { get; set; } = string.Empty;
    public string Modelo { get; set; } = string.Empty;
    public decimal Preco { get; set; }
    public int Ano { get; set; }
    public Categoria Categoria { get; set; }
    public DateTime DataCriacao { get; set; } = DateTime.UtcNow;

    public long UserId { get; set; }
    public User User { get; set; } = default!;
}
