using GrocifyApp.DAL.Data.Consts.ENConsts;

namespace GrocifyApp.DAL.Exceptions
{
    public class EmailExistsException : Exception
    {
        public EmailExistsException() : base(GenericConsts.Exceptions.EmailAlreadyTaken)
        {
        }

        public EmailExistsException(string message) : base(message)
        {
        }

        public EmailExistsException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
