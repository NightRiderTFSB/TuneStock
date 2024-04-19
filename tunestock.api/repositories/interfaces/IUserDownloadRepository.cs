//Importamos la entidad correspondiente
using tunestock.core.entities;

//Nombre del paquete al que pertenece la clase
namespace tunestock.api.repositories.interfaces;

public interface IUserDownloadRepository{

    //Método asíncrono para guardar user download
    Task<UserDownload> SaveAsync(UserDownload userDownload);

    //Método asíncrono para retornar todas las user downloads
    Task<List<UserDownload>> GetAllAsync();

    //Método asíncrono para retornar una user download por ID
    Task<UserDownload> GetByID(int ID);

}