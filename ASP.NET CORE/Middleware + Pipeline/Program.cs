
// var builder = WebApplication.CreateBuilder(args);
// var app = builder.Build();

// app.MapGet("/", () => "HelWrld!");

// app.Run();

namespace ASP.NET
{
    public class Program
    {

        // Host (IHost) object : 
        // - Dependency Inject (ID) : IServiceProvider (ServiceCollection)
        // - Logging (ILogging)
        // - Configruation
        // - IHostedService => StartAsync : Run HTTP Server (Kestrel Http)

        // 1) Tao IHostBuilder
        // 2) Cau hinfh, dang ky cac dich vu ( goi ConfigureWebHostDefaults)
        // 3) IHostBuilder.Build() => Host (IHost) 
        // Host.Run();
        // Request => pipeline (Middleware)
        //     public static void Main(string[] args){
        //         System.Console.WriteLine("Start");
        //         IHostBuilder builder = Host.CreateDefaultBuilder(args);
        //         // cau hinh default cho HOST    
        //         builder.ConfigureWebHostDefaults((IWebHostBuilder webBuilder)=>{
        //             // tuy bien them ve host
        //             // webBuilder
        //             // webBuilder.UseWebRoot("public");
        //             webBuilder.UseStartup<MyStartUp>();

        //         });

        //         IHost host = builder.Build();
        //         host.Run();
        //     }

        //Middle Ware and Pipeline
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }
        public static IHostBuilder CreateHostBuilder(string[] args) => 
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<StartUp>();
            });

    }

}
