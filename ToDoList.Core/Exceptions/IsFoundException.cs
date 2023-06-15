using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Core.Exceptions
{
    public class IsFoundException : Exception
    {
        public IsFoundException() : base("the item is found")
        {

        }
    }
}
