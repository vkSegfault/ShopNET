namespace ShopNET.Contracts.Item;

public record ItemResponse(
    Guid Id,
    string Name,
    string Description,
    DateTime AddedDateTime,
    DateTime LastModifiedDateTime,
    List<string> Tags
);