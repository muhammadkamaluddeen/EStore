using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EStore.Models
{
    public interface IOrder
    {

        void CreateOrder(Order order);
    }
}
