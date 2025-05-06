using TrabalhoDesignPatterns.WebAPI.Data.Interfaces;
using TrabalhoDesignPatterns.WebAPI.Objects.DTOs;
using TrabalhoDesignPatterns.WebAPI.Objects.Enums;
using TrabalhoDesignPatterns.WebAPI.Objects.Models;
using TrabalhoDesignPatterns.WebAPI.Services.Interfaces;
using TrabalhoDesignPatterns.WebAPI.Services.States;

namespace TrabalhoDesignPatterns.WebAPI.Services.Entities;

public class PedidoService : Pedido, IPedidoService
{
    private readonly IPedidoRepository _repository;
    public IPedidoState State;

    public PedidoService(IPedidoRepository pedidoRepository)
    {
        _repository = pedidoRepository;
        State = ObterEstadoClasse();
    }

    public async Task<IEnumerable<PedidoDTO>> ListarTodos()
    {
        var entities = await _repository.Get();
        List<PedidoDTO> entitiesDTO = [];

        foreach (var entity in entities)
        {
            entitiesDTO.Add(ConverterParaDTO(entity));
        }

        return entitiesDTO;
    }

    public async Task<PedidoDTO> ObterPorId(int id)
    {
        var entity = await _repository.GetById(id);
        return ConverterParaDTO(entity);
    }

    public async Task GerarPedido(PedidoDTO entityDTO)
    {
        var entity = ConverterParaModel(entityDTO);
        await _repository.Add(entity);
    }

    public async Task Atualizar(PedidoDTO entityDTO, int id)
    {
        var existingEntity = await _repository.GetById(id);

        if (existingEntity == null)
        {
            throw new KeyNotFoundException($"Entity with id {id} not found.");
        }

        var entity = ConverterParaModel(entityDTO);
        await _repository.Update(entity);
    }

    public async Task Remover(int id)
    {
        var entity = await _repository.GetById(id);
        if (entity == null)
        {
            throw new KeyNotFoundException($"Entidade com id: {id} não encontrado");
        }

        await _repository.Remove(entity);
    }

    public void SucessoAoPagar()
    {
        throw new NotImplementedException();
    }

    public void DespacharPedido()
    {
        throw new NotImplementedException();
    }

    public void CancelarPedido()
    {
        throw new NotImplementedException();
    }

    #region Métodos de Conversão
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

    private PedidoDTO ConverterParaDTO(Pedido pedido)
    {
        PedidoDTO pedidoDTO = new()
        {
            Id = pedido.Id,
            Valor = pedido.Valor,
            EstadoAtual = (int)pedido.EstadoAtual,
            TipoFrete = (int)pedido.TipoFrete,
        };

        return pedidoDTO;
    }

    private Pedido ConverterParaModel(PedidoDTO pedidoDTO)
    {
        Pedido pedido = new()
        {
            Id = pedidoDTO.Id,
            Valor = pedidoDTO.Valor,
            EstadoAtual = (EstadoPedido)pedidoDTO.EstadoAtual,
            TipoFrete = (TipoFrete)pedidoDTO.TipoFrete,
        };

        return pedido;
    }
    #endregion
}