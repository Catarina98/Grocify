using GrocifyApp.DAL.Models;
using System.Linq.Expressions;
using System.Reflection;

namespace GrocifyApp.DAL.Filters
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ContainsSearchAttribute : System.Attribute
    {
    }

    public class BaseSearchModel<T> where T : BaseEntity
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;

        protected (Expression, ParameterExpression) GetExpression()
        {
            ParameterExpression parameter = Expression.Parameter(typeof(T), "x");
            Expression? expression = null;
            MethodInfo containsMethod = typeof(string).GetMethod("Contains", [typeof(string)])!;

            foreach (PropertyInfo propInfo in GetType().GetProperties())
            {
                object? value = propInfo.GetValue(this);
                var prop = typeof(T).GetProperty(propInfo.Name);

                if (value != null && prop != null)
                {
                    Expression property = Expression.Property(parameter, prop);
                    Expression constant = Expression.Constant(value, prop.PropertyType);

                    Expression? temp;

                    if (propInfo.GetCustomAttribute<ContainsSearchAttribute>() != null && prop.PropertyType == typeof(string))
                    {
                        temp = Expression.Call(property, containsMethod, constant);
                    }
                    else
                    {
                        temp = Expression.Equal(property, constant);
                    }

                    if (expression == null)
                    {
                        expression = temp;
                    }
                    else
                    {
                        expression = Expression.AndAlso(expression, temp);
                    }
                }
            }

            if (expression != null)
            {
                return (expression, parameter);
            }
            else
            {
                return (Expression.Constant(true), parameter);
            }
        }

        public virtual Expression<Func<T, bool>> BuildExpression()
        {
            var (expression, parameter) = GetExpression();

            return Expression.Lambda<Func<T, bool>>(expression, parameter);
        }
    }
}
