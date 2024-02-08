using Microsoft.AspNetCore.Mvc.Filters;

namespace Demo.Filtters
{
    public class HandelErrorAttribute : Attribute, IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            //viewModel v = new viewModel();
            //v.name = context.Exception.Message;
            //v.des=
            //handel 
            //context.Result = new ContentResult() 
            //{ Content = $"Some Error Happen{context.Exception.Message}" };
            context.Result = new ViewResult() { ViewName = "Error" };//, Model=v};
        }
    }
}
