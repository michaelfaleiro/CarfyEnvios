using System.Net;

namespace CarfyEnvios.Exceptions.ExceptionBase;

public abstract class CarfyEnviosException(string message) : SystemException(message)
{
        public abstract HttpStatusCode GetStatusCode();
        public abstract IList<string> GetErrorMessages();
}