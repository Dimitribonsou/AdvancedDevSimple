
    namespace AdvancedDevSample.API.Contracts;

    public record CreateOrderRequest(string CustomerName, decimal TotalAmount);

    public record UpdateOrderRequest(string CustomerName, decimal TotalAmount);

    public record OrderResponse(Guid Id, string CustomerName, decimal TotalAmount, DateTime CreatedAt);

