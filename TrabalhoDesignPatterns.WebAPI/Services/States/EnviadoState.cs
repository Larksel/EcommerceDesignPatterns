namespace TrabalhoDesignPatterns.WebAPI.Services.States;

public class EnviadoState : IPedidoState
{
    public IPedidoState CancelarPedido()
    {
        throw new Exception("Opera��o n�o suportada, o pedido j� foi enviado");
    }

    public IPedidoState DespacharPedido()
    {
        throw new Exception("Opera��o n�o suportada, o pedido j� foi enviado");
    }

    public IPedidoState SucessoAoPagar()
    {
        throw new Exception("Opera��o n�o suportada, o pedido j� foi enviado");
    }
}