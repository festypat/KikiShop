using FluentValidation.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KikiShop.ApplicationCore.Core.QueryHandling
{
    public interface IQuery<out TResult> : IRequest<TResult>
    {
        public abstract ValidationResult Validate();
    }

    /// <summary>
    /// Abstract class to be inherited by Queries
    /// </summary>
    public abstract class Query<TResult> : IQuery<QueryHandlerResult<TResult>>
    {
        public ValidationResult ValidationResult { get; set; }

        public virtual ValidationResult Validate()
        {
            return ValidationResult;
        }
    }
}
