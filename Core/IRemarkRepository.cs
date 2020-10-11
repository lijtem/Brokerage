using Brokerage.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brokerage.Core
{
    public interface IRemarkRepository
    {
        Task<Remark> GetRemarks(int id);
        void Add(Remark remark);
        void Remove(Remark remark);
    }
}
