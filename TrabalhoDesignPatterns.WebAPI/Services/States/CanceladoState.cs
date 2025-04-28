using TrabalhoDesignPatterns.WebAPI.Objects.Enums;
using TrabalhoDesignPatterns.WebAPI.Services.Entities;

namespace TrabalhoDesignPatterns.WebAPI.Services.States;

public class CanceladoState : IPedidoState
{
    private PedidoService _pedido;

    public CanceladoState(PedidoService pedido)
    {
        _pedido = pedido;
        _pedido.EstadoAtual = EstadoPedido.CANCELADO;
    }

    void IPedidoState.CancelarPedido()
    {
        throw new Exception("Operação não suportada, o pedido foi cancelado");
    }

    void IPedidoState.DespacharPedido()
    {
        throw new Exception("Operação não suportada, o pedido foi cancelado");
    }

    void IPedidoState.SucessoAoPagar()
    {
        throw new Exception("Operação não suportada, o pedido foi cancelado");
    }
}