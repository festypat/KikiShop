using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace KikiShop.ApplicationCore.Core.QueryHandling
{
    public interface IQueryHandler<in TQuery, TResult> : IRequestHandler<TQuery, TResult>
       where TQuery : IQuery<TResult>
    { }
  
    public abstract class QueryHandler<TQuery, TResult> : IQueryHandler<TQuery, QueryHandlerResult<TResult>>
        where TQuery : IQuery<QueryHandlerResult<TResult>>
    {
        /// To override
        public abstract Task<TResult> ExecuteQuery(TQuery query, CancellationToken cancellationToken);

        /// MediatR Handle implementation
        public async Task<QueryHandlerResult<TResult>> Handle(TQuery query, CancellationToken cancellationToken)
        {
            if (query == null)
                throw new ArgumentNullException(nameof(query));

            QueryHandlerResult<TResult> result = new QueryHandlerResult<TResult>(query);

            try
            {
                if (result.ValidationResult.IsValid)
                    result.Result = await ExecuteQuery(query, cancellationToken);
            }
            catch (Exception) { throw; }

            return result;
        }
    }
}
