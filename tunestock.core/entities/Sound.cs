using System.ComponentModel.DataAnnotations.Schema;

//Nombre del paquete al que pertenece la clase
namespace tunestock.core.entities;

[Table("Sound")]
public class Sound : EntityBase {

    public int UserID { get; set; }

    public string? SoundName { get; set; }

    public string? File { get; set; }

    public bool IsPremiun { get; set; }

    public double Price { get; set; }

}