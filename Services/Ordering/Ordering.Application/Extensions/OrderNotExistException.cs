using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.Extensions
{
    public class OrderNotExistException : ApplicationException
    {
        public OrderNotExistException(string name, int key) : base($"Entity {name}, with key {key} not found")
        {
            
        }
    }
}
