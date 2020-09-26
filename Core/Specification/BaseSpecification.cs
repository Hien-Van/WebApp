using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Core.Specification
{
    public class BaseSpecification<T> : ISpecification<T>
    {
        public BaseSpecification()
        {
        }

        public BaseSpecification(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
        }

        public Expression<Func<T, bool>> Criteria {get;}

        public List<Expression<Func<T, object>>> Includes {get;} = 
                new List<Expression<Func<T, object>>>();

        public Expression<Func<T, object>> OrderBy {get; private set;}

        public Expression<Func<T, object>> OrderByDesc {get; private set;}

        public int Take {get;private set;}

        public int Skipt {get;private set;}

        public bool IsPagingEnable {get;set;}

        protected void AddInclude(Expression<Func<T, object>> include)
        {
            Includes.Add(include);
        }

        protected void AddOrderBy(Expression<Func<T, object>> orderByExpressions)
        {
            OrderBy = orderByExpressions;
        }

        protected void AddOrderByDesc(Expression<Func<T, object>> orderByDescExpressions)
        {
            OrderByDesc = orderByDescExpressions;
        }

        protected void ApplyPaging(int take, int skipt, bool isPagingEnable)
        {
            Take = take;
            Skipt = skipt;
            IsPagingEnable = isPagingEnable;
        }
            
    }
}
