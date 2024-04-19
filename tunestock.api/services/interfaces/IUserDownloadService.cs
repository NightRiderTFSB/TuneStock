//Importación del DTO correspondiente
using tunestock.core.entities;

//Nombre del paquete al que pertenece la clase
namespace tunestock.api.services.interfaces;

public interface IUserDownloadService {

    Task<bool> UserExists(int ID);

    Task<List<UserDownload>> GetAllAsync();

    Task<UserDownload> SaveAsync(UserDownload userDownload);

    Task<UserDownload> GetByID(int ID);


}