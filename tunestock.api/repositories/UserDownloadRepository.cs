//Importamos las entidades, interfaces y el dataaccess
using tunestock.core.entities;
using tunestock.api.repositories.interfaces;
using tunestock.api.dataAccess.interfaces;

//Importamos dapper y dapper.contrib
using Dapper;
using Dapper.Contrib.Extensions;
using System.ComponentModel;

//Nombre del paquete al que pertenecen
namespace tunestock.api.repositories;

public class UserDownloadRepository : IUserDownloadRepository{
    private readonly IDbContext _dbContext;

    public UserDownloadRepository(IDbContext context){
        _dbContext = context;
    }

    public async Task<List<UserDownload>> GetAllAsync(int userID_FK){
        
        try{
            string query = $"SELECT * FROM UserDownloads WHERE UserID_FK = {userID_FK};";
            var userDownloads = await _dbContext.Connection.QueryAsync<UserDownload>(query);
            Console.WriteLine("OBTENIDOS CON EXITO - UserDownloadRepository (GetAllAsync)");
            return userDownloads.ToList();

        }catch(Exception ex){
            Console.WriteLine("HA OCURRIDO UN ERROR - UserDownloadRepository (GetAllAsync)" + ex.StackTrace);
            return null;
        }

    }

    public async Task<UserDownload> GetByID(int ID){
        try{
            var userDownload = await _dbContext.Connection.GetAsync<UserDownload>(ID);

            if(userDownload == null){
                return null;
            }

            Console.WriteLine("OBTENIDO CON EXITO - UserDownloadRepository (GetByID)");

            return userDownload;

        }catch(Exception ex){
            Console.WriteLine("HA OCURRIDO UN ERROR - UserDownloadRepository (GetByID)" + ex.StackTrace);
            return null;
        }
    }

    public async Task<UserDownload> SaveAsync(UserDownload userDownload){
        try{
            userDownload.ID = await _dbContext.Connection.InsertAsync(userDownload);
            Console.WriteLine("GUARDADO CORRECTAMENTE - UserDownloadRepository (SaveAsync)");
            return userDownload;

        }catch(Exception ex){
            Console.WriteLine("HA OCURRIDO UN ERROR - UserDownloadRepository (SaveAsync): " + ex.StackTrace);
            return null;
        }
    }

    public async Task<List<UserDownload>> IfExistsByUserID_FK(int userID_FK){
        
        try{
            string query = $"SELECT * FROM UserDownloads WHERE UserID_FK = {userID_FK};";
            var userDownloads = await _dbContext.Connection.QueryAsync<UserDownload>(query);
            Console.WriteLine("UserID_FK → "+userDownloads.AsList()[0].SoundID_FK);
            Console.WriteLine("OBTENIDOS CON EXITO - UserDownloadRepository (IfExistsByUserID_FK)");
            return userDownloads.ToList();

        }catch(Exception ex){
            Console.WriteLine("HA OCURRIDO UN ERROR - UserDownloadRepository (IfExistsByUserID_FK)" + ex.StackTrace);
            return null;
        }

    }

}