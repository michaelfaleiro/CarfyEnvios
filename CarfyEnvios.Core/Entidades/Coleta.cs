using MongoDB.Bson.Serialization.Attributes;

namespace CarfyEnvios.Core.Entidades;

[BsonIgnoreExtraElements]
public class Coleta : BaseEntity
{
    public string PontoDeColeta { get; set; } = string.Empty;
    public string Transportadora { get; set; } = string.Empty;
    public string TipoTransporte { get; set; } = string.Empty;
    public string StatusColeta { get; set; } = string.Empty;
    public string LinkAwb { get; set; } = string.Empty;
    public string LinkRomaneio { get; set; } = string.Empty;
    public string LinkCartaCorrecao { get; set; } = string.Empty;
    public string MedidasEmbalagem { get; set; } = string.Empty;
    public string PesoEmbalagem { get; set; } = string.Empty;
    public string CodigoRastreio { get; set; } = string.Empty;
    public DateTime? DataEnvio { get; set; }
    public DateTime? DataPrevisaoEntrega { get; set; }
    public DateTime? DataEntregaFinalizada { get; set; }
    public IList<ItemPedido> Itens { get; set; } = [];
}
