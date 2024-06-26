//Importamos la entidad correspondiente

using tunestock.core.entities;

//Nombre del paquete al que pertenece la clase
namespace tunestock.api.dto;

public class SoundDto : DtoBase
{
    public SoundDto()
    {
    }

    public SoundDto(Sound sound)
    {
        ID = sound.ID;
        UserID = sound.UserID;
        SoundName = sound.SoundName;
        File = sound.File;
        IsPremiun = sound.IsPremiun;
        Price = sound.Price;
    }


    public int UserID { get; set; }
    public string? SoundName { get; set; }

    public string? File { get; set; } //Aqui debe almacenarse la ruta al archivo para descargarlo despues

    public bool IsPremiun { get; set; }

    public double Price { get; set; }
}