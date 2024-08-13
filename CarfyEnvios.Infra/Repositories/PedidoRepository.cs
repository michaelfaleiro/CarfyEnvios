using CarfyEnvios.Core.Entidades;
using CarfyEnvios.Core.Interfaces;
using CarfyEnvios.Core.Models;
using CarfyEnvios.Infra.Data;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace CarfyEnvios.Infra.Repositories;

public class PedidoRepository : IPedidoRepository
{

    private readonly IMongoCollection<Pedido> _collection;

    public PedidoRepository(IOptions<MongoDbSettings> mongoDbSettings)
    {
        var client = new MongoClient(mongoDbSettings.Value.ConnectionUri);
        var database = client.GetDatabase(mongoDbSettings.Value.DatabaseName);
        _collection = database.GetCollection<Pedido>(mongoDbSettings.Value.CollectionsNames["PedidoCollection"]);
    }

    public async Task<Pedido> CreateAsync(Pedido pedido)
    {
        await _collection.InsertOneAsync(pedido);
        return pedido;
    }

    public async Task<Pedido> UpdateAsync(Pedido pedido)
    {
        var filter = Builders<Pedido>.Filter.Eq(p => p.Id, pedido.Id);

        await _collection.ReplaceOneAsync(filter, pedido);

        return pedido;
    }

    public async Task<Pedido> GetByIdAsync(string id)
    {
        return await _collection.Find(p => p.Id == id).FirstOrDefaultAsync();
    }

    public async Task<IList<ItemPedido>> GetItensDoPedidoAsync(string pedidoId)
    {
        var pedido = await _collection.Find(p => p.Id == pedidoId).FirstOrDefaultAsync();
        return pedido.Itens;
    }


    public async Task<PagedResult<Pedido>> GetAllAsync(int pageNumber, int pageSize)
    {
        var totalCount = await _collection.CountDocumentsAsync(p => true);

        var pedidos = await _collection.Find(p => true)
            .Skip((pageNumber - 1) * pageSize)
            .Limit(pageSize)
            .ToListAsync();

        return new PagedResult<Pedido>
        {
            TotalCount = (int)totalCount,
            Data = pedidos
        };
    }

    public async Task DeleteAsync(string id)
    {
        var filter = Builders<Pedido>.Filter.Eq(p => p.Id, id);
        await _collection.DeleteOneAsync(filter);
    }

    public async Task AdicionarItemNoPedidoAsync(string pedidoId, ItemPedido itemPedido)
    {
        var filter = Builders<Pedido>.Filter.Eq(p => p.Id, pedidoId);
        var update = Builders<Pedido>.Update.Push(p => p.Itens, itemPedido);

        await _collection.UpdateOneAsync(filter, update);
    }

    public async Task AtualizarItemDoPedidoAsync(string pedidoId, ItemPedido itemPedido)
    {
        var filter = Builders<Pedido>.Filter.And(
            Builders<Pedido>.Filter.Eq(p => p.Id, pedidoId),
            Builders<Pedido>.Filter.ElemMatch(p => p.Itens, i => i.Id == itemPedido.Id)
        );

        var update = Builders<Pedido>.Update.Set(p => p.Itens[-1], itemPedido);

        await _collection.UpdateOneAsync(filter, update);
    }

    public async Task RemoverItemDoPedidoAsync(string pedidoId, string itemId)
    {
        var filter = Builders<Pedido>.Filter.And(
            Builders<Pedido>.Filter.Eq(p => p.Id, pedidoId),
            Builders<Pedido>.Filter.ElemMatch(p => p.Itens, i => i.Id == itemId)
        );

        var update = Builders<Pedido>.Update.PullFilter(p => p.Itens, i => i.Id == itemId);

        await _collection.UpdateOneAsync(filter, update);
    }

    public async Task AdicionarColetaAsync(string pedidoId, Coleta coleta)
    {
        var filter = Builders<Pedido>.Filter.Eq(p => p.Id, pedidoId);
        var update = Builders<Pedido>.Update.Push(p => p.Coletas, coleta);

        await _collection.UpdateOneAsync(filter, update);
    }

    public async Task AtualizarColetaAsync(string pedidoId, string coletaId, Coleta novaColeta)
    {
        var filter = Builders<Pedido>.Filter.And(
            Builders<Pedido>.Filter.Eq(p => p.Id, pedidoId),
            Builders<Pedido>.Filter.ElemMatch(p => p.Coletas, c => c.Id == coletaId)
        );

        var update = Builders<Pedido>.Update.Set("Coletas.$", novaColeta);

        await _collection.UpdateOneAsync(filter, update);
    }


    public async Task RemoverColetaAsync(string pedidoId, string coletaId)
    {
        var filter = Builders<Pedido>.Filter.And(
            Builders<Pedido>.Filter.Eq(p => p.Id, pedidoId),
            Builders<Pedido>.Filter.ElemMatch(p => p.Coletas, c => c.Id == coletaId)
        );

        var update = Builders<Pedido>.Update.PullFilter(p => p.Coletas, c => c.Id == coletaId);

        await _collection.UpdateOneAsync(filter, update);
    }

    public async Task AdicionarItemNaColetaAsync(string pedidoId, string coletaId, ItemPedido item)
    {
        var filter = Builders<Pedido>.Filter.And(
            Builders<Pedido>.Filter.Eq(p => p.Id, pedidoId),
            Builders<Pedido>.Filter.ElemMatch(p => p.Coletas, c => c.Id == coletaId)
        );

          var update = Builders<Pedido>.Update.Push("Coletas.$.Itens", item);

        await _collection.UpdateOneAsync(filter, update);
    }
        
    public async Task RemoverItemDaColetaAsync(string pedidoId, string coletaId, string itemId)
    {
        var filter = Builders<Pedido>.Filter.And(
            Builders<Pedido>.Filter.Eq(p => p.Id, pedidoId),
            Builders<Pedido>.Filter.ElemMatch(p => p.Coletas, c => c.Id == coletaId)
        );

        var update = Builders<Pedido>.Update.PullFilter("Coletas.$.Itens", 
            Builders<ItemPedido>.Filter.Eq(i => i.Id, itemId));

        await _collection.UpdateOneAsync(filter, update);
    }
}