//Middleware and Pipeline 
public class FirstMiddleware{
    private readonly RequestDelegate _next;
    // RequestDelegate ~ async ( HttpContext context) => {}
    public FirstMiddleware(RequestDelegate next){
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context){
        System.Console.WriteLine($"URL: {context.Request.Path}");
        context.Items.Add("DataFirstMiddleware", $"<p> URL : {context.Request.Path}</p>");
        // await context.Response.WriteAsync($"<p>URL : {context.Request.Path}</p>");
        await _next(context);
    }
}