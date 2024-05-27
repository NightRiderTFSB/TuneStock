//Importación del DTO correspondiente

using tunestock.api.dto;
using tunestock.core.entities;

//Nombre del paquete al que pertenece la clase
namespace tunestock.api.services.interfaces;

public interface IUserService
{
    Task<bool> UserExists(int ID);

    Task<List<UserDto>> GetAllAsync();

    Task<UserDto> SaveAsync(UserDto userDto);

    Task<UserDto> GetByID(int ID);

    Task<UserDto> UpdateAsync(UserDto userDto);

    Task<bool> DeleteAsync(int ID);

    Task<bool> Login(UserDto userDto);
    
    Task<User> GetByEmail(UserDto userDto);
}