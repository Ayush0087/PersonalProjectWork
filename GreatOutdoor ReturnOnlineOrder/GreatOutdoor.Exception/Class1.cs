using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreatOutdoor.Exception
{
    public class OnlineReturnException : ApplicationException
    {
        public OnlineReturnException()
            :base()
        {

        }
        public OnlineReturnException(string message)
            :base(message)
        {

        }
        public OnlineReturnException(string message, ApplicationException innerException)
            :base(message, innerException)
        {

        }
    }
}
