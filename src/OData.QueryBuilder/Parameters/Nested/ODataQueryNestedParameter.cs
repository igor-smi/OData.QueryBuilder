﻿using OData.QueryBuilder.Builders.Nested;
using OData.QueryBuilder.Constants;
using OData.QueryBuilder.Extensions;
using System;
using System.Linq.Expressions;
using System.Text;

namespace OData.QueryBuilder.Parameters.Nested
{
    public class ODataQueryNestedParameter<TEntity> : ODataQueryNested, IODataQueryNestedParameter<TEntity>
    {
        public ODataQueryNestedParameter()
            : base(new StringBuilder())
        {
        }

        public IODataQueryNestedParameter<TEntity> Expand(Expression<Func<TEntity, object>> entityNestedExpand)
        {
            var query = entityNestedExpand.Body.ToODataQuery();

            _stringBuilder.Append($"{ODataQueryParameters.Expand}{ODataQuerySeparators.EqualSignString}{query}{ODataQuerySeparators.NestedString}");

            return this;
        }

        public IODataQueryNestedParameter<TEntity> Expand(Action<IODataQueryNestedBuilder<TEntity>> actionEntityExpandNested)
        {
            var builder = new ODataQueryNestedBuilder<TEntity>();

            actionEntityExpandNested(builder);

            _stringBuilder.Append($"{ODataQueryParameters.Expand}{ODataQuerySeparators.EqualSignString}{builder.Query}{ODataQuerySeparators.NestedString}");

            return this;
        }

        public IODataQueryNestedParameter<TEntity> Filter(Expression<Func<TEntity, bool>> entityNestedFilter)
        {
            var query = entityNestedFilter.Body.ToODataQuery();

            _stringBuilder.Append($"{ODataQueryParameters.Filter}{ODataQuerySeparators.EqualSignString}{query}{ODataQuerySeparators.NestedString}");

            return this;
        }

        public IODataQueryNestedParameter<TEntity> OrderBy(Expression<Func<TEntity, object>> entityNestedOrderBy)
        {
            var query = entityNestedOrderBy.Body.ToODataQuery();

            _stringBuilder.Append($"{ODataQueryParameters.OrderBy}{ODataQuerySeparators.EqualSignString}{query} {ODataQuerySorts.Asc}{ODataQuerySeparators.NestedString}");

            return this;
        }

        public IODataQueryNestedParameter<TEntity> OrderByDescending(Expression<Func<TEntity, object>> entityNestedOrderByDescending)
        {
            var query = entityNestedOrderByDescending.Body.ToODataQuery();

            _stringBuilder.Append($"{ODataQueryParameters.OrderBy}{ODataQuerySeparators.EqualSignString}{query} {ODataQuerySorts.Desc}{ODataQuerySeparators.NestedString}");

            return this;
        }

        public IODataQueryNestedParameter<TEntity> Select(Expression<Func<TEntity, object>> entityNestedSelect)
        {
            var query = entityNestedSelect.Body.ToODataQuery();

            _stringBuilder.Append($"{ODataQueryParameters.Select}{ODataQuerySeparators.EqualSignString}{query}{ODataQuerySeparators.NestedString}");

            return this;
        }

        public IODataQueryNestedParameter<TEntity> Top(int value)
        {
            _stringBuilder.Append($"{ODataQueryParameters.Top}{ODataQuerySeparators.EqualSignString}{value}{ODataQuerySeparators.NestedString}");

            return this;
        }
    }
}
