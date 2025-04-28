using TrabalhoDesignPatterns.WebAPI.Objects.Enums;
using TrabalhoDesignPatterns.WebAPI.Services.Entities;

namespace TrabalhoDesignPatterns.WebAPI.Services.States;

public class EnviadoState : IPedidoState
{
    private PedidoService _pedido;

    public EnviadoState(PedidoService pedido)
    {
        _pedido = pedido;
        _pedido.EstadoAtual = EstadoPedido.ENVIADO;
    }

    void IPedidoState.CancelarPedido()
    {
        throw new Exception("Opera��o n�o suportada, o pedido j� foi enviado");
    }

    void IPedidoState.DespacharPedido()
    {
        throw new Exception("Opera��o n�o suportada, o pedido j� foi enviado");
    }

    void IPedidoState.SucessoAoPagar()
    {
        throw new Exception("Opera��o n�o suportada, o pedido j� foi enviado");
    }
}