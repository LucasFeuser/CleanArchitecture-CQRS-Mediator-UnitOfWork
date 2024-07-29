using System.Net;

namespace CleanArchitecture.CrossCutting.Common.CQRS.Response.Base;

public sealed class ResponseBase<TEntity>
{
    public ResponseBase(HttpStatusCode statusCode, string message, TEntity data)
    {
        StatusCode = (int)statusCode;
        Mensagem = message;
        Dados = data;
    }

    public int StatusCode { get; private set; }
    public string Mensagem { get; private set; }
    public TEntity? Dados { get; private set; }
}