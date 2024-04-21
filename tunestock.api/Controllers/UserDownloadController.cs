//Importamos la arquitectura MVC de dotNET
using Microsoft.AspNetCore.Mvc;
using FluentValidation;

//Importamos nuestras entidades, dtos y servicios
using tunestock.core.entities;
using tunestock.core.http;
using tunestock.api.dto;
using tunestock.api.services.interfaces;

//Nombre del paquete al que pertenece la clase
namespace tunestock.api.controllers;

[ApiController] //Establece que la clase sera un controller
[Route("api/[controller]")] //Establece la ruta del controller

public class UserDownloadController : ControllerBase {

    private readonly IUserDownloadService _userDownloadService;
    private readonly IValidator<InputUserDownloadDto> _validator;

    public UserDownloadController(IUserDownloadService userDownloadService, IValidator<InputUserDownloadDto> validator){
        _userDownloadService = userDownloadService;
        _validator = validator;
    }

    //END POINTS
    [HttpGet]
    public async Task<ActionResult<Response<List<UserDownload>>>> GetAll([FromQuery] int userID_FK){

        var response = new Response<List<UserDownload>>();

        try{
            if(!await _userDownloadService.IfExistsByUserID_FK(userID_FK)){
                response.Errors.Add("User not exists");
                return NotFound(response);
            }

            response.Data = await _userDownloadService.GetAllAsync(userID_FK);
            return Ok(response);

        }catch(Exception ex){
            Console.WriteLine("HA OCURRIDO UN ERROR - UserDownloadController (GetAll): " + ex.Message);
            response.Errors.Add("HA OCURRIDO UN ERROR - UserDownloadController (GetAll)");
            return StatusCode(500, response);
        }

    }

    [HttpPost]
    public async Task<ActionResult<Response<UserDownload>>> Post([FromBody] InputUserDownloadDto inputUserDownloadDto){
        
        var response = new Response<UserDownload>();

        try{
            var validationResult = await _validator.ValidateAsync(inputUserDownloadDto);

            if(!validationResult.IsValid){
                response.Errors.AddRange(validationResult.Errors.Select(error => error.ErrorMessage));
                return BadRequest(response);
            }


            UserDownload userDownload = new UserDownload(){
                SoundID_FK = inputUserDownloadDto.SoundID_FK,
                UserID_FK = inputUserDownloadDto.UserID_FK,
                DownloadedDate = inputUserDownloadDto.DownloadedDate
            };

            response.Data = await _userDownloadService.SaveAsync(userDownload);
            return Created("/api/[controller]/{response.Data.ID}", response);

        }catch(Exception ex){
            Console.WriteLine("HA OCURRIDO UN ERROR - UserDownloadController (Post): " + ex.Message);
            response.Errors.Add("HA OCURRIDO UN ERROR - UserDownloadController (Post)");
            return StatusCode(500, response);

        }
    }

    [HttpGet]
    [Route("{ID:int}")]
    public async Task<ActionResult<Response<UserDownload>>> GetByID(int ID){

        var response = new Response<UserDownload>();

        try{
            if(!await _userDownloadService.UserDownloadExists(ID)){
                response.Errors.Add("User Download Not Found");
                return NotFound(response);
            }

            response.Data = await _userDownloadService.GetByID(ID);
            return Ok(response);

        }catch(Exception ex){
            Console.WriteLine("HA OCURRIDO UN ERROR - UserDownloadController (GetByID): " + ex.Message);
            response.Errors.Add("HA OCURRIDO UN ERROR - UserDownloadController (GetByID)");
            return StatusCode(500, response);

        }
    }


}