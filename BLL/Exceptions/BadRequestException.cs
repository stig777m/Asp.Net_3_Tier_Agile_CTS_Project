using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;


namespace project_demo_1.BLL.Exceptions
{
    public class BadRequestException : Exception
    {
        public BadRequestException(string message) : base(message) { }
    }
}
