//Importamos las entidades, interfaces y el dataaccess
using tunestock.core.entities;
using tunestock.api.repositories.interfaces;
using tunestock.api.dataAccess.interfaces;

//Importamos dapper y dapper.contrib
using Dapper;
using Dapper.Contrib.Extensions;
using System.ComponentModel;
using System.Data;

//Nombre del paquete al que pertenecen
namespace tunestock.api.repositories;

public class SoundRepository : ISoundRepository{

    private readonly IDbContext _dbContext;

    public SoundRepository(IDbContext context){
        _dbContext = context;
    }

    public async Task<bool> DeleteAsync(int ID){
        
        try{
            var sound = await GetByID(ID);

            if(sound == null){
                return false;
            }

            sound.IsDeleted = true;
            Console.WriteLine("ELIMINADO CORRECTAMENTE - SoundRepository (DeleteAsync)");
            return await _dbContext.Connection.UpdateAsync(sound);

        }catch(Exception ex){
            Console.WriteLine("HA OCURRIDO UN ERROR - SoundRepository (DeleteAsync): " + ex.StackTrace);
            return false;
        }

    }

    public async Task<List<Sound>> GetAllAsync(){
        
        try{
            const string query = "SELECT * FROM Sound WHERE IsDeleted = 0";
            var sounds = await _dbContext.Connection.QueryAsync<Sound>(query);
            Console.WriteLine("OBTENIDOS CON EXITO - SoundRepository (GetAllAsync)");
            return sounds.ToList();

        }catch(Exception ex){
            Console.WriteLine("HA OCURRIDO UN ERROR - SoundRepository (GetAllAsync)" + ex.StackTrace);
            return null;
        }

    }

    public async Task<Sound> GetByID(int SoundID){
        try{
            var sound = await _dbContext.Connection.GetAsync<Sound>(SoundID);

            if(sound == null){
                return null;
            }

            Console.WriteLine("OBTENIDO CON EXITO - SoundRepository (GetByID)");

            return sound.IsDeleted == true ? null: sound;

        }catch(Exception ex){
            Console.WriteLine("HA OCURRIDO UN ERROR - SoundRepository (GetByID)" + ex.StackTrace);
            return null;
        }
    }

    public async Task<Sound> SaveAsync(Sound sound, int labelId){
        try{
            // Ejecutar el procedimiento almacenado
        var parameters = new {
            p_UserID = sound.UserID,
            p_SoundName = sound.SoundName,
            p_File = sound.File,
            p_IsPremiun = sound.IsPremiun,
            p_Price = sound.Price,
            p_IsDeleted = sound.IsDeleted,
            p_CreatedBy = sound.CreatedBy,
            p_CreatedDate = sound.CreatedDate,
            p_UpdatedBy = sound.UpdatedBy,
            p_UpdatedDate = sound.UpdatedDate,
            p_LabelID = labelId // Pasar el ID de la etiqueta como parámetro
        };

        await _dbContext.Connection.ExecuteAsync("InsertSoundAndLabel", parameters, commandType: CommandType.StoredProcedure);

        // Obtener el nuevo ID del sonido insertado
        var newSoundId = await _dbContext.Connection.ExecuteScalarAsync<int>("SELECT LAST_INSERT_ID()");

        // Asignar el nuevo ID al objeto sound
        sound.ID = newSoundId;

        // Devolver el sonido recién insertado
        return sound;

        }catch(Exception ex){
            Console.WriteLine("HA OCURRIDO UN ERROR - SoundRepository (SaveAsync) xd: " + ex.StackTrace);
            return null;
        }
    }

    public async Task<Sound> UpdateAsync(Sound sound)
    {
        try{
            await _dbContext.Connection.UpdateAsync(sound);
            Console.WriteLine("ACTUALIZADO CORRECTAMENTE - SoundRepository (UpdateAsync)");
            return sound;
            
        }catch(Exception ex){
            Console.WriteLine("HA OCURRIDO UN ERROR - SoundRepository (UpdateAsync): " + ex.StackTrace);
            return null;
        }
    }

}