using MongoDB.Bson.Serialization.Attributes;

namespace CarfyEnvios.Core.Entidades;

[BsonIgnoreExtraElements]
public class Pedido : BaseEntity
{
    public string NumeroPedido { get; set; } = string.Empty;
    public DateTime DataPedido { get; set; }
    public string NumeroNfe { get; set; } = string.Empty;
    public DateTime DataEmissaoNfe { get; set; }
    public string LinkNfe { get; set; } = string.Empty;
    public Cliente Cliente { get; set; } = null!;
    public IList<ItemPedido> Itens { get; set; } = [];
    public IList<Coleta> Coletas { get; set; } = [];
    public string Observacao { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
}