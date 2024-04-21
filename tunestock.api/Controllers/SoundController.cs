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
public class SoundController : ControllerBase{

    private readonly ISoundService _soundService; //Establecemos nuestras dependencias
    private readonly IValidator<InputSoundDto> _validator;

    public SoundController(ISoundService soundService, IValidator<InputSoundDto> validator){
        _soundService = soundService; //Inyectamos la dependencia
        _validator = validator;
    }

    //END POINTS
    [HttpGet]
    public async Task<ActionResult<Response<List<SoundDto>>>> GetAll(){

        var response = new Response<List<SoundDto>>();

        try{
            response.Data = await _soundService.GetAllAsync();
            return Ok(response);

        }catch(Exception ex){
            Console.WriteLine("HA OCURRIDO UN ERROR - SoundController (GetAll): " + ex.Message);
            response.Errors.Add("HA OCURRIDO UN ERROR - SoundController (GetAll)");
            return StatusCode(500, response);
        }

    }

    [HttpPost]
    public async Task<ActionResult<Response<SoundDto>>> Post([FromBody] InputSoundDto inputSoundDto, [FromQuery] int labelId){
        
        var response = new Response<SoundDto>();
        

        try{
            var validationResult = await _validator.ValidateAsync(inputSoundDto);

            if(!validationResult.IsValid){
                response.Errors.AddRange(validationResult.Errors.Select(error => error.ErrorMessage));
                return BadRequest(response);
            }
    
            SoundDto soundDto = new SoundDto(){
                UserID = inputSoundDto.UserID,
                SoundName = inputSoundDto.SoundName,
                File = inputSoundDto.File,
                IsPremiun = inputSoundDto.IsPremiun,
                Price = inputSoundDto.Price
            };

            response.Data = await _soundService.SaveAsync(soundDto, labelId);

            return Created("/api/[controller]/{response.Data.ID}", response);
            

        }catch(Exception ex){
            Console.WriteLine("HA OCURRIDO UN ERROR - SoundController (Post): " + ex.Message);
            response.Errors.Add("HA OCURRIDO UN ERROR - SoundController (Post)");
            return StatusCode(500, response);

        }
    }

    [HttpGet]
    [Route("{ID:int}")]
    public async Task<ActionResult<Response<SoundDto>>> GetByID(int ID){

        var response = new Response<SoundDto>();

        try{
            if(!await _soundService.SoundExists(ID)){
                response.Errors.Add("Sound Not Found");
                return NotFound(response);
            }

            response.Data = await _soundService.GetByID(ID);
            return Ok(response);

        }catch(Exception ex){
            Console.WriteLine("HA OCURRIDO UN ERROR - SoundController (GetByID): " + ex.Message);
            response.Errors.Add("HA OCURRIDO UN ERROR - SoundController (GetByID)");
            return StatusCode(500, response);

        }
    }

    [HttpPut]
    [Route("{ID:int}")]
    public async Task<ActionResult<Response<Sound>>> Update([FromBody] InputSoundDto inputSoundDto, int ID){
        
        var response = new Response<SoundDto>();

        try{

            SoundDto soundDto = new SoundDto(){
                ID = ID,
                UserID = inputSoundDto.UserID,
                SoundName = inputSoundDto.SoundName,
                File = inputSoundDto.File,
                IsPremiun = inputSoundDto.IsPremiun,
                Price = inputSoundDto.Price
            };

            if(!await _soundService.SoundExists(soundDto.ID)){
                response.Errors.Add("Sound Not Found");
                return NotFound(response);
            }

            response.Data = await _soundService.UpdateAsync(soundDto);
            return Ok(response);

        }catch(Exception ex){
            Console.WriteLine("HA OCURRIDO UN ERROR - SoundController (GetByID): " + ex.Message);
            response.Errors.Add("HA OCURRIDO UN ERROR - SoundController (GetByID)");
            return StatusCode(500, response);

        }

    }

    [HttpDelete]
    [Route("{ID:int}")]
    public async Task<ActionResult<Response<bool>>> DeleteAsync(int ID){

        var response = new Response<bool>();

        try{
            var sound = await _soundService.DeleteAsync(ID);
            
            response.Data = sound;

            if(sound == null){
                response.Errors.Add("Sound Not Found");
                return NotFound(response);
            }

            response.Message = ("Sound correctly deleted");
            return Ok(response);

        }catch(Exception ex){
            Console.WriteLine("HA OCURRIDO UN ERROR - SoundController (GetByID): " + ex.Message);
            response.Errors.Add("HA OCURRIDO UN ERROR - SoundController (GetByID)");
            return StatusCode(500, response);

        }

    }

}