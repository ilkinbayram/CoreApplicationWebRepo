using System.Transactions;

using Castle.DynamicProxy;
using Core.Utilities.Interceptors;

namespace Core.Aspects.Autofac.Transaction
{
    public class TransactionScopeAspectAsync : MethodInterception
    {
        public override void Intercept(IInvocation invocation)
        {
            using (TransactionScope transactionScope = new TransactionScope(TransactionScopeOption.Required,TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    invocation.Proceed();
                    transactionScope.Complete();
                }
                catch (System.Exception)
                {
                    transactionScope.Dispose();
                    throw;
                }
            }
        }
    }
}
