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
using CarfyEnvios.Communication;
using CarfyEnvios.Communication.Request.Pedido;
using CarfyEnvios.Communication.Request.Pedido.Coleta;
using CarfyEnvios.Communication.Response;
using CarfyEnvios.Communication.Response.Pedido;
using Microsoft.AspNetCore.Mvc;

namespace CarfyEnvios.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PedidosController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(Response<ResponsePedidoJson>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> PostAsync(
        [FromBody] CreatePedidoRequest request,
        [FromServices] CreatePedidoUseCase useCase)
    {
        var pedido = await useCase.ExecuteAsync(request);

        return Created(string.Empty, pedido);
    }

    [HttpGet]
    [ProducesResponseType(typeof(PagedResponse<ResponsePedidoJson>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllAsync(
        [FromServices] GetAllPedidosUseCase useCase,
        [FromQuery] int pageNumber = Configuration.DefaultPageNumber,
        [FromQuery] int pageSize = Configuration.DefaultPageSize)
    {
        var pedidos = await useCase.ExecuteAsync(pageNumber, pageSize);

        return Ok(pedidos);
    }

    [HttpGet("{id:length(24)}")]
    [ProducesResponseType(typeof(Response<ResponsePedidoJson>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetByIdAsync(
        [FromRoute] string id,
        [FromServices] GetByIdPedidoUseCase useCase)
    {
        var pedido = await useCase.ExecuteAsync(id);

        return Ok(pedido);
    }

    [HttpPut("{id:length(24)}")]
    [ProducesResponseType(typeof(Response<ResponsePedidoJson>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> PutAsync(
        [FromRoute] string id,
        [FromBody] UpdatePedidoRequest request,
        [FromServices] UpdatePedidoUseCase useCase)
    {
        var pedido = await useCase.ExecuteAsync(id, request);

        return Ok(pedido);
    }

    [HttpDelete("{id:length(24)}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteAsync(
        [FromRoute] string id,
        [FromServices] DeletePedidoUseCase useCase)
    {
        await useCase.ExecuteAsync(id);

        return NoContent();
    }

    [HttpPost("{id:length(24)}/itens")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> AdicionarItemAsync(
        [FromRoute] string id,
        [FromBody] AdicionarItemPedidoRequest request,
        [FromServices] AdicionarItemPedidoUseCase useCase)
    {
        await useCase.ExecuteAsync(id, request);

        return NoContent();
    }

    [HttpPut("{id:length(24)}/itens/{itemId:length(24)}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateItemAsync(
        [FromRoute] string id,
        [FromRoute] string itemId,
        [FromBody] AdicionarItemPedidoRequest item,
        [FromServices] UpdateItemPedidoUseCase useCase)
    {
        await useCase.ExecuteAsync(id, itemId, item);

        return NoContent();
    }

    [HttpDelete("{id:length(24)}/itens/{itemId:length(24)}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteItemAsync(
        [FromRoute] string id,
        [FromRoute] string itemId,
        [FromServices] DeleteItemPedidoUseCase useCase)
    {
        await useCase.ExecuteAsync(id, itemId);

        return NoContent();
    }

    [HttpPost("{id:length(24)}/coleta")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> AdicionarColetaItemAsync(
        [FromRoute] string id,
        [FromBody] CreateColetaRequest request,
        [FromServices] CreateColetaUseCase useCase)
    {
        await useCase.ExecuteAsync(id, request);

        return NoContent();
    }

    [HttpPut("{id:length(24)}/coleta/{coletaId:length(24)}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateColetaItemAsync(
        [FromRoute] string id,
        [FromRoute] string coletaId,
        [FromBody] UpdateColetaRequest request,
        [FromServices] UpdateColetaItemUseCase useCase)
    {
        await useCase.ExecuteAsync(id, coletaId, request);

        return NoContent();
    }

    [HttpPost("{id:length(24)}/coleta/{coletaId:length(24)}/itens")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> AdicionarItemNaColetaAsync(
        [FromRoute] string id,
        [FromRoute] string coletaId,
        [FromBody] AdicionarItemNaColetaRequest request,
        [FromServices] AdicionarItemNaColetaUseCase useCase)
    {
        await useCase.ExecuteAsync(id, coletaId, request);

        return NoContent();
    }

    [HttpDelete("{id:length(24)}/coleta/{coletaId:length(24)}/itens/{itemId:length(24)}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> RemoverItemDaColetaAsync(
        [FromRoute] string id,
        [FromRoute] string coletaId,
        [FromRoute] string itemId,
        [FromServices] RemoverItemDaColetaUseCase useCase)
    {
        await useCase.ExecuteAsync(id, coletaId, itemId);

        return NoContent();
    }
    
}