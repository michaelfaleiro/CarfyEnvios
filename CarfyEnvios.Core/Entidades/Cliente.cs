namespace CarfyEnvios.Core.Entidades;

public class Cliente : BaseEntity
{
    public string Nome { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Telefone { get; set; } = string.Empty;
    // public IList<Endereco> Enderecos { get; set; } = [];
    // public IList<Pedido> Pedidos { get; set; } = [];
    
}