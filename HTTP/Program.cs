using System;
using System.Net;
using System.Net.Http.Headers;
using System.Net.NetworkInformation;

namespace HTTP // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            // HTTP (HyperText Transfer Protocol) là giao thức truyền tải siêu văn bản,
            //  giao thức HTTP dựa trên giao thức TCP/IP nó cho phép lấy về
            //  các tài nguyên ví dụ như văn bản HTML, text, video, ảnh ...

            //HTTP là phi trạng thái (stateless), có nghĩa không có mối liên hệ nào 
            // giữa hai yêu cầu được gửi đi, 
            // dù nó là thực hiện trên cùng một kế nối - đến cùng một server.

            // string url = "https://www.youtube.com/watch?v=Z6EKX8FxrkU";
            // var uri = new Uri(url);

            // var uritype = typeof(Uri);
            // uritype.GetProperties().ToList().ForEach(property => {
            //     System.Console.WriteLine($"{property.Name, 15} {property.GetValue(uri)}");
            // });
            //     System.Console.WriteLine($"Segments : {string.Join(",", uri.Segments)}");

            // Lớp DNS , IPHostEntry

            //GetHostName() - lấy hostname của máy local
            // var hostname = Dns.GetHostName();
            // System.Console.WriteLine(hostname);

            // GetHostEntry
            // var url = "https://www.bootstrapcdn.com/";
            // var uri = new Uri(url);
            // System.Console.WriteLine(uri.Host);

            // var iphostentry = Dns.GetHostEntry(uri.Host);
            // System.Console.WriteLine(iphostentry.HostName);
            // iphostentry.AddressList.ToList().ForEach(ip => {
            //     System.Console.WriteLine(ip);
            // });

            //ping
            // var ping = new Ping();
            // var pingReply = ping.Send("google.com.vn");
            // Console.WriteLine(pingReply.Status);
            // if (pingReply.Status == IPStatus.Success)
            // {
            //     Console.WriteLine(pingReply.RoundtripTime);
            //     Console.WriteLine(pingReply.Address);
            // }

            // HTTP REQUEST
            var url = "https://www.youtube.com/watch?v=Z6EKX8FxrkU";
            var html = await GetWebContent(url);
            System.Console.WriteLine(html);


        }
        
            // HTTP REQUEST
        public static async Task<string> GetWebContent(string url){
            using var httpClient = new HttpClient();
            try{

            HttpResponseMessage httpResponseMessage = await httpClient.GetAsync(url);

            string html = await httpResponseMessage.Content.ReadAsStringAsync();
            return html;
            }
            catch (Exception e ){
                System.Console.WriteLine(e.Message);
                return " Error ";
            }

        }
    }
}