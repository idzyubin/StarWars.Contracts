using StarWars.Contracts.Interfaces;
using StarWars.Contracts.Responses;

namespace StarWars.Contracts.Requests;

public record Request<TResponse>() : IRequest<TResponse> where TResponse : Response;