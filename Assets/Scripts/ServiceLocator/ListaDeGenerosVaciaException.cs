using System;
using System.Runtime.Serialization;

[Serializable]
public class ListaDeGenerosVaciaException : Exception
{
    public ListaDeGenerosVaciaException()
    {
    }

    public ListaDeGenerosVaciaException(string message) : base(message)
    {
    }

    public ListaDeGenerosVaciaException(string message, Exception innerException) : base(message, innerException)
    {
    }

    protected ListaDeGenerosVaciaException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}