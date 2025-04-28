using TrabalhoDesignPatterns.WebAPI.Objects.Enums;

namespace TrabalhoDesignPatterns.WebAPI.Objects.Models;

public class Pedido
{
    public int Id { get; set; }
    public double Valor { get; set; }
    public EstadoPedido EstadoAtual { get; set; }
    public TipoFrete TipoFrete { get; set; }

    public Pedido() { }

    public Pedido(int id, double valor, TipoFrete tipoFrete)
    {
        Id = id;
        Valor = valor;
        EstadoAtual = EstadoPedido.AGUARDANDO_PAGAMENTO;
        TipoFrete = tipoFrete;
    }
}