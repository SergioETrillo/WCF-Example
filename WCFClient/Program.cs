using System;
using System.ServiceModel;
using TestServer;

namespace WCFClient
{
    public class CallbackHandler : ITestCallback
    {
        public void Equals(double result)
        {
            Console.WriteLine("Equals({0})", result);
        }
    }

    class Program
    {
        // Program.cs
        static void Main(string[] args)
        {
            string address = "net.pipe://localhost/selector/12345";

            NetNamedPipeBinding binding = new NetNamedPipeBinding(NetNamedPipeSecurityMode.None);
            EndpointAddress ep = new EndpointAddress(address);
            CallbackHandler callbackHandler = new CallbackHandler();
            ITestContract channel = DuplexChannelFactory<ITestContract>.CreateChannel(callbackHandler, binding, ep);

            Console.WriteLine("Client Connected");

            Console.WriteLine(" 2 + 2 = ");
            channel.Add(2, 2);
            Console.WriteLine(" 256 - 89 =");
            channel.Subtract(256, 89);

            Console.ReadLine();
        }
    }
}
