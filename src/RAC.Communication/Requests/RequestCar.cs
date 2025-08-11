
using RAC.Communication.Enum;

namespace RAC.Communication.Requests;

public class RequestCar
{
    public string Marca { get; set; } = string.Empty;
    public string Modelo { get; set; } = string.Empty;
    public decimal Preco { get; set; }
    public int Ano { get; set; }
    public Categoria Categoria { get; set; } 
}
