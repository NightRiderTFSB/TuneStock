//Imports de los paquetes correspondientes

using tunestock.api.dto;
using tunestock.api.repositories.interfaces;
using tunestock.api.services.interfaces;
using tunestock.core.entities;

//Nombre del paquete al que pertenece la clase
namespace tunestock.api.services;

public class SoundService : ISoundService
{
    private readonly ISoundRepository _soundRepository;

    public SoundService(ISoundRepository soundRepository)
    {
        _soundRepository = soundRepository;
    }


    public async Task<bool> DeleteAsync(int ID)
    {
        try
        {
            return await _soundRepository.DeleteAsync(ID);
        }
        catch (Exception ex)
        {
            Console.WriteLine("HA OCURRIDO UN ERROR - SoundService (DeleteAsync):" + ex.StackTrace);
            return false;
        }
    }

    public async Task<List<SoundDto>> GetByUser(int ID) {
        try
        {
            var sounds = await _soundRepository.GetByUser(ID);
            var soundsDto = sounds.Select(l => new SoundDto(l)).ToList();
            return soundsDto;
        }
        catch (Exception ex)
        {
            Console.WriteLine("HA OCURRIDO UN ERROR - SoundService (GeyByUser):" + ex.StackTrace);
            return null;
        }
    }

    public async Task<List<SoundDto>> GetAllAsync()
    {
        try
        {
            var sounds = await _soundRepository.GetAllAsync();
            var soundsDto = sounds.Select(l => new SoundDto(l)).ToList();
            return soundsDto;
        }
        catch (Exception ex)
        {
            Console.WriteLine("HA OCURRIDO UN ERROR - SoundService (GetAllAsync):" + ex.StackTrace);
            return null;
        }
    }

    public async Task<SoundDto> GetByID(int ID)
    {
        try
        {
            var sound = await _soundRepository.GetByID(ID);
            if (sound == null) throw new Exception("Sound not found");

            var soundDto = new SoundDto(sound);
            return soundDto;
        }
        catch (Exception ex)
        {
            Console.WriteLine("HA OCURRIDO UN ERROR - SoundService (GetByID):" + ex.StackTrace);
            return null;
        }
    }

    public async Task<bool> SoundExists(int ID)
    {
        try
        {
            var sound = await _soundRepository.GetByID(ID);
            return sound != null;
        }
        catch (Exception ex)
        {
            Console.WriteLine("HA OCURRIDO UN ERROR - SoundService (SoundExists):" + ex.StackTrace);
            return false;
        }
    }

    public async Task<SoundDto> SaveAsync(SoundDto soundDto, int labelId)
    {
        try
        {
            var sound = new Sound
            {
                UserID = soundDto.UserID,
                SoundName = soundDto.SoundName,
                File = soundDto.File,
                IsPremiun = soundDto.IsPremiun,
                Price = soundDto.Price,
                IsDeleted = false,
                CreatedBy = "Starryboy",
                CreatedDate = DateTime.Now,
                UpdatedBy = "Starryboy",
                UpdatedDate = DateTime.Now
            };

            sound = await _soundRepository.SaveAsync(sound, labelId);
            soundDto.ID = sound.ID;

            return soundDto;
        }
        catch (Exception ex)
        {
            Console.WriteLine("HA OCURRIDO UN ERROR - SoundService (SaveAsync):" + ex.StackTrace);
            return null;
        }
    }

    public async Task<SoundDto> UpdateAsync(SoundDto soundDto)
    {
        try
        {
            var sound = await _soundRepository.GetByID(soundDto.ID);
            if (sound == null) throw new Exception("Brand Not Found");

            sound.UserID = soundDto.UserID;
            sound.SoundName = soundDto.SoundName;
            sound.File = soundDto.File;
            sound.IsPremiun = soundDto.IsPremiun;
            sound.Price = soundDto.Price;
            sound.UpdatedBy = "Starryboy";
            sound.UpdatedDate = DateTime.Now;


            sound.UpdatedBy = "NightRider";
            sound.UpdatedDate = DateTime.Now;

            await _soundRepository.UpdateAsync(sound);
            return soundDto;
        }
        catch (Exception ex)
        {
            Console.WriteLine("HA OCURRIDO UN ERROR - SoundService (UpdateAsync):" + ex.StackTrace);
            return null;
        }
    }
}