//Importamos el paquete que nos permita manejar Connections
using System.Data.Common;
//Importamos el paquete que contiene nuestra interfaz
using tunestock.api.dataAccess.interfaces;
//Importamos el conector de MySQL que instalamos previamente
using MySqlConnector;

public class DbContext : IDbContext{

    private readonly IConfiguration _config;
    public DbContext(IConfiguration config){
        _config = config;
    }
    
    //Esta será nuestra variable de conexión
    private MySqlConnection _connection; 

    //Devolverá la conexión a la base de datos
    public DbConnection Connection{
        get{
            if(_connection == null){
                //DefaultConnection está definido en appsettgins.json
                _connection = new MySqlConnection(
                    _config.GetConnectionString("DefaultConnection"));
            }
            return _connection;
        }
    }
}