using GrocifyApp.DAL.Data.Consts.ENConsts;

namespace GrocifyApp.DAL.Exceptions
{
    public class CustomException : Exception
    {
        public CustomException() : base(GenericConsts.Exceptions.Generic)
        {
        }

        public CustomException(string message) : base(message)
        {
        }

        public CustomException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
