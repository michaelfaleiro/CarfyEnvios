namespace CarfyEnvios.Core.Entidades;

public class Produto : BaseEntity
{
    public string Nome { get; set; } = string.Empty;
    public string Sku { get; set; } = string.Empty;
    public string Fabricante { get; set; } = string.Empty;
    
}