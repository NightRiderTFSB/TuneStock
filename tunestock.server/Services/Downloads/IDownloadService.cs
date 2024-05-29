using tunestock.core.entities;
using tunestock.core.http;

namespace tunestock.server.Services.Downloads;

public interface IDownloadService {
    
    Task<bool> UserDownloadExists(int ID);

    Task<List<UserDownload>> GetAllAsync(int userID_FK);

    Task<UserDownload> SaveAsync(UserDownload userDownload);

    Task<UserDownload> GetByID(int ID);

    Task<bool> IfExistsByUserID_FK(int userID_FK);
    
}