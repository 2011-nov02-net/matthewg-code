using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HelloAspNetCore {
    public class Startup {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services) {
            // this method is for (1) configuring  middleware before actually plugging it in
            // and (2) adding "services" to the dependency injection container.

            services.AddControllersWithViews(); // adds controllers and views to the list of things ASP.NET Core will understand.
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }

            app.UseFileServer(); // look for files called 'index' in wwwroot

            app.UseRouting();

            app.UseEndpoints(endpoints => {
                // ASP.NET Core MVC is when we use a specific subset of middlewares/classes/practices
                //  within ASP.NET Core as a whole

                endpoints.MapControllerRoute(
                    name: "hello-controller",
                    pattern: "hello",
                    defaults: new { controller = "Hello", action = "Action1" }
                    );
                // every route definition here needs to wind up specifying
                // (1) a controller, (2) an action method on tha tcontroller.
                // if the pattern isn't enough to do that, we need to set defaults
                // we do that with a C# syntax called "anonymous type" which creates an object without a class.


                endpoints.MapControllerRoute(
                    name: "hello-controller2",
                    pattern: "hello/{param1}/{param2:int?}",
                    defaults: new { controller = "Hello", action = "ParameterizedAction" }
                    );
                // route parameters can be constrained with ":int", if the given value doesn't match
                //      the route as a whole will not match
                // add a "?" to make the parameter optional, and the route will still match if no value is provided
                // add "=something" to provide a different action

                // a given request is matched against each of these route patterns in turn until the first one
                //  that matches is found


                endpoints.MapControllerRoute(
                    name: "hello-controller-generic",
                    pattern: "hi/{action=Action1}/{param1?}/{param2:int?}",
                    defaults: new { controller = "Hello" }
                    );
                // a route parameter named "action" is looked at to decide which action method is called
                //      in the first place


                endpoints.MapControllerRoute(
                    name: "controller-generic",
                    pattern: "{controller=hello}/{action=Action1}/{param1?}/{param2:int?}"
                    );
                // this route could match any controller and any action - "hello" and "Action1" are just defaults.
            });


            app.Use(async (context, next) => {
                // request processing logic before the next middleware runs
                
                await next();
                // request processing logic that runs after any later middlewares
            });

            app.Run(async context => {

                // this object has all the details of the request
                HttpRequest request = context.Request;

                // we can modify this object to set up the response
                HttpResponse response = context.Response;

                response.ContentType = "text/html";
                await response.WriteAsync(@"<!DOCTYPE html>
<html>
    <head>
    </head>
    <body>
        Default fallback
    </body>
</html>");
            });
        }
    }
}
