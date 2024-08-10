using CarfyEnvios.Core.Interfaces;

namespace CarfyEnvios.Application.UseCase.Pedidos.Delete;

public class DeletePedidoUseCase(IPedidoRepository pedidoRepository)
{
    public async Task ExecuteAsync(string id)
    {
        var pedido = await pedidoRepository.GetByIdAsync(id);

        if (pedido == null)
            throw new Exception("Pedido não encontrado");

        await pedidoRepository.DeleteAsync(pedido.Id);
    }

}