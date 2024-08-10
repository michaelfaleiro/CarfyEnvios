using CarfyEnvios.Communication.Response.Envio;

namespace CarfyEnvios.Communication.Response.ItemPedido;

public class ResponseItemPedidoJson
{
    public string Id { get; set; } = string.Empty;
    public string Nome { get; set; } = string.Empty;
    public string Sku { get; set; } = string.Empty;
    public string Fabricante { get; set; } = string.Empty;
    public int Quantidade { get; set; }
    public decimal ValorUnitario { get; set; }
    
}