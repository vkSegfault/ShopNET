namespace ShopNET.Contracts.Item;

public record ItemReponse(
    Guid Id,
    string Name,
    string Description,
    DateTime AddedDateTime,
    DateTime LastModifiedDateTime,
    List<string> Tags
);