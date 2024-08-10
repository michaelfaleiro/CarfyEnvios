namespace CarfyEnvios.Communication.Request.Pedido;

public class CreatePedidoRequest
{
    public string NumeroPedido { get; set; } = string.Empty;
    public DateTime DataPedido { get; set; }
    public string NumeroNfe { get; set; } = string.Empty;
    public DateTime DataEmissaoNfe { get; set; }
    public string LinkNfe { get; set; } = string.Empty;
    public string Nome { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Telefone { get; set; } = string.Empty;
    public string Observacao { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    
}