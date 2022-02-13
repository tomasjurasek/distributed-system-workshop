using System.ComponentModel.DataAnnotations;

namespace Writer.API.Requests;

public record CreatePaymentRequest
{
    [Required]
    public Guid OrderId { get; init; }

    [Required]
    [Range(0, double.MaxValue)]
    public decimal Amount { get; init; }

    [Required]
    public string Currency { get; init; }
}

