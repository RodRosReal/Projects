using DynamicExpresso;
using Domain.ValueObjects;
using System.Linq.Expressions;

namespace System.Linq
{
    public static class QueryableInterfaceExtensions
    {
        public static IOrderedQueryable<TEntity> OrderBy<TEntity>(this IQueryable<TEntity> source, string propertyName, SortDirection direction)
        {
            var typeProperty = typeof(TEntity).GetProperty(propertyName).PropertyType.Name.ToLower();

            if (typeProperty == "int32")
            {
                var orderExpression = GetOrderExpression<TEntity, int>(propertyName);

                var orderedSource = direction == SortDirection.Ascending
                    ? source.OrderBy(orderExpression)
                    : source.OrderByDescending(orderExpression);

                return orderedSource;
            }
            else if (typeProperty == "int64")
            {
                var orderExpression = GetOrderExpression<TEntity, long>(propertyName);

                var orderedSource = direction == SortDirection.Ascending
                    ? source.OrderBy(orderExpression)
                    : source.OrderByDescending(orderExpression);

                return orderedSource;
            }
            else if (typeProperty == "string")
            {
                var orderExpression = GetOrderExpression<TEntity, string>(propertyName);

                var orderedSource = direction == SortDirection.Ascending
                    ? source.OrderBy(orderExpression)
                    : source.OrderByDescending(orderExpression);

                return orderedSource;
            }
            else if (typeProperty == "datetime")
            {
                var orderExpression = GetOrderExpression<TEntity, DateTime>(propertyName);

                var orderedSource = direction == SortDirection.Ascending
                    ? source.OrderBy(orderExpression)
                    : source.OrderByDescending(orderExpression);

                return orderedSource;
            }
            else if (typeProperty == "bool" || typeProperty == "boolean")
            {
                var orderExpression = GetOrderExpression<TEntity, bool>(propertyName);

                var orderedSource = direction == SortDirection.Ascending
                    ? source.OrderBy(orderExpression)
                    : source.OrderByDescending(orderExpression);

                return orderedSource;
            }
            return null;
        }

        public static IOrderedQueryable<TEntity> ThenBy<TEntity>(this IOrderedQueryable<TEntity> source, string propertyName, SortDirection direction)
        {
            var typeProperty = typeof(TEntity).GetProperty(propertyName).PropertyType.Name.ToLower();

            if (typeProperty == "int32")
            {
                var orderExpression = GetOrderExpression<TEntity, int>(propertyName);

                var orderedSource = direction == SortDirection.Ascending
                    ? source.ThenBy(orderExpression)
                    : source.ThenByDescending(orderExpression);

                return orderedSource;
            }
            if (typeProperty == "int64")
            {
                var orderExpression = GetOrderExpression<TEntity, long>(propertyName);

                var orderedSource = direction == SortDirection.Ascending
                    ? source.ThenBy(orderExpression)
                    : source.ThenByDescending(orderExpression);

                return orderedSource;
            }
            else if (typeProperty == "string")
            {
                var orderExpression = GetOrderExpression<TEntity, string>(propertyName);

                var orderedSource = direction == SortDirection.Ascending
                    ? source.ThenBy(orderExpression)
                    : source.ThenByDescending(orderExpression);

                return orderedSource;
            }
            else if (typeProperty == "datetime")
            {
                var orderExpression = GetOrderExpression<TEntity, DateTime>(propertyName);

                var orderedSource = direction == SortDirection.Ascending
                    ? source.ThenBy(orderExpression)
                    : source.ThenByDescending(orderExpression);

                return orderedSource;
            }
            else if (typeProperty == "bool" || typeProperty == "boolean")
            {
                var orderExpression = GetOrderExpression<TEntity, bool>(propertyName);

                var orderedSource = direction == SortDirection.Ascending
                    ? source.ThenBy(orderExpression)
                    : source.ThenByDescending(orderExpression);

                return orderedSource;
            }
            return null;
        }

        private static Expression<Func<TEntity, TType>> GetOrderExpression<TEntity, TType>(string propertyName)
        {
            return new Interpreter()
                .ParseAsExpression<Func<TEntity, TType>>($"entity.{propertyName}", "entity");
        }
    }
}
