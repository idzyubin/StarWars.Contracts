using StarWars.Contracts.Responses;

namespace StarWars.Contracts.Interfaces;

public interface IRequest<TResponse> where TResponse : Response
{
}