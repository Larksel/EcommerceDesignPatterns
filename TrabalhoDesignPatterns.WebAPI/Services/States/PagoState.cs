using TrabalhoDesignPatterns.WebAPI.Objects.Enums;
using TrabalhoDesignPatterns.WebAPI.Services.Entities;

namespace TrabalhoDesignPatterns.WebAPI.Services.States;

public class PagoState : IPedidoState
{
    private PedidoService _pedido;

    public PagoState(PedidoService pedido)
    {
        _pedido = pedido;
        _pedido.EstadoAtual = EstadoPedido.PAGO;
    }

    void IPedidoState.CancelarPedido()
    {
        _pedido.State = new CanceladoState(_pedido);
    }

    void IPedidoState.DespacharPedido()
    {
        _pedido.State = new EnviadoState(_pedido);
    }

    void IPedidoState.SucessoAoPagar()
    {
        throw new Exception("Operação não suportada, o pedido já foi pago");
    }
}