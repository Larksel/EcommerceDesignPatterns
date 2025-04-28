using TrabalhoDesignPatterns.WebAPI.Objects.DTOs;

namespace TrabalhoDesignPatterns.WebAPI.Services.Interfaces;

public interface IPedidoService
{
    Task<IEnumerable<PedidoDTO>> ListarTodos();
    Task<PedidoDTO> ObterPorId(int id);
    Task GerarPedido(PedidoDTO pedidoDTO);
}