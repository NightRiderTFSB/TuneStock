using tunestock.api.dto;
using tunestock.core.http;
using tunestock.core.entities;

namespace tunestock.server.Services.User;

public interface IUserService
{
    Task<Response<List<UserDto>>> GetAllAsync();
    Task<Response<UserDto>> GeyByID(int id);
    Task<Response<UserDto>> SaveAsync(UserDto userDto);
    Task<Response<UserDto>> UpdateAsync(UserDto userDto);
    Task<Response<bool>> DeleteAsync(int id);

    Task<Response<bool>> Login(UserDto userDto);

    Task<Response<core.entities.User>> GetByEmail(UserDto userDto);

}