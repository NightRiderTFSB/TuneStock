//Importamos la entidad correspondiente
using tunestock.core.entities;

//Nombre del paquete al que pertenece la clase
namespace tunestock.api.dto;

public class InputLabelDto{
    
    public string? Labelname { get; set; }
    public string? Description {get; set;}

    public InputLabelDto(){
        
    }

    public InputLabelDto(Label label){
        Labelname = label.Labelname;
        Description = label.Description;
    }

}