using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SIS.HTTP
{
    public class HttpServer : IHttpServer
    {
        private readonly TcpListener tcpListener; 

        public HttpServer(int port)
        {
            this.tcpListener = new TcpListener(IPAddress.Loopback, port);
        }

        public async Task ResetAsync()
        {
            this.Stop();
            await this.StartAsync();
        }

        public async Task StartAsync()
        {
            this.tcpListener.Start();
            while (true)
            {
                TcpClient tcpClient = await this.tcpListener.AcceptTcpClientAsync();

                Task.Run(() => ProcessClientAsync(tcpClient));
            }
        }

        public void Stop()
        {
            this.tcpListener.Stop();
        }

        private async Task ProcessClientAsync(TcpClient tcpClient)
        {
            using NetworkStream networkStream = tcpClient.GetStream();
            byte[] requestBytes = new byte[1000000]; // TODO: Use buffer
            int bytesRead = await networkStream.ReadAsync(requestBytes, 0, requestBytes.Length);
            string requestAsString = Encoding.UTF8.GetString(requestBytes, 0, bytesRead);
            var request = new HttpRequest(requestAsString);
            string responseText = "<h1>Hello There</h1>";
            string headers = "HTTP/1.0 200 OK" + HttpConstants.NewLine +
                              "Server: SoftUniServer/1.0" + HttpConstants.NewLine +
                              "Content-Type: text/html" + HttpConstants.NewLine +
                              "Content-Lenght: " + responseText.Length + HttpConstants.NewLine +
                              HttpConstants.NewLine +
                              responseText;
            byte[] headersBytes = Encoding.UTF8.GetBytes(headers);
            await networkStream.WriteAsync(headersBytes, 0, headersBytes.Length);
            Console.WriteLine(request.ToString());
            Console.WriteLine(new string('=', 60));
        }
    }
}
