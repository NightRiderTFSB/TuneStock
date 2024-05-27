//Importamos el decorador para establecer la tabla SQL objetivo

using System.ComponentModel.DataAnnotations.Schema;

//Nombre del paquete al que pertenece la clase
namespace tunestock.core.entities;

[Table("User")] //Apuntamos a la tabla correspondiente
public class User : EntityBase
{
    /*Heredamos los atributos base*/

    public string? Username { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }
}