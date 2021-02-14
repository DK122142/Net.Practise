using System;
using System.Linq.Expressions;
using System.Text;

namespace EducationPortalADO.DAL.Infrastructure
{
    public class SqlQueryHelper
    {
        public string SqlFromPredicate<T>(Expression<Func<T, Boolean>> predicate)
        {
            var whereQuery = new StringBuilder(predicate.Body.ToString());

            foreach (var parameterExpression in predicate.Parameters)
            {
                whereQuery.Replace($"{parameterExpression.Name}.", string.Empty);
            }
            
            whereQuery.Replace("(", string.Empty);
            whereQuery.Replace(")", string.Empty);
            whereQuery.Replace("AndAlso", "AND");
            whereQuery.Replace("OrElse", "OR");
            whereQuery.Replace("\"", "'");
            whereQuery.Replace("==", "=");

            return whereQuery.ToString();
        }
    }
}
