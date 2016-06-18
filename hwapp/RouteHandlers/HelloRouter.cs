using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Http;

public class HelloRouter: IRouter {
    public VirtualPathData GetVirtualPath(VirtualPathContext context)
    {
        return null;
    }

    public Task RouteAsync(RouteContext context) {
        var name = context.RouteData.Values["name"] as string;
        
        if(string.IsNullOrEmpty(name)){
            return Task.CompletedTask;
        }
        
        return context.HttpContext.Response.WriteAsync($"Hi {name}");
    }
}