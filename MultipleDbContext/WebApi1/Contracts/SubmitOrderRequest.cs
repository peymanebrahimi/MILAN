namespace WebApi1.Contracts;

public class SubmitOrderRequest
{
    public List<Guid> ProductIds { get; set; } = new();
}
