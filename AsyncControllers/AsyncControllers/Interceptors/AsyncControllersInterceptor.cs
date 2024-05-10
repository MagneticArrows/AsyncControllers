using Castle.DynamicProxy;

namespace AsyncControllers.Interceptors;
public class AsyncControllersInterceptor : IAsyncInterceptor
{
    #region external
    public void InterceptSynchronous(IInvocation invocation)
    {
        invocation.Proceed();
    }

    public async void InterceptAsynchronous(IInvocation invocation)
    {
        invocation.Proceed();
    }

    public void InterceptAsynchronous<TResult>(IInvocation invocation)
    {
        invocation.Proceed();
    }
    #endregion
}