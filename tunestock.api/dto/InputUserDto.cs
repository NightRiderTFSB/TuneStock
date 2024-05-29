//Importamos la entidad correspondiente

using tunestock.core.entities;

namespace tunestock.api.dto;

public class InputUserDto
{
    public InputUserDto()
    {
    }

    public InputUserDto(User user)
    {
        Username = user.Username;
        Email = user.Email;
        Password = user.Password;
        Admin = user.Admin;
    }

    public string? Username { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }

    public bool Admin { get; set; }
}