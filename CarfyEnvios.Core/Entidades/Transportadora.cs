using MongoDB.Bson.Serialization.Attributes;

namespace CarfyEnvios.Core.Entidades;

[BsonIgnoreExtraElements]
public class Transportadora : BaseEntity
{
    public string Nome { get; set; } = string.Empty;
    public string Cnpj { get; set; } = string.Empty;
    public string Telefone { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Observacao { get; set; } = string.Empty;
    public Endereco Endereco { get; set; } = null!;
}