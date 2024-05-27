//Imports de los paquetes correspondientes

using tunestock.api.dto;
using tunestock.api.repositories.interfaces;
using tunestock.api.services.interfaces;
using tunestock.core.entities;

//Nombre del paquete al que pertenece la clase
namespace tunestock.api.services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<bool> DeleteAsync(int ID)
    {
        try
        {
            return await _userRepository.DeleteAsync(ID);
        }
        catch (Exception ex)
        {
            Console.WriteLine("HA OCURRIDO UN ERROR - UserService (DelteAsync): " + ex.StackTrace);
            return false;
        }
    }

    public async Task<List<UserDto>> GetAllAsync()
    {
        try
        {
            var users = await _userRepository.GetAllAsync();
            var usersDto = users.Select(l => new UserDto(l)).ToList();
            return usersDto;
        }
        catch (Exception ex)
        {
            Console.WriteLine("HA OCURRIDO UN ERROR - UserService (GetAllAsync): " + ex.StackTrace);
            return null;
        }
    }

    public async Task<UserDto> GetByID(int ID)
    {
        try
        {
            var user = await _userRepository.GetByID(ID);
            if (user == null) throw new Exception("user not found");

            var userDto = new UserDto(user);
            return userDto;
        }
        catch (Exception ex)
        {
            Console.WriteLine("HA OCURRIDO UN ERROR - UserService (GetByID): " + ex.StackTrace);
            return null;
        }
    }

    public async Task<UserDto> SaveAsync(UserDto userDto)
    {
        try
        {
            var user = new User
            {
                Username = userDto.Username,
                Email = userDto.Email,
                Password = userDto.Password,
                CreatedBy = "Starryboy",
                CreatedDate = DateTime.Now,
                UpdatedBy = "Starryboy",
                UpdatedDate = DateTime.Now
            };

            user = await _userRepository.SaveAsync(user);
            userDto.ID = user.ID;

            return userDto;
        }
        catch (Exception ex)
        {
            Console.WriteLine("HA OCURRIDO UN ERROR - UserService (SaveAsync): " + ex.StackTrace);
            return null;
        }
    }

    public async Task<UserDto> UpdateAsync(UserDto userDto)
    {
        try
        {
            var user = await _userRepository.GetByID(userDto.ID);
            if (user == null) throw new Exception("Brand Not Found");

            user.Username = userDto.Username;
            user.Email = userDto.Email;
            user.Password = userDto.Password;
            user.UpdatedBy = "NightRider";
            user.UpdatedDate = DateTime.Now;

            await _userRepository.UpdateAsync(user);
            return userDto;
        }
        catch (Exception ex)
        {
            Console.WriteLine("HA OCURRIDO UN ERROR - UserService (UpdateAsync): " + ex.StackTrace);
            return null;
        }
    }

    public async Task<bool> UserExists(int ID)
    {
        try
        {
            var user = await _userRepository.GetByID(ID);
            return user != null;
        }
        catch (Exception ex)
        {
            Console.WriteLine("HA OCURRIDO UN ERROR - UserService (UserExists):" + ex.StackTrace);
            return false;
        }
    }

    public async Task<bool> Login(UserDto userDto)
    {
        try
        {

            User user = new User();
            user.Email = userDto.Email;
            user.Password = userDto.Password;
            
            
            var access = await _userRepository.Login(user);
            
            if (user == null) throw new Exception("User Not Found");
            
            return access;

        }
        catch (Exception ex)
        {
            Console.WriteLine("HA OCURRIDO UN ERROR - UserService (Login):" + ex.StackTrace);
            return false;
        }
    }

    public async Task<User> GetByEmail(UserDto userDto)
    {
        try
        {
            
            User user = new User();
            user.Email = userDto.Email;
            
            var usr = await _userRepository.GetByEmail(user);

            if (usr == null)
            {
                return null;
            }
            
            
            return usr;
        }
        catch (Exception ex)
        {
            Console.WriteLine("HA OCURRIDO UN ERROR - UserService (GetByEmail):" + ex.StackTrace);
            return null;
        }
    }
}