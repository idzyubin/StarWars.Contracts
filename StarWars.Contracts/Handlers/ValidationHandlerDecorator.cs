using FluentValidation;
using FluentValidation.Results;
using StarWars.Contracts.Interfaces;
using StarWars.Contracts.Models;
using StarWars.Contracts.Requests;
using StarWars.Contracts.Responses;

namespace StarWars.Contracts.Handlers;

/// <summary>
///     Базовый обработчик, проводящий валидацию поступающего запроса
/// </summary>
/// <typeparam name="TRequest"><see cref="Request"/></typeparam>
/// <typeparam name="TResponse"><see cref="Response"/></typeparam>
public abstract class BaseHandler<TRequest, TResponse> : IHandler<TRequest, TResponse>
    where TRequest : Request
    where TResponse : Response
{
    private readonly IValidator<TRequest> _validator;
    private readonly IHandler<TRequest, TResponse> _handler;

    /// <inheritdoc cref="IHandler{TRequest,TResponse}" />
    public BaseHandler(IHandler<TRequest, TResponse> handler, IValidator<TRequest> validator)
    {
        _handler = handler;
        _validator = validator;
    }

    /// <inheritdoc />
    public async ValueTask<Result<TResponse, ValidationResult>> HandleAsync(TRequest request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        return validationResult.IsValid
            ? await _handler.HandleAsync(request, cancellationToken)
            : validationResult;
    }
}