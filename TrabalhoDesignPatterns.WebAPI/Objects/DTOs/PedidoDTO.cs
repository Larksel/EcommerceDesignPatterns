namespace TrabalhoDesignPatterns.WebAPI.Objects.DTOs;

public class PedidoDTO
{
    public int Id { get; set; }
    public double Valor { get; set; }
    public int EstadoAtual { get; set; }
    public int TipoFrete { get; set; }
}