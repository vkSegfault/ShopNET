namespace ShopNET.Contracts.Item;

public record CreateItemRequest(
    string Name,
    string Description,
    List<string> Tags
);