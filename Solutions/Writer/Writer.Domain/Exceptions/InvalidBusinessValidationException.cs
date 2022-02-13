using System.Runtime.Serialization;

namespace Writer.Domain.Exceptions;

[Serializable]
public class InvalidBusinessValidationException : Exception
{
    public InvalidBusinessValidationException()
    {
    }

    public InvalidBusinessValidationException(string? message) : base(message)
    {
    }

    public InvalidBusinessValidationException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected InvalidBusinessValidationException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}

