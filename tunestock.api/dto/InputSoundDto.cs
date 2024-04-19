//Importamos la entidad correspondiente
using tunestock.core.entities;

//Nombre del paquete al que pertenece la clase
namespace tunestock.api.dto;

public class InputSoundDto{
    

    public int UserID { get; set; }
    public string? SoundName { get; set; }

    public string? File { get; set; }

    public bool IsPremiun { get; set; }

    public double Price { get; set; }


    public InputSoundDto(){
        
    }

    public InputSoundDto(Sound sound){
        UserID = sound.UserID;
        SoundName = sound.SoundName;
        File = sound.File;
        IsPremiun = sound.IsPremiun;
        Price = sound.Price;
    }

}