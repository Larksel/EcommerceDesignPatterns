using TrabalhoDesignPatterns.WebAPI.Objects.Enums;
using TrabalhoDesignPatterns.WebAPI.Services.Entities;

namespace TrabalhoDesignPatterns.WebAPI.Services.States;

public class AguardandoPagamentoState : IPedidoState
{
    private PedidoService _pedido;

    public AguardandoPagamentoState(PedidoService pedido)
    {
        _pedido = pedido;
        _pedido.EstadoAtual = EstadoPedido.AGUARDANDO_PAGAMENTO;
    }

    void IPedidoState.CancelarPedido()
    {
        _pedido.State = new CanceladoState(_pedido);
    }

    void IPedidoState.DespacharPedido()
    {
        throw new Exception("Opera��o n�o suportada, " +
            "o pedido ainda n�o foi pago");
    }

    void IPedidoState.SucessoAoPagar()
    {
        _pedido.State = new PagoState(_pedido);
    }
}