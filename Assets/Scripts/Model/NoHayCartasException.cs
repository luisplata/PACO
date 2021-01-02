using System;
using System.Runtime.Serialization;

[Serializable]
public class NoHayCartasException : Exception
{
    public NoHayCartasException()
    {
    }

    public NoHayCartasException(string message) : base(message)
    {
    }

    public NoHayCartasException(string message, Exception innerException) : base(message, innerException)
    {
    }

    protected NoHayCartasException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}