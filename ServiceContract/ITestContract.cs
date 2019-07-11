using System.ServiceModel;

namespace TestServer
{
    public interface ITestCallback
    {
        [OperationContract(IsOneWay = true)]
        void Equals(double result);
    }

    [ServiceContract(Namespace = "https://grantadesign.selector.workbench.addin", SessionMode = SessionMode.Required,
        CallbackContract = typeof(ITestCallback))]
    public interface ITestContract
    {
        [OperationContract]
        void Add(int a, int b);

        [OperationContract]
        void Subtract(int a, int b);
    }
}
