using Demo.Filtters;
using Demo.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Demo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container. -- Day8
            //1) Framwrok Service
            //2) Built in Service 
            //global fitter
            
            builder.Services.AddControllersWithViews();
            #region global fitter
            //builder.Services.AddControllersWithViews(options =>
            //{
            //    options.Filters.Add(new HandelErrorAttribute());
            //});
            #endregion
       
            builder.Services.AddDbContext<ITIContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("cs"));
            });

            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(
                options =>
                {
                    /*Custmize password Constrinat*/
                    options.Password.RequiredLength = 5;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireDigit = false;
                }).AddEntityFrameworkStores<ITIContext>();//Register To IDentity Service 
            
            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
            });//deault setting 
            //3)Custom Serevice
            builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();//REgister
            builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
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
            //custom route
            //app.MapControllerRoute(
            //    "Route1",
            //    //"m1/{stdName:alpha:maxlength(4)}/{age:int:range(12,20)}",
            //    //"m1/{stdName}/{age?}",
            //    "m1",
            //    new { controller="Route",action="Method1"});

            //app.MapControllerRoute(
            //    "rout2",
            //    "m2",
            //    new { controller="Route",action="Method2"}
            //    );
            //R1/Method1
            //r1/method2
            //r1 ==>default action
            //app.MapControllerRoute("MyRoue",
            //    "{controller=}/{action=Method1}");

            //default route /class/action/id
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Employee}/{action=Index}/{id?}");
            #endregion


            //------------Start Application
            app.Run();
        }
    }
}
