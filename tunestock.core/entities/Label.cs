using System.ComponentModel.DataAnnotations.Schema;

//Nombre del paquete al que pertenece la clase
namespace tunestock.core.entities;

[Table("Labels")]
public class Label : EntityBase
{
    public string? Labelname { get; set; }

    public string? Description { get; set; }
}