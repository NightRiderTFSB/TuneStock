//Importamos la entidad correspondiente

using tunestock.core.entities;

namespace tunestock.api.dto;

public class UserDto : DtoBase
{
    public UserDto()
    {
    }

    public UserDto(User user)
    {
        ID = user.ID;
        Username = user.Username;
        Email = user.Email;
        Password = user.Password;
    }

    public string? Username { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
}