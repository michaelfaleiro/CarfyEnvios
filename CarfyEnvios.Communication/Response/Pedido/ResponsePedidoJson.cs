using CarfyEnvios.Communication.Response.Cliente;
using CarfyEnvios.Communication.Response.Coleta;
using CarfyEnvios.Communication.Response.ItemPedido;

namespace CarfyEnvios.Communication.Response.Pedido;

public class ResponsePedidoJson
{
    public string Id { get; set; } = string.Empty;
    public ResponseClienteJson Cliente { get; set; } = new();
    public IList<ResponseItemPedidoJson> Itens { get; set; } = [];
    public IList<ResponseColetaJson> Coletas { get; set; } = [];
    public string NumeroPedido { get; set; } = string.Empty;
    public DateTime DataPedido { get; set; }
    public string NumeroNfe { get; set; } = string.Empty;
    public DateTime DataEmissaoNfe { get; set; }
    public string LinkNfe { get; set; } = string.Empty;
    public string Observacao { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}