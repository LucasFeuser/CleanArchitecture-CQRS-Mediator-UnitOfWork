using CleanArchitecture.CrossCutting.Common.CQRS.Response.Base;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CleanArchitecture.CrossCutting.Common.CQRS.Query;

public abstract class QueryBase
{
    protected IActionResult ReturnOk<TEnitity>(TEnitity view) where TEnitity : class
        => new OkObjectResult(new ResponseBase<TEnitity>(HttpStatusCode.OK, $"Processado com sucesso.", view));
}