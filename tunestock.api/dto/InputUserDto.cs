//Importamos la entidad correspondiente
using tunestock.core.entities;

namespace tunestock.api.dto;

public class InputUserDto {

    public string? Username { get; set; }
    public string? Email { get; set; }
    public string? Password {get; set; }

    public InputUserDto(){

    }

    public InputUserDto(User user){
        Username = user.Username;
        Email = user.Email;
        Password = user.Password;
    }

}