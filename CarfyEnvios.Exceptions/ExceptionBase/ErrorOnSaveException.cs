using System.Net;

namespace CarfyEnvios.Exceptions.ExceptionBase;

public class ErrorOnSaveException(string message) : CarfyEnviosException(message)   
{
    public override HttpStatusCode GetStatusCode()
    {
        return HttpStatusCode.InternalServerError;
    }

    public override IList<string> GetErrorMessages()
    {
        return new List<string> {Message};
    }
}