using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sockets
{
    class Program
    {
        static TcpListener listener;

        //TODO: make it a chat
        //TODO: clients should be able to connect from all over the world (change IP in SocketsClient, it's the only thing to change there)
        //TODO: whenever client disconnects server crashes.

        static void Main(string[] args)
        {
            listener = new TcpListener(IPAddress.Any, 7865);
            listener.Start();

            BeginAccepting();

            Console.ReadKey();
        }

        private static void BeginAccepting()
        {
            listener.BeginAcceptSocket(connectionCallback, new object());
        }

        private static void connectionCallback(IAsyncResult ar)
        {
            var client = listener.EndAcceptSocket(ar);
            //TODO: to all connected clients send information that new client has connected (with it's IP)

            new Thread(() =>
            {
                while (client.Connected)
                {
                    var bytes = new byte[1024];
                    var i = client.Receive(bytes);
                    var str = Encoding.UTF8.GetString(bytes, 0, i);
                    //TODO: save first message as name of client
                    //TODO: write to others that connected one name is as first mesage

                    //TODO: any next message: broadcast message to other clients, but add client's name on the begining (so if client's name is "Neo" broadcast message as "Neo: " + message;
                    client.Send(Encoding.UTF8.GetBytes(str));
                }
                Console.WriteLine($"client {client.AddressFamily} disconnected");
            }).Start();

            BeginAccepting();
        }
    }
}
