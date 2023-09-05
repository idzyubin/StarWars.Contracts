using FluentValidation.Results;
using StarWars.EpisodeService.Application.Models;
using StarWars.EpisodeService.Application.Requests;
using StarWars.EpisodeService.Application.Responses;

namespace StarWars.EpisodeService.Application.Interfaces;

/// <summary>
///     Интерфейс обработчика сообщения.
/// </summary>
/// <typeparam name="TRequest">Данные запроса</typeparam>
/// <typeparam name="TResponse">Данные ответа</typeparam>
public interface IHandler<in TRequest, TResponse>
    where TRequest : Request
    where TResponse : Response
{
    /// <summary>
    ///     Обработчик входящего запроса
    /// </summary>
    /// <param name="request"><see cref="Request"/></param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
    /// <returns><see cref="Response"/></returns>
    static abstract ValueTask<Result<Response, ValidationResult>> HandleAsync(TRequest request, CancellationToken cancellationToken);
}