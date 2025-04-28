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
        throw new Exception("Operação não suportada, o pedido já foi enviado");
    }

    void IPedidoState.DespacharPedido()
    {
        throw new Exception("Operação não suportada, o pedido já foi enviado");
    }

    void IPedidoState.SucessoAoPagar()
    {
        throw new Exception("Operação não suportada, o pedido já foi enviado");
    }
}