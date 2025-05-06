using TrabalhoDesignPatterns.WebAPI.Objects.DTOs;
using TrabalhoDesignPatterns.WebAPI.Services.States;

namespace TrabalhoDesignPatterns.WebAPI.Services.Interfaces;

public interface IPedidoService : IPedidoState
{
    Task<IEnumerable<PedidoDTO>> ListarTodos();
    Task<PedidoDTO> ObterPorId(int id);
    Task GerarPedido(PedidoDTO pedidoDTO);
    Task Atualizar(PedidoDTO pedidoDTO, int id);
    Task Remover(int id);
}