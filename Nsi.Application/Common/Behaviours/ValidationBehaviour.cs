﻿using FluentValidation;
using MediatR;
using Nsi.Application.Common.Extentions;
using ValidationException = Nsi.Application.Common.Exceptions.ValidationException;

namespace Nsi.Application.Common.Behaviours;

public class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;


    public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }


    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        var context = new ValidationContext<TRequest>(request);

        var validationResult =
            await Task.WhenAll(_validators.Select(x => x.ValidateAsync(context, cancellationToken)));

        var failures = validationResult.SelectMany(r => r.Errors).Where(f => f != null).ToList();
        var groupFailures = failures.ToGroup();

        if (failures.Count != 0)
        {
            throw new ValidationException(failures.ToGroup(), null);
        }

        return await next();
    }
}