using CarfyEnvios.Core.Enums;
using MongoDB.Bson.Serialization.Attributes;

namespace CarfyEnvios.Core.Entidades;

[BsonIgnoreExtraElements]
public class Fornecedor : BaseEntity
{
    public string Nome { get; set; } = string.Empty;
    public string Cnpj { get; set; } = string.Empty;
    public string Telefone { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public Endereco Endereco { get; set; } = new();
    public EServicoDeColeta Coleta { get; set; } = EServicoDeColeta.Nao;
}