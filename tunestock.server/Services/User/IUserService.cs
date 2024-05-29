using tunestock.api.dto;
using tunestock.core.http;

namespace tunestock.api.services.interfaces
{
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
}