using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

public class ApiFeatures<T>
{
    private IQueryable<T> _query;
    private readonly IDictionary<string, string> _queryParams;

    public ApiFeatures(IQueryable<T> query, IDictionary<string, string> queryParams)
    {
        _query = query;
        _queryParams = queryParams;
    }

    public ApiFeatures<T> Filter()
    {
        var excludedFields = new[] { "page", "sort", "limit", "fields" };

        foreach (var param in _queryParams)
        {
            if (excludedFields.Contains(param.Key))
                continue;

            // Get property info
            var propertyInfo = typeof(T).GetProperty(param.Key, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
            if (propertyInfo == null) continue;

            // Build expression: x => x.Property == param.Value
            var parameter = Expression.Parameter(typeof(T), "x");
            var property = Expression.Property(parameter, propertyInfo);

            object convertedValue;

            // Convert param.Value to the property type
            if (propertyInfo.PropertyType.IsEnum)
            {
                // Try to parse the enum (ignore case)
                convertedValue = Enum.Parse(propertyInfo.PropertyType, param.Value.ToString(), true);
            }
            else
            {
                convertedValue = Convert.ChangeType(param.Value, propertyInfo.PropertyType);
            }
            var constant = Expression.Constant(convertedValue);
            var equality = Expression.Equal(property, constant);

            var lambda = Expression.Lambda<Func<T, bool>>(equality, parameter);

            _query = _query.Where(lambda);
        }

        return this;
    }

    public ApiFeatures<T> Sort()
    {
        if (_queryParams.ContainsKey("sort"))
        {
            var sortBy = _queryParams["sort"];
            var isDescending = false;

            if (sortBy.StartsWith("-"))
            {
                sortBy = sortBy.Substring(1);
                isDescending = true;
            }

            var param = Expression.Parameter(typeof(T), "x");
            var property = Expression.Property(param, sortBy);
            var lambda = Expression.Lambda(property, param);

            var methodName = isDescending ? "OrderByDescending" : "OrderBy";
            var resultExp = Expression.Call(typeof(Queryable), methodName,
                new Type[] { typeof(T), property.Type },
                _query.Expression, Expression.Quote(lambda));

            _query = _query.Provider.CreateQuery<T>(resultExp);
        }
        return this;
    }

    public ApiFeatures<T> Paginate()
    {
        int page = _queryParams.ContainsKey("page") ? int.Parse(_queryParams["page"]) : 1;
        int limit = _queryParams.ContainsKey("limit") ? int.Parse(_queryParams["limit"]) : 10;
        int skip = (page - 1) * limit;

        _query = _query.Skip(skip).Take(limit);
        return this;
    }

    public IQueryable<T> Build() => _query;
}
