using FluentValidation.Results;
using StarWars.Contracts.Models;
using StarWars.Contracts.Requests;
using StarWars.Contracts.Responses;

namespace StarWars.Contracts.Interfaces;

/// <summary>
///     Интерфейс обработчика сообщения.
/// </summary>
/// <typeparam name="TRequest">Данные запроса</typeparam>
/// <typeparam name="TResponse">Данные ответа</typeparam>
public interface IHandler<in TRequest, TResponse>
    where TRequest : Request<TResponse>
    where TResponse : Response
{
    /// <summary>
    ///     Обработчик входящего запроса
    /// </summary>
    /// <param name="request"><see cref="Request"/></param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
    /// <returns><see cref="Response"/></returns>
    ValueTask<Result<TResponse, ValidationResult>> HandleAsync(TRequest request, CancellationToken cancellationToken);
}