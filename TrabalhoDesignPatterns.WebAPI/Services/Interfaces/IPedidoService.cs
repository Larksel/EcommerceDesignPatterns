using TrabalhoDesignPatterns.WebAPI.Objects.DTOs;

namespace TrabalhoDesignPatterns.WebAPI.Services.Interfaces;

public interface IPedidoService
{
    Task<IEnumerable<PedidoDTO>> ListarTodos();
    Task<PedidoDTO> ObterPorId(int id);
    Task GerarPedido(PedidoDTO pedidoDTO);
    Task Atualizar(PedidoDTO pedidoDTO, int id);
    Task Cancelar(int id);
}