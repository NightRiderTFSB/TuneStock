//Importamos la arquitectura MVC de dotNET

using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using tunestock.api.dto;
using tunestock.api.services.interfaces;
using tunestock.core.entities;
using tunestock.core.http;
//Importamos nuestras entidades, dtos y servicios

//Nombre del paquete al que pertenece la clase
namespace tunestock.api.controllers;

[ApiController] //Establece que la clase sera un controller
[Route("api/[controller]")] //Establece la ruta del controller
public class UserController : ControllerBase
{
    private readonly IUserService _userService; //Establecemos nuestras dependencias
    private readonly IValidator<InputUserDto> _validator;


    public UserController(IUserService userService, IValidator<InputUserDto> validator)
    {
        _userService = userService; //Inyectamos la dependencia
        _validator = validator;
    }

    //END POINTS
    [HttpGet]
    public async Task<ActionResult<Response<List<UserDto>>>> GetAll()
    {
        var response = new Response<List<UserDto>>();

        try
        {
            response.Data = await _userService.GetAllAsync();
            return Ok(response);
        }
        catch (Exception ex)
        {
            Console.WriteLine("HA OCURRIDO UN ERROR - UserController (GetAll): " + ex.Message);
            response.Errors.Add("HA OCURRIDO UN ERROR - UserController (GetAll)");
            return StatusCode(500, response);
        }
    }

    [HttpPost]
    public async Task<ActionResult<Response<UserDto>>> Post([FromBody] InputUserDto inputUserDto)
    {
        var response = new Response<UserDto>();

        try
        {
            var validationResult = await _validator.ValidateAsync(inputUserDto);

            if (!validationResult.IsValid)
            {
                response.Errors.AddRange(validationResult.Errors.Select(error => error.ErrorMessage));
                return BadRequest(response);
            }

            var userDto = new UserDto
            {
                Username = inputUserDto.Username,
                Email = inputUserDto.Email,
                Password = inputUserDto.Password,
                Admin = inputUserDto.Admin
            };

            response.Data = await _userService.SaveAsync(userDto);
            return Created("/api/[controller]/{response.Data.ID}", response);
        }
        catch (Exception ex)
        {
            Console.WriteLine("HA OCURRIDO UN ERROR - UserController (Post): " + ex.Message);
            response.Errors.Add("HA OCURRIDO UN ERROR - UserController (Post)");
            return StatusCode(500, response);
        }
    }

    [HttpGet]
    [Route("{ID:int}")]
    public async Task<ActionResult<Response<UserDto>>> GetByID(int ID)
    {
        var response = new Response<UserDto>();

        try
        {
            if (!await _userService.UserExists(ID))
            {
                response.Errors.Add("Label Not Found");
                return NotFound(response);
            }

            response.Data = await _userService.GetByID(ID);
            return Ok(response);
        }
        catch (Exception ex)
        {
            Console.WriteLine("HA OCURRIDO UN ERROR - UserController (GetByID): " + ex.Message);
            response.Errors.Add("HA OCURRIDO UN ERROR - UserController (GetByID)");
            return StatusCode(500, response);
        }
    }

    [HttpPut]
    [Route("{ID:int}")]
    public async Task<ActionResult<Response<Label>>> Update([FromBody] InputUserDto inputUserDto, int ID)
    {
        var response = new Response<UserDto>();

        try
        {
            var userDto = new UserDto
            {
                ID = ID,
                Username = inputUserDto.Username,
                Email = inputUserDto.Email,
                Password = inputUserDto.Password,
                Admin = inputUserDto.Admin
            };

            if (!await _userService.UserExists(userDto.ID))
            {
                response.Errors.Add("Label Not Found");
                return NotFound(response);
            }

            response.Data = await _userService.UpdateAsync(userDto);
            return Ok(response);
        }
        catch (Exception ex)
        {
            Console.WriteLine("HA OCURRIDO UN ERROR - UserController (Update): " + ex.Message);
            response.Errors.Add("HA OCURRIDO UN ERROR - UserController (Update)");
            return StatusCode(500, response);
        }
    }

    [HttpDelete]
    [Route("{ID:int}")]
    public async Task<ActionResult<Response<bool>>> DeleteAsync(int ID)
    {
        var response = new Response<bool>();

        try
        {
            var label = await _userService.DeleteAsync(ID);

            response.Data = label;

            if (label == null)
            {
                response.Errors.Add("User Not Found");
                return NotFound(response);
            }

            response.Message = "User correctly deleted";
            return Ok(response);
        }
        catch (Exception ex)
        {
            Console.WriteLine("HA OCURRIDO UN ERROR - UserController (Delete): " + ex.Message);
            response.Errors.Add("HA OCURRIDO UN ERROR - UserController (Delete)");
            return StatusCode(500, response);
        }
    }
    
    [HttpPost]
    [Route("login")]
    public async Task<ActionResult<Response<bool>>> Login([FromBody] UserDto userDto)
    {
        var response = new Response<bool>();

        try
        {
            bool loginSuccessful = await _userService.Login(userDto);

            if (loginSuccessful)
            {
                response.Data = true;
                response.Message = "Login successful";
                return Ok(response);
            }
            else
            {
                response.Data = false;
                response.Errors.Add("Invalid email or password");
                return Unauthorized(response); // 401 Unauthorized
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("HA OCURRIDO UN ERROR - UserController (Login): " + ex.Message);
            response.Errors.Add("HA OCURRIDO UN ERROR - UserController (Login)");
            return StatusCode(500, response);
        }
    }
    
    
    [HttpGet]
    [Route("byemail/{email}")]
    public async Task<ActionResult<Response<User>>> GetByEmail(string email)
    {
        var response = new Response<User>();

        try
        {
            UserDto usrDto = new UserDto();
            usrDto.Email = email;
            var user = await _userService.GetByEmail(usrDto);
            
            Console.WriteLine("USR: " + user.ID);
            Console.WriteLine("Email: " + user.Email);
            Console.WriteLine("Pass: " + user.Password);
            Console.WriteLine("Admin: " + user.Admin);
            if (user == null)
            {
                response.Errors.Add("User not found.");
                return NotFound(response);
            }

            response.Data = user;
            return Ok(response);
        }
        catch (Exception ex)
        {
            Console.WriteLine("HA OCURRIDO UN ERROR - UserController (GetByEmail): " + ex.Message);
            response.Errors.Add("HA OCURRIDO UN ERROR - UserController (GetByEmail)");
            return StatusCode(500, response);
        }
    }

    
}