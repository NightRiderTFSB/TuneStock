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

public class UserPurchaseRepository : IUserPurchaseRepository{

    private readonly IDbContext _dbContext;

    public UserPurchaseRepository(IDbContext context){
        _dbContext = context;
    }

    public async Task<List<UserPurchase>> GetAllAsync(int userID_FK){
        try{
            string query = $"SELECT * FROM UserPurchases WHERE UserID_FK = {userID_FK};";
            var userPurchase = await _dbContext.Connection.QueryAsync<UserPurchase>(query);
            Console.WriteLine("OBTENIDOS CON EXITO - UserPurchaseRepository (GetAllAsync)");
            return userPurchase.ToList();

        }catch(Exception ex){
            Console.WriteLine("HA OCURRIDO UN ERROR - UserPurchaseRepository (GetAllAsync): " + ex.StackTrace);
            return null;
        }
    }

    public async Task<UserPurchase> GetByID(int ID){
        try{
            var userPurchase = await _dbContext.Connection.GetAsync<UserPurchase>(ID);

            if(userPurchase == null){
                return null;
            }

            Console.WriteLine("OBTENIDO CON EXITO - UserPurchaseRepository (GetByID)");

            return userPurchase.IsDeleted == true ? null: userPurchase;

        }catch(Exception ex){
            Console.WriteLine("HA OCURRIDO UN ERROR - UserPurchaseRepository (GetByID): " + ex.StackTrace);
            return null;
        }
    }

    public async Task<UserPurchase> SaveAsync(UserPurchase userPurchase){
        try{
            userPurchase.ID = await _dbContext.Connection.InsertAsync(userPurchase);
            Console.WriteLine("GUARDADO CORRECTAMENTE - UserPurchaseRepository (SaveAsync)");
            return userPurchase;

        }catch(Exception ex){
            Console.WriteLine("HA OCURRIDO UN ERROR - UserPurchaseRepository (SaveAsync): " + ex.StackTrace);
            return null;
        }
    }

    public async Task<List<UserPurchase>> IfExistsByUserID_FK(int userID_FK)
    {
        try{
            string query = $"SELECT * FROM UserPurchases WHERE UserID_FK = {userID_FK};";
            var userPurchase = await _dbContext.Connection.QueryAsync<UserPurchase>(query);
            Console.WriteLine("UserID_FK → "+userPurchase.AsList()[0].SoundID_FK);
            Console.WriteLine("OBTENIDOS CON EXITO - UserPurchaseRepository (IfExistsByUserID_FK)");
            return userPurchase.ToList();

        }catch(Exception ex){
            Console.WriteLine("HA OCURRIDO UN ERROR - UserPurchaseRepository (GetByID): " + ex.StackTrace);
            return null;
        }
    }

}