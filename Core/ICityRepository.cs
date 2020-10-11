using Brokerage.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brokerage.Core
{
    public interface ICityRepository    {

        void Add(City city);
        void Remove(City city);
        Task<City> GetCity(int id);
    }
}
