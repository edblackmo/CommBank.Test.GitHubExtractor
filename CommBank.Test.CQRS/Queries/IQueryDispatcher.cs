using System;
using System.Threading.Tasks;

namespace CommBank.Test.CQRS.Queries
{
    public interface IQueryDispatcher
    {
        Task<T> DispatchAsync<TQuery, T>(Action<TQuery> initialiseParameters = null)
           where T : class
           where TQuery : class, IQuery<T>;
    }
}
