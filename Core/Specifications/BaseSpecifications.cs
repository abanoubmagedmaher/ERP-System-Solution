using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specifications
{
    public class BaseSpecifications<T> : ISpecification<T>
    {
        public BaseSpecifications()
        {
            
        }
        public BaseSpecifications(Expression<Func<T, bool>> criteria)
        {
            Criteria=criteria;
        }
        public Expression<Func<T, bool>> Criteria { get; }

        public List<Expression<Func<T, object>>> Includes
                { get; }= new List<Expression<Func<T, object>>>();

        #region Sortting
        public Expression<Func<T, object>> OrderBy { get; private set; }

        public Expression<Func<T, object>> OrderByDesc { get; private set; }

        #endregion

        #region Includes
        protected void AddIncludes(Expression<Func<T,object>> includeExpression)
        {
            Includes.Add(includeExpression);
        }
        #endregion

        #region Sortting Function
        protected void AddOrderBy(Expression<Func<T, object>> orderByExpretion)
        {
            OrderBy = orderByExpretion;
        }
        protected void AddorderByDesc(Expression<Func<T, object>> orderByExpressionDesc)
        {
            OrderByDesc = orderByExpressionDesc;
        }
        #endregion

        #region Pagination
        public int Take { get;  set; }

        public int Skip { get;  set; }

        public bool IsPagingEnabled { get;  set; }

        public void ApplyPaging(int skip ,int take)
        {
            Skip = skip;
            Take = take;
            IsPagingEnabled = true;
        }
        #endregion
    }
}
