using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace itservicecenter.Helper
{
    public class ExceptionFilters : ExceptionFilterAttribute
    {
        private readonly ILogger <ExceptionFilters> _logger;

        public ExceptionFilters(ILogger<ExceptionFilters> logger)
        {
            _logger = logger;
        }

        public override void OnException(ExceptionContext context)
        {
            _logger.LogError(context.Exception, context.Exception.Message);

            if (context.Exception is UserException)
            {
                context.ModelState.AddModelError("UserError", context.Exception.Message);
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }
            else
            {
                context.ModelState.AddModelError("Error", "Server Side Error, Please Check Logs");
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            }

            var lista = context.ModelState.Where(x => x.Value.Errors.Count > 0)
                .ToDictionary(x => x.Key,
                    y => y.Value.Errors
                        .Select(z => z.ErrorMessage));
            context.Result = new JsonResult(new { errors = lista });
        }
    }
}