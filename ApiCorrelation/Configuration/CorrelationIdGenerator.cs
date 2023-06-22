using ApiCorrelation.Configuration.Interfaces;

namespace ApiCorrelation.Configuration
{
    public class CorrelationIdGenerator : ICorrelationIdGenerator
    {
        public string CorrelationId { get; set; }

        public CorrelationIdGenerator()
        {
            CorrelationId = Guid.NewGuid().ToString();
        }
    }
}