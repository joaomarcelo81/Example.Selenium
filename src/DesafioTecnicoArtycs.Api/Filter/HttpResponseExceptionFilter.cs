using DesafioTecnicoArtycs.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Reflection.Metadata;
using DesafioTecnicoArtycs.Api.Model;

namespace DesafioTecnicoArtycs.Api.Filter
{
    public class HttpResponseExceptionFilter : IActionFilter, IOrderedFilter
    {
        public int Order => int.MaxValue - 10;

        public void OnActionExecuting(ActionExecutingContext context) { }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception is HttpResponseException httpResponseException)
            {
                context.Result = new ObjectResult(httpResponseException.Value)
                {
                    StatusCode = httpResponseException.StatusCode
                };

                context.ExceptionHandled = true;
            }
            if (context.Exception is Exception exception)
            {
                context.Result = new ObjectResult(Constantes.ErroInesperadoMessage)
                {
                    StatusCode = (int)HttpStatusCode.InternalServerError
                };

                context.ExceptionHandled = true;
            }
            //if (context.Exception is Exception exception)
            //{
            //    context.Result = new ObjectResult(Constantes.UnauthorizedMessage)
            //    {
            //        StatusCode = (int)HttpStatusCode.InternalServerError
            //    };

            //    context.ExceptionHandled = true;
            //}
        }
    }
}
