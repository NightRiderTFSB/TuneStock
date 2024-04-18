//Importamos la entidad correspondiente
using tunestock.core.entities;

//Nombre del paquete al que pertenece la clase
namespace tunestock.api.repositories.interfaces;

public interface ILabelRepository{

    //Método asíncrono para guardar label
    Task<Label> SaveAsync(Label label);

    //Método asíncrono para actualizar label
    Task<Label> UpdateAsync(Label label);

    //Método asíncrono para retornar todas las labels
    Task<List<Label>> GetAllAsync();

    //Método asíncrono para retornar una label por ID
    Task<Label> GetByID(int ID);

    //Método asíncrono PARA eliminar una label
    Task<bool> DeleteAsync(int ID);

}