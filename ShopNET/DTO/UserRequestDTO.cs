using ShopNET.Models;

namespace ShopNET.DTO;

public class UserRequestDTO
{
    // using `internal set` will block setters executed from Swagger UI and block show example body in Swagger UI because Swashbuckle package is external
    public string Name { get; internal set; } = string.Empty;

    public string Surname { get; set; } = string.Empty;

    public UserRequestDTO() { }

    public UserRequestDTO(string name, string surname, List<Item> purchasedItems)
    {
        Name = name;
        Surname = surname;
    }
}