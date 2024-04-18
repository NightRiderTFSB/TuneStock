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

public class UserRepository : IUserRepository {

    private readonly IDbContext _dbContext;

    public UserRepository(IDbContext context){
        _dbContext = context;
    }

    public async Task<bool> DeleteAsync(int ID){
        try{
            var user = await GetByID(ID);

            if(user == null){
                return false;
            }

            user.IsDeleted = true;
            Console.WriteLine("ELIMINADO CORRECTAMENTE - userRepository (DeleteAsync)");
            return await _dbContext.Connection.UpdateAsync(user);

        }catch(Exception ex){
            Console.WriteLine("HA OCURRIDO UN ERROR - UserRepository ()" + ex.StackTrace);
            return false;
        }
    }

    public async Task<List<User>> GetAllAsync(){
        try{
            const string query = "SELECT * FROM User WHERE IsDeleted = 0";
            var users = await _dbContext.Connection.QueryAsync<User>(query);
            Console.WriteLine("OBTENIDOS CON EXITO - userRepository (GetAllAsync)");
            return users.ToList();

        }catch(Exception ex){
            Console.WriteLine("HA OCURRIDO UN ERROR - UserRepository ()" + ex.StackTrace);
            return null;
        }
    }

    public async Task<User> GetByID(int ID){
        try{
            var user = await _dbContext.Connection.GetAsync<User>(ID);

            if(user == null){
                return null;
            }

            Console.WriteLine("OBTENIDO CON EXITO - userRepository (GetByID)");

            return user.IsDeleted == true ? null: user;

        }catch(Exception ex){
            Console.WriteLine("HA OCURRIDO UN ERROR - UserRepository ()" + ex.StackTrace);
            return null;
        }
    }

    public async Task<User> SaveAsync(User user){
        try{
            user.ID = await _dbContext.Connection.InsertAsync(user);
            Console.WriteLine("GUARDADO CORRECTAMENTE - userRepository (SaveAsync)");
            return user;

        }catch(Exception ex){
            Console.WriteLine("HA OCURRIDO UN ERROR - UserRepository ()" + ex.StackTrace);
            return null;
        }
    }

    public async Task<User> UpdateAsync(User user){
        try{
            await _dbContext.Connection.UpdateAsync(user);
            Console.WriteLine("ACTUALIZADO CORRECTAMENTE - userRepository (UpdateAsync)");
            return user;

        }catch(Exception ex){
            Console.WriteLine("HA OCURRIDO UN ERROR - UserRepository ()" + ex.StackTrace);
            return null;
        }
    }
}