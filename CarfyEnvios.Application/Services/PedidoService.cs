using CarfyEnvios.Application.UseCase.Pedidos.Coleta.AdicionarItemColeta;
using CarfyEnvios.Application.UseCase.Pedidos.Coleta.Create;
using CarfyEnvios.Application.UseCase.Pedidos.Coleta.RemoverItemColeta;
using CarfyEnvios.Application.UseCase.Pedidos.Coleta.Update;
using CarfyEnvios.Application.UseCase.Pedidos.Create;
using CarfyEnvios.Application.UseCase.Pedidos.Delete;
using CarfyEnvios.Application.UseCase.Pedidos.GetAll;
using CarfyEnvios.Application.UseCase.Pedidos.GetById;
using CarfyEnvios.Application.UseCase.Pedidos.ItensPedido.AdicionarItem;
using CarfyEnvios.Application.UseCase.Pedidos.ItensPedido.DeleteItem;
using CarfyEnvios.Application.UseCase.Pedidos.ItensPedido.UpdateItem;
using CarfyEnvios.Application.UseCase.Pedidos.Update;
using Microsoft.Extensions.DependencyInjection;

namespace CarfyEnvios.Application.Services;

public static class PedidoService
{
    public static IServiceCollection PedidoUseCase(this IServiceCollection services)
    {
        services.AddSingleton<CreatePedidoUseCase>();
        services.AddSingleton<GetByIdPedidoUseCase>();
        services.AddSingleton<GetAllPedidosUseCase>();
        services.AddSingleton<UpdatePedidoUseCase>();
        services.AddSingleton<DeletePedidoUseCase>();
        services.AddSingleton<AdicionarItemPedidoUseCase>();
        services.AddSingleton<UpdateItemPedidoUseCase>();
        services.AddSingleton<DeleteItemPedidoUseCase>();
        services.AddSingleton<CreateColetaUseCase>();
        services.AddSingleton<UpdateColetaItemUseCase>();
        services.AddSingleton<AdicionarItemNaColetaUseCase>();
        services.AddSingleton<RemoverItemDaColetaUseCase>();

        return services;

    }

}