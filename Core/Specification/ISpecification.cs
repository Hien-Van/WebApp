using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Entites;

namespace Core.Specification
{
    public interface ISpecification<T>
    {
      
         Expression<Func<T, bool>> Criteria { get;}
         List<Expression<Func<T, object>>> Includes{get;}

         Expression<Func<T, object>> OrderBy{get;}
         Expression<Func<T, object>> OrderByDesc{get;}

        int Take{get;}
        int Skipt{get;}
        bool IsPagingEnable{get;set;}
    }
}