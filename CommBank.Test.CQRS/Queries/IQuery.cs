using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CommBank.Test.CQRS.Queries
{
    public interface IQuery<T>
    {
        Task<T> Dispatch();
    }
}
