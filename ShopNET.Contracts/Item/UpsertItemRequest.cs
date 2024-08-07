namespace ShopNET.Contracts.Item;

public record UpsertItemRequest(
    string Name,
    string Description,
    decimal Price,
    DateTime Added,
    DateTime Modified,
    List<string> Tags
);