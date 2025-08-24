namespace AzureTaskTracker.Contracts.Tasks;

public record TaskResponse(Guid Id, string Title, string? Description);
