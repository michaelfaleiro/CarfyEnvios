namespace CarfyEnvios.Communication.Request.Pedido;

public class AdicionarItemPedidoRequest
{
    public string Nome { get; set; } = string.Empty;
    public string Sku { get; set; } = string.Empty;
    public string Fabricante { get; set; } = string.Empty;
    public int Quantidade { get; set; }
    public decimal ValorUnitario { get; set; }
    
}