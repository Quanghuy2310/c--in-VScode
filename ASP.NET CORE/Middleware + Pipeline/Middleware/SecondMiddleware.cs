using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

    public class SecondMiddleware : IMiddleware{
public async Task InvokeAsync(HttpContext context, RequestDelegate next){
    if (context.Request.Path == "/xxx.html"){
        context.Response.Headers.Add("SecondMiddleware", "Not Allow");
        var datafromFirstMiddleware = context.Items["DataFirstMiddleware"];
        if(datafromFirstMiddleware != null)
        await context.Response.WriteAsync((string)datafromFirstMiddleware);
        await context.Response.WriteAsync("Not Allow");
    }
    else {
        context.Response.Headers.Add("SecondMiddleware", "Alow to Access");
        var datafromFirstMiddleware = context.Items["DataFirstMiddleware"];
        if(datafromFirstMiddleware != null)
        await context.Response.WriteAsync((string)datafromFirstMiddleware);
        await next(context);
    }
}
}