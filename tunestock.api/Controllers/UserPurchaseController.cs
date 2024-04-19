//Importamos la arquitectura MVC de dotNET
using Microsoft.AspNetCore.Mvc;

//Importamos nuestras entidades, dtos y servicios
using tunestock.core.entities;
using tunestock.core.http;
using tunestock.api.dto;
using tunestock.api.services.interfaces;

//Nombre del paquete al que pertenece la clase
namespace tunestock.api.controllers;

[ApiController] //Establece que la clase sera un controller
[Route("api/[controller]")] //Establece la ruta del controller

public class UserPurchaseController : ControllerBase{

    private readonly IUserPurchaseService _userPurchaseService; //Establecemos nuestras dependencias

    public UserPurchaseController(IUserPurchaseService userPurchaseService){
        _userPurchaseService = userPurchaseService; //Inyectamos la dependencia

    }

    //END POINTS
    [HttpGet]
    public async Task<ActionResult<Response<List<UserPurchaseDto>>>> GetAll(){

        var response = new Response<List<UserPurchaseDto>>();

        try{
            response.Data = await _userPurchaseService.GetAllAsync();
            return Ok(response);

        }catch(Exception ex){
            Console.WriteLine("HA OCURRIDO UN ERROR - UserPurchaseController (GetAll): " + ex.Message);
            response.Errors.Add("HA OCURRIDO UN ERROR - UserPurchaseController (GetAll)");
            return StatusCode(500, response);
        }

    }

    [HttpPost]
    public async Task<ActionResult<Response<UserPurchaseDto>>> Post([FromBody] InputUserPurchaseDto inputUserPurchaseDto){
        
        var response = new Response<UserPurchaseDto>();

        try{
            UserPurchaseDto userPurchaseDto = new UserPurchaseDto(){
                PurchasedDate = inputUserPurchaseDto.PurchasedDate,
                SoundPrice = inputUserPurchaseDto.SoundPrice,
                PaymentStatus = inputUserPurchaseDto.PaymentStatus,
                PaymentMethod = inputUserPurchaseDto.PaymentMethod,
                UserID_FK = inputUserPurchaseDto.UserID_FK,
                SoundID_FK = inputUserPurchaseDto.SoundID_FK
            };

            response.Data = await _userPurchaseService.SaveAsync(userPurchaseDto);
            return Created("/api/[controller]/{response.Data.ID}", response);

        }catch(Exception ex){
            Console.WriteLine("HA OCURRIDO UN ERROR - UserPurchaseController (Post): " + ex.Message);
            response.Errors.Add("HA OCURRIDO UN ERROR - UserPurchaseController (Post)");
            return StatusCode(500, response);

        }
    }

    [HttpGet]
    [Route("{ID:int}")]
    public async Task<ActionResult<Response<UserPurchaseDto>>> GetByID(int ID){

        var response = new Response<UserPurchaseDto>();

        try{
            if(!await _userPurchaseService.UserPurchaseExists(ID)){
                response.Errors.Add("userPurchase Not Found");
                return NotFound(response);
            }

            response.Data = await _userPurchaseService.GetByID(ID);
            return Ok(response);

        }catch(Exception ex){
            Console.WriteLine("HA OCURRIDO UN ERROR - UserPurchaseController (GetByID): " + ex.Message);
            response.Errors.Add("HA OCURRIDO UN ERROR - UserPurchaseController (GetByID)");
            return StatusCode(500, response);

        }
    }


}