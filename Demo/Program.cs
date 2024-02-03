namespace Demo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container. -- Day8
            builder.Services.AddControllersWithViews();
            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
            });//deault setting 

           
            var app = builder.Build();

            // Configure the HTTP request pipeline. --DAy2 |Day3 Middlewares
            #region inline midelwarres
            //app.Use(async (httpContext, next) =>
            //{
            //    await httpContext.Response.WriteAsync("1- MiddleWare 1\n");
            //    await next.Invoke();//21
            //    await httpContext.Response.WriteAsync("1-1 MiddleWare 1-1\n");

            //});
            //app.Use(async (httpContext, next) =>
            //{
            //    await httpContext.Response.WriteAsync("2- MiddleWare 2\n");
            //    await next.Invoke();//26
            //    await httpContext.Response.WriteAsync("2-2 MiddleWare 2-2\n");

            //});
            //app.Run(async(httpContext) =>
            //{

            //    await httpContext.Response.WriteAsync("3- Terminate 3\n");
            //});
            #endregion
            #region DEfault pipline
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            
            app.UseStaticFiles();
            
            app.UseRouting();//department/index (controoler =dep,action=index) routing

            app.UseSession();//not been configure session

            app.UseAuthorization();//roles unused==>Authantictio

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            #endregion


            //------------Start Application
            app.Run();
        }
    }
}
