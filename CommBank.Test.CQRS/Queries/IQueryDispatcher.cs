using System;
using System.Threading.Tasks;

namespace CommBank.Test.CQRS.Queries
{
    public interface IQueryDispatcher
    {
        Task<T> DispatchAsync<Q, T>(Action<Q> initialiseParameters = null)
           where T : class
           where Q : class, IQuery<T>;
    }
}
