using CarfyEnvios.Core.Entidades;

namespace CarfyEnvios.Core.Interfaces;

public interface IClienteRepository
{
    Task<Cliente> GetByIdAsync(int id);
    Task<IEnumerable<Cliente>> GetAllAsync();
    Task AddAsync(Cliente cliente);
    Task UpdateAsync(Cliente cliente);
    Task DeleteAsync(Cliente cliente);
} 