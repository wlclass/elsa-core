using Elsa.Features;
using Elsa.Features.Extensions;
using Elsa.Features.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Elsa.Extensions;

/// <summary>
/// Provides extension methods to <see cref="IServiceCollection"/>. 
/// </summary>
public static class DependencyInjectionExtensions
{
    /// <summary>
    /// Creates a new Elsa module and adds the <see cref="ElsaFeature"/> to it.
    /// </summary>
    public static IServiceCollection AddElsa(this IServiceCollection services, Action<IModule>? configure = default)
    {
        var module = services.CreateModule();
        module.Configure<ElsaFeature>();
        configure?.Invoke(module);
        module.Apply();
        return services;
    }
}