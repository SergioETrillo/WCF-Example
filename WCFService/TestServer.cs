// IPCTestServer.cs
using System.ServiceModel;

namespace TestServer
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public class TestServer : ITestContract
    {
        public void Add(int a, int b)
        {
            System.Threading.Thread.Sleep(1000);
            Callback.Equals(a + b);
        }

        public void Subtract(int a, int b)
        {
            Callback.Equals(a - b);
        }

        ITestCallback Callback => OperationContext.Current.GetCallbackChannel<ITestCallback>();
    }
}