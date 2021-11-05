using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KikiShop.Seed
{
    public interface IRepository<T> where T : IAggregateRoot
    {
    }
}
