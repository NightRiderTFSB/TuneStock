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
public class LabelController : ControllerBase
{
    private readonly ILabelService _labelService; //Establecemos nuestras dependencias
    private readonly IValidator<InputLabelDto> _validator;

    public LabelController(ILabelService labelService, IValidator<InputLabelDto> validator)
    {
        _labelService = labelService; //Inyectamos la dependencia
        _validator = validator;
    }

    //END POINTS
    [HttpGet]
    public async Task<ActionResult<Response<List<LabelDto>>>> GetAll()
    {
        var response = new Response<List<LabelDto>>();

        try
        {
            response.Data = await _labelService.GetAllAsync();
            return Ok(response);
        }
        catch (Exception ex)
        {
            Console.WriteLine("HA OCURRIDO UN ERROR - LabelController (GetAll): " + ex.Message);
            response.Errors.Add("HA OCURRIDO UN ERROR - LabelController (GetAll)");
            return StatusCode(500, response);
        }
    }

    [HttpPost]
    public async Task<ActionResult<Response<LabelDto>>> Post([FromBody] InputLabelDto inputLabelDto)
    {
        var response = new Response<LabelDto>();

        try
        {
            var validationResult = await _validator.ValidateAsync(inputLabelDto);

            if (!validationResult.IsValid)
            {
                response.Errors.AddRange(validationResult.Errors.Select(error => error.ErrorMessage));
                return BadRequest(response);
            }

            var labelDto = new LabelDto
            {
                Labelname = inputLabelDto.Labelname,
                Description = inputLabelDto.Description
            };

            response.Data = await _labelService.SaveAsync(labelDto);
            return Created("/api/[controller]/{response.Data.ID}", response);
        }
        catch (Exception ex)
        {
            Console.WriteLine("HA OCURRIDO UN ERROR - LabelController (Post): " + ex.Message);
            response.Errors.Add("HA OCURRIDO UN ERROR - LabelController (Post)");
            return StatusCode(500, response);
        }
    }

    [HttpGet]
    [Route("{ID:int}")]
    public async Task<ActionResult<Response<LabelDto>>> GetByID(int ID)
    {
        var response = new Response<LabelDto>();

        try
        {
            if (!await _labelService.LabelExists(ID))
            {
                response.Errors.Add("Label Not Found");
                return NotFound(response);
            }

            response.Data = await _labelService.GetByID(ID);
            return Ok(response);
        }
        catch (Exception ex)
        {
            Console.WriteLine("HA OCURRIDO UN ERROR - LabelController (GetByID): " + ex.Message);
            response.Errors.Add("HA OCURRIDO UN ERROR - LabelController (GetByID)");
            return StatusCode(500, response);
        }
    }

    [HttpPut]
    [Route("{ID:int}")]
    public async Task<ActionResult<Response<Label>>> Update([FromBody] InputLabelDto inputLabelDto, int ID)
    {
        var response = new Response<LabelDto>();

        try
        {
            var labelDto = new LabelDto
            {
                ID = ID,
                Labelname = inputLabelDto.Labelname,
                Description = inputLabelDto.Description
            };

            if (!await _labelService.LabelExists(labelDto.ID))
            {
                response.Errors.Add("Label Not Found");
                return NotFound(response);
            }

            response.Data = await _labelService.UpdateAsync(labelDto);
            return Ok(response);
        }
        catch (Exception ex)
        {
            Console.WriteLine("HA OCURRIDO UN ERROR - LabelController (GetByID): " + ex.Message);
            response.Errors.Add("HA OCURRIDO UN ERROR - LabelController (GetByID)");
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
            var label = await _labelService.DeleteAsync(ID);

            response.Data = label;

            if (label == null)
            {
                response.Errors.Add("Label Not Found");
                return NotFound(response);
            }

            response.Message = "Label correctly deleted";
            return Ok(response);
        }
        catch (Exception ex)
        {
            Console.WriteLine("HA OCURRIDO UN ERROR - LabelController (GetByID): " + ex.Message);
            response.Errors.Add("HA OCURRIDO UN ERROR - LabelController (GetByID)");
            return StatusCode(500, response);
        }
    }
}