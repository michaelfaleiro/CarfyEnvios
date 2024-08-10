using CarfyEnvios.Core.Entidades;

namespace CarfyEnvios.Core.Interfaces;

public interface IFornecedorRepository
{
    Task<Fornecedor> GetByIdAsync(int id);
    Task<IEnumerable<Fornecedor>> GetAllAsync();
    Task AddAsync(Fornecedor fornecedor);
    Task UpdateAsync(Fornecedor fornecedor);
    Task DeleteAsync(Fornecedor fornecedor);
}