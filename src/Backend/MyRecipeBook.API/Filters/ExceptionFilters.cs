using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MyRecipeBook.Communication.Responses;
using MyRecipeBook.Exceptions;
using MyRecipeBook.Exceptions.ExceptionsBase;
using System.Net;

namespace MyRecipeBook.API.Filters;

public class ExceptionFilters : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is MyRecipeBookException)
            handleProjectException(context);
        else
            ThrowUnknowException(context);
    }

    private void handleProjectException(ExceptionContext context)
    {
        if (context.Exception is ErrorOnValidateException)
        {
            var exception = context.Exception as ErrorOnValidateException;

            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            context.Result = new BadRequestObjectResult(new ResponseErrorJson(exception.ErrorsMessages));
        }
    }

    private void ThrowUnknowException(ExceptionContext context)
    {
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Result = new ObjectResult(new ResponseErrorJson(ResourceMessageException.UNKNOWN_ERROR));
    }
}
