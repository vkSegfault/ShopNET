namespace ShopNET.Contracts.Item;

public record UpsertItemRequest(
    string Name,
    string Description,
    DateTime Added,
    DateTime Modified,
    List<string> Tags
);