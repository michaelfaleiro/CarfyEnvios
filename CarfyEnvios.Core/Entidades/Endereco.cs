using CarfyEnvios.Core.Enums;
using MongoDB.Bson.Serialization.Attributes;

namespace CarfyEnvios.Core.Entidades;

[BsonIgnoreExtraElements]
public class Endereco : BaseEntity
{
    public string Logradouro { get; set; } = string.Empty;
    public string Numero { get; set; } = string.Empty;
    public string Complemento { get; set; } = string.Empty;
    public string Bairro { get; set; } = string.Empty;
    public string Cidade { get; set; } = string.Empty;
    public string Estado { get; set; } = string.Empty;
    public string Cep { get; set; } = string.Empty;
    public ETipoEndereco TipoEndereco { get; set; } = ETipoEndereco.Entrega;
    
}