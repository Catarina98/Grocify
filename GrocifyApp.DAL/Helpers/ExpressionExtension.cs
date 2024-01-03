using System.Linq.Expressions;

namespace GrocifyApp.DAL.Helpers
{
    public static class ExpressionsExtension<T>
    {
        public static Expression<Func<T, bool>> MergeAndExpressions(List<Expression<Func<T, bool>>> expressions)
        {
            Expression<Func<T, bool>> result = null;

            foreach (var exp in expressions)
            {
                if (result == null)
                {
                    result = exp;
                }
                else
                {
                    result = AndExpression2(result, exp);
                }

            }

            return result;
        }

        public static Expression<Func<T, bool>> AndExpression //check which is better
                    (Expression<Func<T, bool>> left, Expression<Func<T, bool>> right)
        {
            var invoked = Expression.Invoke(right, left.Parameters.Cast<Expression>());
            return Expression.Lambda<Func<T, bool>>
            (Expression.AndAlso(left.Body, invoked), left.Parameters);
        }

        private class ParameterReplaceVisitor : ExpressionVisitor
        {
            public ParameterExpression Target { get; set; }
            public ParameterExpression Replacement { get; set; }

            protected override Expression VisitParameter(ParameterExpression node)
            {
                return node == Target ? Replacement : base.VisitParameter(node);
            }
        }

        public static Expression<Func<T, bool>> AndExpression2( //check which is better
            Expression<Func<T, bool>> left, Expression<Func<T, bool>> right)
        {
            var visitor = new ParameterReplaceVisitor()
            {
                Target = right.Parameters[0],
                Replacement = left.Parameters[0],
            };

            var rewrittenRight = visitor.Visit(right.Body);
            var andExpression = Expression.AndAlso(left.Body, rewrittenRight);
            return Expression.Lambda<Func<T, bool>>(andExpression, left.Parameters);
        }
    }
}


