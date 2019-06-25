using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using  Rock.Logging;

namespace AspNetCoreToDo.ActionFilters
{
    public class ActionExecuted : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context) { }

        public void OnActionExecuted(ActionExecutedContext context) { }
    }

    public class ExceptionFilters : ExceptionFilterAttribute
    {
        private ILogger _logger;

        public ExceptionFilters(ILogger logger)
        {
            _logger = logger;
        }

        public override void OnException(ExceptionContext exContext)
        {
            _logger.Error(exContext.Exception.Message, new object(), exContext.Exception);
        }
    }
}