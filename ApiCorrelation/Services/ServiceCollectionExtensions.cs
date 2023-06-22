using ApiCorrelation.Configuration;
using ApiCorrelation.Configuration.Interfaces;

namespace ApiCorrelation.Services
{
    public static  class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCorrelationIdManager(this IServiceCollection serviceCollection) =>
            serviceCollection.AddScoped<ICorrelationIdGenerator, CorrelationIdGenerator>(); 
    }
}