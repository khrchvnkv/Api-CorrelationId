namespace ApiCorrelation.Configuration.Interfaces
{
    public interface ICorrelationIdGenerator
    {
        string CorrelationId { get; set; }
    }
}