using System.Net;

namespace CarfyEnvios.Exceptions.ExceptionBase;

public class NotFoundException(string message) : CarfyEnviosException(message)
{

    public override HttpStatusCode GetStatusCode()
    {
        return HttpStatusCode.NotFound;
    }

    public override IList<string> GetErrorMessages()
    {
        return new List<string> {Message};
    }
}