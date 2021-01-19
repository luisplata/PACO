using System;
using System.Runtime.Serialization;

[Serializable]
internal class AudioNotFoundException : Exception
{
    public AudioNotFoundException()
    {
    }

    public AudioNotFoundException(string message) : base(message)
    {
    }

    public AudioNotFoundException(string message, Exception innerException) : base(message, innerException)
    {
    }

    protected AudioNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}