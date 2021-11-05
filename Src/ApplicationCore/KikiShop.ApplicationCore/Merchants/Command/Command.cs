﻿using FluentValidation.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KikiShop.ApplicationCore.Merchants.Command
{
    public interface ICommand<out TResult> : IRequest<TResult>
    {
        public abstract ValidationResult Validate();
    }

    /// <summary>
    /// Abstract classes meant to be inherited by Commands
    /// </summary>
    public abstract class Command<TID> : ICommand<CommandHandlerResult<TID>>
        where TID : struct
    {
        public ValidationResult ValidationResult { get; set; }

        /// <summary>
        /// Validation method
        /// </summary>
        /// <returns></returns>
        public virtual ValidationResult Validate()
        {
            return ValidationResult;
        }
    }
}
