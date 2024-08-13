using CarfyEnvios.Core.Entidades;
using CarfyEnvios.Core.Models;

namespace CarfyEnvios.Core.Interfaces;

public interface IPedidoRepository
{
    Task<Pedido> CreateAsync(Pedido pedido);
    Task<Pedido> UpdateAsync(Pedido pedido);
    Task<Pedido> GetByIdAsync(string id);
    Task<IList<ItemPedido>> GetItensDoPedidoAsync(string pedidoId);
    Task<PagedResult<Pedido>> GetAllAsync(int pageNumber, int pageSize);
    Task DeleteAsync(string id);
    Task AdicionarItemNoPedidoAsync(string pedidoId, ItemPedido itemPedido);
    Task AtualizarItemDoPedidoAsync(string pedidoId, ItemPedido itemPedido);
    Task RemoverItemDoPedidoAsync(string pedidoId, string itemId);
    Task AdicionarColetaAsync(string pedidoId, Coleta coleta);
    Task AtualizarColetaAsync(string pedidoId, string coletaId, Coleta coleta);
    Task RemoverColetaAsync(string pedidoId, string coletaId);
    Task AdicionarItemNaColetaAsync(string pedidoId, string coletaId, ItemPedido item);
    Task RemoverItemDaColetaAsync(string pedidoId, string coletaId, string itemId);

    
}