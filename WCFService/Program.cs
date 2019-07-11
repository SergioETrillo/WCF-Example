using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WCFService
{
    class Program
    {
        static void Main(string[] args)
        {
            string address = "net.pipe://localhost/selector/12345";

            NetNamedPipeBinding binding = new NetNamedPipeBinding(NetNamedPipeSecurityMode.None);
            ServiceHost serviceHost = new ServiceHost(typeof(TestServer.TestServer));
            serviceHost.AddServiceEndpoint(typeof(TestServer.ITestContract), binding, address);
            serviceHost.Open();

            Console.WriteLine("ServiceHost running. Press Return to Exit");
            Console.ReadLine();
        }
    }
}
