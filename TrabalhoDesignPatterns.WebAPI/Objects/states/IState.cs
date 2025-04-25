namespace TrabalhoDesignPatterns.WebAPI.Objects.States;

public interface IState
{
    public void SucessoAoPagar();
    public void DespacharPedido();
    public void CancelarPedido();
}