using ApiCorrelation.Configuration.Interfaces;

namespace ApiCorrelation.Helpers
{
    public class CorrelationIdMiddleware
    {
        private const string CorrelationIdHeader = "X-Correlation-Id";
        
        private readonly RequestDelegate _next;

        public CorrelationIdMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, ICorrelationIdGenerator correlationIdGenerator)
        {
            var correlationId = GetCorrelationIdTrace(context, correlationIdGenerator);
            AddCorrelationIdToResponse(context,  correlationId);

            await _next(context);
        }
        private static string GetCorrelationIdTrace(in HttpContext context, in ICorrelationIdGenerator correlationIdGenerator)
        {
            if (context.Request.Headers.TryGetValue(CorrelationIdHeader, out var correlationId))
            {
                correlationIdGenerator.CorrelationId = correlationId;
                return correlationId;
            }

            return correlationIdGenerator.CorrelationId;
        }
        private static void AddCorrelationIdToResponse(HttpContext context, string correlationId)
        {
            context.Response.OnStarting(() =>
            {
                context.Response.Headers.Add(CorrelationIdHeader, new [] {correlationId});
                return Task.CompletedTask; 
            });
        }
    }
}