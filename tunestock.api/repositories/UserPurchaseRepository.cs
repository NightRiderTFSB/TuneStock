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

    public async Task<bool> DeleteAsync(int ID){
        try{
            var userPurchase = await GetByID(ID);

            if(userPurchase == null){
                return false;
            }

            userPurchase.IsDeleted = true;
            Console.WriteLine("ELIMINADO CORRECTAMENTE - UserPurchaseRepository (DeleteAsync)");
            return await _dbContext.Connection.UpdateAsync(userPurchase);

        }catch(Exception ex){
            Console.WriteLine("HA OCURRIDO UN ERROR - UserPurchaseRepository (DeleteAsync): " + ex.StackTrace);
            return false;
        }
    }

    public async Task<List<UserPurchase>> GetAllAsync(){
        try{
            const string query = "SELECT * FROM UserPurchase WHERE IsDeleted = 0";
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

    public async Task<UserPurchase> UpdateAsync(UserPurchase userPurchase){
        try{
            await _dbContext.Connection.UpdateAsync(userPurchase);
            Console.WriteLine("ACTUALIZADO CORRECTAMENTE - UserPurchaseRepository (UpdateAsync)");
            return userPurchase;

        }catch(Exception ex){
            Console.WriteLine("HA OCURRIDO UN ERROR - UserPurchaseRepository (UpdateAsync): " + ex.StackTrace);
            return null;
        }
    }
}