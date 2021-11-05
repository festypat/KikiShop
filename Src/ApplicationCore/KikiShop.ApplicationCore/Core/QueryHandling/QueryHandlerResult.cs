using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KikiShop.ApplicationCore.Core.QueryHandling
{
    public class QueryHandlerResult<TResult>
    {
        public ValidationResult ValidationResult { get; }

        public TResult Result { get; set; }

        public QueryHandlerResult(IQuery<QueryHandlerResult<TResult>> query)
        {
            ValidationResult = query.Validate();
        }
    }

}
