//Importamos el paquete que nos permita usar DbConnection

using System.Data.Common;

//Nombre del paquete al que pertenece la clase
namespace tunestock.api.dataAccess.interfaces;

public interface IDbContext
{
    //Nos devolverá la conexión a la base de datos
    DbConnection Connection { get; }
}