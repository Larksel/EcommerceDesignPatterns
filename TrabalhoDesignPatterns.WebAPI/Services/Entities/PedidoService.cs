using TrabalhoDesignPatterns.WebAPI.Objects.DTOs;
using TrabalhoDesignPatterns.WebAPI.Objects.Enums;
using TrabalhoDesignPatterns.WebAPI.Objects.Models;
using TrabalhoDesignPatterns.WebAPI.Services.Interfaces;
using TrabalhoDesignPatterns.WebAPI.Services.States;

namespace TrabalhoDesignPatterns.WebAPI.Services.Entities;

public class PedidoService : Pedido, IPedidoService
{
    public IPedidoState State;

    public PedidoService()
    {
        State = ObterEstadoClasse();
    }

    public Task<IEnumerable<PedidoDTO>> ListarTodos()
    {

    }

    public Task<PedidoDTO> ObterPorId(int id)
    {

    }

    public Task GerarPedido(PedidoDTO pedidoDTO)
    {

    }

    private IPedidoState ObterEstadoClasse()
    {
        return EstadoAtual switch
        {
            EstadoPedido.AGUARDANDO_PAGAMENTO => new AguardandoPagamentoState(this),
            EstadoPedido.PAGO => new PagoState(this),
            EstadoPedido.ENVIADO => new EnviadoState(this),
            EstadoPedido.CANCELADO => new CanceladoState(this),
            _ => throw new ArgumentException("Estado inválido"),
        };
    }

    private EstadoPedido ObterEstadoEnum()
    {
        return State switch
        {
            AguardandoPagamentoState _ => EstadoPedido.AGUARDANDO_PAGAMENTO,
            PagoState _ => EstadoPedido.PAGO,
            EnviadoState _ => EstadoPedido.ENVIADO,
            CanceladoState _ => EstadoPedido.CANCELADO,
            _ => throw new ArgumentException("Estado inválido"),
        };
    }
}