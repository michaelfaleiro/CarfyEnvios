namespace CarfyEnvios.Communication.Request.Pedido.Rastreio;
public class AdicionarRastreioItemRequest
{
    public string CodigoRastreio { get; set; } = string.Empty;
    public DateTime DataEnvio { get; set; }
    public DateTime? DataPrevisaoEntrega { get; set; } 
    public DateTime? DataEntregaFinalizada { get; set; }
}
