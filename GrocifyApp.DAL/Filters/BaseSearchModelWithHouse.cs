using GrocifyApp.DAL.Models;
using System.Linq.Expressions;

namespace GrocifyApp.DAL.Filters
{
    public class BaseSearchModelWithHouse<T>: BaseSearchModel<T> where T : BaseEntityWithHouse
    {
        public Guid? HouseIdFilter;

        public override Expression<Func<T, bool>> BuildExpression()
        {
            var (expression, parameter) = GetExpression();

            var houseIdProperty = Expression.Property(parameter, nameof(BaseEntityWithHouse.HouseId));

            var houseIdValue = Expression.Constant(HouseIdFilter, typeof(Guid?));

            var nullValue = Expression.Constant(null, typeof(Guid?));

            var equalCondition = Expression.Equal(houseIdProperty, houseIdValue);

            var nullCondition = Expression.Equal(houseIdProperty, nullValue);

            var orCondition = Expression.OrElse(equalCondition, nullCondition);

            var body = Expression.AndAlso(expression, orCondition);

            return Expression.Lambda<Func<T, bool>>(body, parameter);
        }
    }
}
