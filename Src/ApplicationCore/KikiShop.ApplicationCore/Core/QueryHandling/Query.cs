using FluentValidation.Results;
using MediatR;

namespace KikiShop.ApplicationCore.Core.QueryHandling
{
    public interface IQuery<out TResult> : IRequest<TResult>
    {
        public abstract ValidationResult Validate();
    }       
    public abstract class Query<TResult> : IQuery<QueryHandlerResult<TResult>>
    {
        public ValidationResult ValidationResult { get; set; }

        public virtual ValidationResult Validate()
        {
            return ValidationResult;
        }
    }
}
