using System.Reflection;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using StarWars.Contracts.Handlers;
using StarWars.Contracts.Interfaces;

namespace StarWars.Contracts.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddHandlersFromAssemblyOf<T>(this IServiceCollection services) =>
        services
            .Scan(scan => scan
                .FromAssemblyOf<T>()
                .AddClasses(classes => classes.AssignableTo(typeof(IHandler<,>)))
                .AsImplementedInterfaces()
                .WithScopedLifetime())
            .Decorate(typeof(IHandler<,>), typeof(ValidationHandlerDecorator<,>));
    
    public static IServiceCollection AddValidatorsFromAssemblyOf<T>(this IServiceCollection services) =>
        services.AddValidatorsFromAssemblyContaining<T>();
}