//Imports de los paquetes correspondientes

using tunestock.api.dto;
using tunestock.api.repositories.interfaces;
using tunestock.api.services.interfaces;
using tunestock.core.entities;

//Nombre del paquete al que pertenece la clase
namespace tunestock.api.services;

public class LabelService : ILabelService
{
    private readonly ILabelRepository _labelRepository;

    public LabelService(ILabelRepository labelRepository)
    {
        _labelRepository = labelRepository;
    }


    public async Task<bool> DeleteAsync(int ID)
    {
        try
        {
            return await _labelRepository.DeleteAsync(ID);
        }
        catch (Exception ex)
        {
            Console.WriteLine("HA OCURRIDO UN ERROR - LabelService (DeleteAsync):" + ex.StackTrace);
            return false;
        }
    }

    public async Task<List<LabelDto>> GetAllAsync()
    {
        try
        {
            var labels = await _labelRepository.GetAllAsync();
            var labelsDto = labels.Select(l => new LabelDto(l)).ToList();
            return labelsDto;
        }
        catch (Exception ex)
        {
            Console.WriteLine("HA OCURRIDO UN ERROR - LabelService (GetAllAsync):" + ex.StackTrace);
            return null;
        }
    }

    public async Task<LabelDto> GetByID(int ID)
    {
        try
        {
            var label = await _labelRepository.GetByID(ID);
            if (label == null) throw new Exception("Label not found");

            var labelDto = new LabelDto(label);
            return labelDto;
        }
        catch (Exception ex)
        {
            Console.WriteLine("HA OCURRIDO UN ERROR - LabelService (GetByID):" + ex.StackTrace);
            return null;
        }
    }

    public async Task<bool> LabelExists(int ID)
    {
        try
        {
            var label = await _labelRepository.GetByID(ID);
            return label != null;
        }
        catch (Exception ex)
        {
            Console.WriteLine("HA OCURRIDO UN ERROR - LabelService (LabelExists):" + ex.StackTrace);
            return false;
        }
    }

    public async Task<LabelDto> SaveAsync(LabelDto labelDto)
    {
        try
        {
            var label = new Label
            {
                Labelname = labelDto.Labelname,
                Description = labelDto.Description,
                CreatedBy = "Starryboy",
                CreatedDate = DateTime.Now,
                UpdatedBy = "Starryboy",
                UpdatedDate = DateTime.Now
            };

            label = await _labelRepository.SaveAsync(label);
            labelDto.ID = label.ID;

            return labelDto;
        }
        catch (Exception ex)
        {
            Console.WriteLine("HA OCURRIDO UN ERROR - LabelService (SaveAsync):" + ex.StackTrace);
            return null;
        }
    }

    public async Task<LabelDto> UpdateAsync(LabelDto labelDto)
    {
        try
        {
            var label = await _labelRepository.GetByID(labelDto.ID);
            if (label == null) throw new Exception("Brand Not Found");

            label.Labelname = labelDto.Labelname;
            label.Description = labelDto.Description;
            label.UpdatedBy = "NightRider";
            label.UpdatedDate = DateTime.Now;

            await _labelRepository.UpdateAsync(label);
            return labelDto;
        }
        catch (Exception ex)
        {
            Console.WriteLine("HA OCURRIDO UN ERROR - LabelService (UpdateAsync):" + ex.StackTrace);
            return null;
        }
    }
}