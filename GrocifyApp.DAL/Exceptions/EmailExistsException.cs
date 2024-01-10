using GrocifyApp.DAL.Data.Consts.ENConsts;

namespace GrocifyApp.DAL.Exceptions
{
    public class EmailExistsException : Exception
    {
        public EmailExistsException() : base(GenericConsts.Exceptions.EmailAlreadyTaken)
        {
        }
    }
}
