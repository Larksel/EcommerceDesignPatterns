namespace TrabalhoDesignPatterns.WebAPI.Services.States;

public class CanceladoState : IPedidoState
{
    public IPedidoState CancelarPedido()
    {
        throw new Exception("Opera��o n�o suportada, o pedido foi cancelado");
    }

    public IPedidoState DespacharPedido()
    {
        throw new Exception("Opera��o n�o suportada, o pedido foi cancelado");
    }

    public IPedidoState SucessoAoPagar()
    {
        throw new Exception("Opera��o n�o suportada, o pedido foi cancelado");
    }
}