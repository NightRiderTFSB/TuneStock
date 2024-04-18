//Importamos la entidad correspondiente
using tunestock.core.entities;

//Nombre del paquete al que pertenece la clase
namespace tunestock.api.repositories.interfaces;

public interface IUserRepository{
    
    //Método asíncrono para guardar user
    Task<User> SaveAsync(User user);

    //Método asíncrono para actualizar user
    Task<User> UpdateAsync(User user);

    //Método asíncrono para retornar todas las users
    Task<List<User>> GetAllAsync();

    //Método asíncrono para retornar una user por ID
    Task<User> GetByID(int ID);

    //Método asíncrono PARA eliminar una user
    Task<bool> DeleteAsync(int ID);

}