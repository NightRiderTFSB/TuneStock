//Importación del DTO correspondiente
using tunestock.core.entities;

//Nombre del paquete al que pertenece la clase
namespace tunestock.api.services.interfaces;

public interface IUserDownloadService {

    Task<bool> UserDownloadExists(int ID);

    Task<List<UserDownload>> GetAllAsync(int userID_FK);

    Task<UserDownload> SaveAsync(UserDownload userDownload);

    Task<UserDownload> GetByID(int ID);

    Task<bool> IfExistsByUserID_FK(int userID_FK);
}