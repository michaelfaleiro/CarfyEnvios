using System.Net;

namespace CarfyEnvios.Exceptions.ExceptionBase;

public class ErrorOnValidateException(string message) : CarfyEnviosException(message)
{
    public override HttpStatusCode GetStatusCode()
    {
        return HttpStatusCode.BadRequest;
    }

    public override IList<string> GetErrorMessages()
    {
        return new List<string> {Message};
    }
}