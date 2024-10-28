using CarfyEnvios.Communication.Response;
using CarfyEnvios.Exceptions.ExceptionBase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CarfyEnvios.Api.Filters;

public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is CarfyEnviosException)
        {
            var autoPartsOrcamentoException = (CarfyEnviosException)context.Exception;

            context.HttpContext.Response.StatusCode = (int)autoPartsOrcamentoException.GetStatusCode();
            
            var responseJson = new ResponseErrorJson(autoPartsOrcamentoException.GetErrorMessages());

            context.Result = new ObjectResult(responseJson);
        }
        else
        {
            context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            Console.WriteLine(context.Exception.Message);

            var list = new List<string> { "Erro interno no servidor"};

            var responseJson = new ResponseErrorJson(list);

            context.Result = new ObjectResult(responseJson);
        }
    }
}