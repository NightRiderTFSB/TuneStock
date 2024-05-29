//Importamos la entidad correspondiente

using tunestock.core.entities;

//Nombre del paquete al que pertenece la clase
namespace tunestock.api.repositories.interfaces;

public interface ISoundRepository
{
    //Método asíncrono para guardar Sound
    Task<Sound> SaveAsync(Sound sound, int labelId);

    //Método asíncrono para actualizar Sound
    Task<Sound> UpdateAsync(Sound sound);

    //Método asíncrono para retornar todas las Sounds
    Task<List<Sound>> GetAllAsync();

    //Método asíncrono para retornar una Sound por ID
    Task<Sound> GetByID(int ID);

    //Método asíncrono PARA eliminar una Sound
    Task<bool> DeleteAsync(int ID);

    Task<List<Sound>> GetByUser(int ID);
    
    Task<List<Sound>> GetBySoundIds(List<int> soundIds); 
}