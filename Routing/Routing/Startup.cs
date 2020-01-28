using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Routing
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            var myRouteHandler = new RouteHandler(Handle);
            var routeBuilder = new RouteBuilder(app, myRouteHandler);
            routeBuilder.MapRoute("default", "{controller}/{action}");
            app.UseRouter(routeBuilder.Build());
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }
        private async Task Handle(HttpContext context)
        {
            await context.Response.WriteAsync("Hello ASP.NET Core!");
        }
    }
    //public class Startup
    //{
    //    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    //    {
    //        if (env.IsDevelopment())
    //        {
    //            app.UseDeveloperExceptionPage();
    //        }

    //        app.UseRouting();
    //        app.Use(async (context, next) =>
    //        {
    //            Endpoint endpoint = context.GetEndpoint();

    //            if (endpoint != null)
    //            {
    //                var routePattern = (endpoint as Microsoft.AspNetCore.Routing.RouteEndpoint)?.RoutePattern?.RawText;

    //                Debug.WriteLine($"Endpoint Name: {endpoint.DisplayName}");
    //                Debug.WriteLine($"Route Pattern: {routePattern}");

    //                await next();
    //            }
    //            else
    //            {
    //                Debug.WriteLine("Endpoint: null");
    //                await context.Response.WriteAsync("Endpoint is not defined");
    //            }
    //        });
    //        app.UseEndpoints(endpoints =>
    //        {
    //            endpoints.MapGet("/index", async context =>
    //            {
    //                await context.Response.WriteAsync("Hello Index!");
    //            });
    //            endpoints.MapGet("/", async context =>
    //            {
    //                await context.Response.WriteAsync("Hello World!");
    //            });
    //        });
    //    }
    //}

}
