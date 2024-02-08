using Microsoft.AspNetCore.Mvc.Filters;

namespace Demo.Filtters
{
    public class MyFilterAttribute : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        { }

        public void OnActionExecuting(ActionExecutingContext context)
        { }
    }
}
