//Nombre del paquete al que pertenece la clase
namespace My.Tecnm.Ecommerce.Core.Http;

public class Response<T>{
    //Esta clase nos permitirá manejar las respuestas del servidor

    public T Data { get; set; }
    //T es un tipo génerico de datos, el cual puede 
    //variar en <int>, <stiring>, etc.
    public string Message { get; set;} = "";
    //Guardamos el mensaje de la respuesta

    public List<string> Errors { get; set;} = new List<string>();
    //Guardamos una lista de errores para aquellos que se lleguen
    //a presentar
}