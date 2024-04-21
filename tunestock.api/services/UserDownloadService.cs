//Imports de los paquetes correspondientes
using tunestock.api.dto;
using tunestock.api.repositories.interfaces;
using tunestock.api.services.interfaces;
using tunestock.core.entities;

//Nombre del paquete al que pertenece la clase
namespace tunestock.api.services;

public class UserDownloadService : IUserDownloadService{

    private readonly IUserDownloadRepository _userDownloadRepository;

    public UserDownloadService(IUserDownloadRepository userDownloadRepository){
        _userDownloadRepository = userDownloadRepository;
    }

    public async Task<List<UserDownload>> GetAllAsync(int userID_FK){
        try{
            var userDownloads = await _userDownloadRepository.GetAllAsync(userID_FK);
            var userDownloadsDto = userDownloads.Select(l => new UserDownload(l)).ToList();
            return userDownloadsDto;
        }catch(Exception ex){
            Console.WriteLine("HA OCURRIDO UN ERROR - userDownloadService (GetAllAsync):" + ex.StackTrace);
            return null;
        }
    }

    public async Task<UserDownload> GetByID(int ID){
        try{
            var userDownload = await _userDownloadRepository.GetByID(ID);
            if(userDownload == null){
                throw new Exception("userDownload not found");
            }

            return userDownload;
        
        }catch(Exception ex){
            Console.WriteLine("HA OCURRIDO UN ERROR - userDownloadService (GetByID):" + ex.StackTrace);
            return null;
        }
    }

    public async Task<UserDownload> SaveAsync(UserDownload userDownloadx){
        try{
            var userDownload = new UserDownload{
                SoundID_FK = userDownloadx.SoundID_FK,
                UserID_FK = userDownloadx.UserID_FK,
                DownloadedDate = userDownloadx.DownloadedDate
            };

            userDownload = await _userDownloadRepository.SaveAsync(userDownload);
            userDownloadx.ID = userDownloadx.ID;

        return userDownloadx;

        }catch(Exception ex){
            Console.WriteLine("HA OCURRIDO UN ERROR - userDownloadService (SaveAsync):" + ex.StackTrace);
            return null;
        }
    }


    public async Task<bool> IfExistsByUserID_FK(int ID){
        try{
            var downloads = await _userDownloadRepository.IfExistsByUserID_FK(ID);
            return (downloads != null);            

        }catch(Exception ex){
            Console.WriteLine("HA OCURRIDO UN ERROR - userDownloadService (UserExists):" + ex.StackTrace);
            return false;
        }
    }

    public async Task<bool> UserDownloadExists(int ID){
        try{
            var label = await _userDownloadRepository.GetByID(ID);
            return (label != null);            

        }catch(Exception ex){
            Console.WriteLine("HA OCURRIDO UN ERROR - userDownloadService (UserExists):" + ex.StackTrace);
            return false;
        }
    }
}