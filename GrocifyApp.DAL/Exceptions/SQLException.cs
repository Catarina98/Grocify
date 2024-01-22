using GrocifyApp.DAL.Data.Consts.ENConsts;
using Microsoft.EntityFrameworkCore;

namespace GrocifyApp.DAL.Exceptions
{
    public class SQLException : CustomException
    {
        public static SQLExceptionType SqlExceptionType { get; set; }
        public static string? EntityName { get; set; }
        public static string? ForeignKey { get; set; }

        public SQLException(DbUpdateException ex, string entityName) : base(GetExceptionMessage(ex, entityName))
        {
        }

        private static string GetExceptionMessage(DbUpdateException ex, string entityName)
        {
            var innerException = ex.InnerException;

            EntityName = entityName;

            SqlExceptionType = SQLExceptionType.Other;

            var message = GenericConsts.SQLExceptions.Generic;


            if (innerException is Microsoft.Data.SqlClient.SqlException sqlException)
            {
                if (sqlException.Number == 547)
                {
                    SqlExceptionType = SQLExceptionType.ForeignKeyViolation;

                    ForeignKey = sqlException.Message.Split("FK_").Last().Split(" ")[0];

                    message = string.Format(GenericConsts.SQLExceptions.ForeignKeyException, ForeignKey);
                }
                else if (sqlException.Number == 2601 || sqlException.Number == 2627)
                {
                    SqlExceptionType = SQLExceptionType.DuplicateEntity;

                    message = string.Format(GenericConsts.SQLExceptions.DuplicateEntityFormat, entityName);
                }
            }

            return message;
        }

        public enum SQLExceptionType
        {
            ForeignKeyViolation,
            DuplicateEntity,
            Other
        }
    }

}
