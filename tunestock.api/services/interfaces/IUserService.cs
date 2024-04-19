//Importación del DTO correspondiente
using tunestock.api.dto;

//Nombre del paquete al que pertenece la clase
namespace tunestock.api.services.interfaces;

public interface IUserService {

    Task<bool> UserExists(int ID);

    Task<List<UserDto>> GetAllAsync();

    Task<UserDto> SaveAsync(UserDto user);

    Task<UserDto> GetByID(int ID);

    Task<UserDto> UpdateAsync(UserDto user);

    Task<bool> DeleteAsync(int ID);

}