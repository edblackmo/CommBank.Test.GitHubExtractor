using System;
using System.Threading.Tasks;

namespace CommBank.Test.CQRS.Queries
{
    public class QueryDispatcher : IQueryDispatcher
    {
        private readonly IServiceProvider _serviceProvider;

        public QueryDispatcher(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        Task<T> IQueryDispatcher.DispatchAsync<Q, T>(Action<Q> parameters)
        {
            var query = (Q)_serviceProvider.GetService(typeof(Q));            
            parameters?.Invoke(query);
            return query.Dispatch();
        }
    }
}
