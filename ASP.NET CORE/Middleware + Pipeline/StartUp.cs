public class StartUp
{
    public IConfiguration configRoot
    {
        get;
    }
    public StartUp(IConfiguration configuration)
    {
        configRoot = configuration;
    }
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddSingleton<SecondMiddleware>();
    }
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseStaticFiles(); //StaticMiddleware
        // app.UseMiddleware<FirstMiddleware>();
        app.UseFirstMiddleware(); // dua vao pipeline FirstMiddleware
        app.UseSecondMiddleware();// dua vao pipeline SecondMiddleware
        
        app.UseRouting(); //endpointRoutingMiddleware
        // tao Endpoint ( terminal Middleware)
        app.UseEndpoints((endpoint) => {
            // EP 1
            endpoint.MapGet("/about.html", async (context) => {
            await context.Response.WriteAsync("About Page");
            });
            endpoint.MapGet("/product.html", async (context) => {
            await context.Response.WriteAsync("Product Page");

            });

        });
        // re nhanh pipeline
        app.Map("/admin", (app1) => {
            // tao middleware cua nhanh
            app1.UseRouting();
            app1.UseEndpoints((endpoint) => {
                endpoint.MapGet("/user", async(context) =>{
                    await context.Response.WriteAsync("Admin / User");
                });
            });

            app1.UseEndpoints((endpoint) => {
                endpoint.MapGet("/product", async(context) =>{
                    await context.Response.WriteAsync("Admin / Product");
                });
            });    

            app1.Run(async (context) =>
        {
            await context.Response.WriteAsync("ADMIN ASP.NetCore");
        });
        });

        // Terminate Middlware M1
        app.Run(async (context) =>
        {
            await context.Response.WriteAsync("ASP.NetCore");
        });
    }

    // app.UseHttpsRedirection();
    // app.UseStaticFiles();
    // app.UseRouting();
    // app.UseAuthorization();
    // app.MapRazorPages();
    // app.Run();
}

//  HttpContext
//  pipeline : StaticFileMiddleware - FirstMiddleware - SecondMiddleware - M1
