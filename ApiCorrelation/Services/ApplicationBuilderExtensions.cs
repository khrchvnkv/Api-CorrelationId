using ApiCorrelation.Helpers;

namespace ApiCorrelation.Services
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder AddCorrelationIdMiddleware(this IApplicationBuilder applicationBuilder) =>
            applicationBuilder.UseMiddleware<CorrelationIdMiddleware>();
    }
}