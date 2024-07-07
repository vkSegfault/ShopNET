namespace ShopNET.Contracts.Item;

public record ItemResponse(
    string info,
Guid Id,
    string Name,
    string Description,
    DateTime AddedDateTime,
    DateTime LastModifiedDateTime,
    List<string> Tags
);