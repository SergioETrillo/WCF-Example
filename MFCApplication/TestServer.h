#pragma once

ref class SomeClass
{
public:
    static void Func(TestServer::ITestCallback^ clientCallback)
    {
        System::Threading::Thread::Sleep(1000);
        clientCallback->Equals(4);
        theApp.OnAppAbout();
    }
};

delegate void MyCallback(TestServer::ITestCallback^ clientCallback);

[System::ServiceModel::ServiceBehavior(InstanceContextMode = System::ServiceModel::InstanceContextMode::Single)]
public ref class MyTestServer : public TestServer::ITestContract
{
public:
    MyTestServer() {};

    virtual void Add(int a, int b)
    {
        MyCallback^ callback = gcnew MyCallback(SomeClass::Func);

        TestServer::ITestCallback^ clientCallback = System::ServiceModel::OperationContext::Current->GetCallbackChannel<TestServer::ITestCallback^>();

        theApp.m_Dispatcher->BeginInvoke(callback, clientCallback);
        // return a + b;
    }

    virtual void Subtract(int a, int b)
    {
        // return a - b;
    }
};

