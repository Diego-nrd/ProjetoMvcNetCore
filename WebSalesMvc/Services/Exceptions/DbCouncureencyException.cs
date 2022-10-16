using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSalesMvc.Services.Exceptions
{
    public class DbCouncureencyException : ApplicationException
    {
        public DbCouncureencyException(string message) : base(message)
        {

        }
    }
}
