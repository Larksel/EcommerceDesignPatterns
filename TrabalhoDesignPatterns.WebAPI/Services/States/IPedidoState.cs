namespace TrabalhoDesignPatterns.WebAPI.Services.States;

public interface IPedidoState
{
    public void SucessoAoPagar();
    public void DespacharPedido();
    public void CancelarPedido();
}