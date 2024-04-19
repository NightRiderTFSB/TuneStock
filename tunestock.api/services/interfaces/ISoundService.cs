//Importación del DTO correspondiente
using tunestock.api.dto;

//Nombre del paquete al que pertenece la clase
namespace tunestock.api.services.interfaces;

public interface ISoundService {

    Task<bool> SoundExists(int ID);

    Task<List<SoundDto>> GetAllAsync();

    Task<SoundDto> SaveAsync(SoundDto sound, int labelId);

    Task<SoundDto> GetByID(int ID);

    Task<SoundDto> UpdateAsync(SoundDto sound);

    Task<bool> DeleteAsync(int ID);

}