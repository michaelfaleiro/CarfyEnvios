namespace CarfyEnvios.Communication.Request.Pedido.Coleta;
public class CreateColetaRequest
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
    public DateTime DataEnvio { get; set; }
    public DateTime? DataPrevisaoEntrega { get; set; } = null;
    public DateTime? DataEntregaFinalizada { get; set; } = null;
}
