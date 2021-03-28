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

        Task<T> IQueryDispatcher.DispatchAsync<TQuery, T>(Action<TQuery> parameters)
        {
            var query = (TQuery)_serviceProvider.GetService(typeof(TQuery));            
            parameters?.Invoke(query);
            return query.Dispatch();
        }
    }
}
