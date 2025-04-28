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
        throw new Exception("Opera��o n�o suportada, o pedido foi cancelado");
    }

    void IPedidoState.DespacharPedido()
    {
        throw new Exception("Opera��o n�o suportada, o pedido foi cancelado");
    }

    void IPedidoState.SucessoAoPagar()
    {
        throw new Exception("Opera��o n�o suportada, o pedido foi cancelado");
    }
}