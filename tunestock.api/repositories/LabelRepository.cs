//Importamos las entidades, interfaces y el dataaccess
using tunestock.core.entities;
using tunestock.api.repositories.interfaces;
using tunestock.api.dataAccess.interfaces;

//Importamos dapper y dapper.contrib
using Dapper;
using Dapper.Contrib.Extensions;
using System.ComponentModel;
using MySqlConnector;

//Nombre del paquete al que pertenecen
namespace tunestock.api.repositories;

public class LabelRepository : ILabelRepository{

    private readonly IDbContext _dbContext;

    public LabelRepository(IDbContext context){
        _dbContext = context;
    }

    public async Task<bool> DeleteAsync(int ID){
        
        try{
            var label = await GetByID(ID);

            if(label == null){
                return false;
            }

            label.IsDeleted = true;
            Console.WriteLine("ELIMINADO CORRECTAMENTE - LabelRepository (DeleteAsync)");
            return await _dbContext.Connection.UpdateAsync(label);

        }catch(Exception ex){
            Console.WriteLine("HA OCURRIDO UN ERROR - LabelRepository (DeleteAsync): " + ex.StackTrace);
            return false;
        }

    }

    public async Task<List<Label>> GetAllAsync(){
        
        try{
            const string query = "SELECT * FROM Labels WHERE IsDeleted = 0";
            var labels = await _dbContext.Connection.QueryAsync<Label>(query);
            Console.WriteLine("OBTENIDOS CON EXITO - LabelRepository (GetAllAsync)");
            return labels.ToList();

        }catch(Exception ex){
            Console.WriteLine("HA OCURRIDO UN ERROR - LabelRepository (GetAllAsync)" + ex.StackTrace);
            return null;
        }

    }

    public async Task<Label> GetByID(int LabelID)
    {
        try
        {
            var label = await _dbContext.Connection.GetAsync<Label>(LabelID);

            if (label == null)
            {
                Console.WriteLine($"Label con ID {LabelID} no encontrado.");
                return null;
            }

            Console.WriteLine("OBTENIDO CON EXITO - LabelRepository (GetByID)");

            return label.IsDeleted ? null : label;
        }
        catch (MySqlException ex)
        {
            Console.WriteLine($"MySQL error - LabelRepository (GetByID): {ex.Message}");
            return null;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"HA OCURRIDO UN ERROR - LabelRepository (GetByID): {ex.Message}");
            Console.WriteLine(ex.StackTrace);
            return null;
        }
    }


    public async Task<Label> SaveAsync(Label label){
        try{
            label.ID = await _dbContext.Connection.InsertAsync(label);
            Console.WriteLine("GUARDADO CORRECTAMENTE - LabelRepository (SaveAsync)");
            return label;

        }catch(Exception ex){
            Console.WriteLine("HA OCURRIDO UN ERROR - LabelRepository (SaveAsync): " + ex.StackTrace);
            return null;
        }
    }

    public async Task<Label> UpdateAsync(Label label)
    {
        try{
            await _dbContext.Connection.UpdateAsync(label);
            Console.WriteLine("ACTUALIZADO CORRECTAMENTE - LabelRepository (UpdateAsync)");
            return label;
            
        }catch(Exception ex){
            Console.WriteLine("HA OCURRIDO UN ERROR - LabelRepository (UpdateAsync): " + ex.StackTrace);
            return null;
        }
    }

}