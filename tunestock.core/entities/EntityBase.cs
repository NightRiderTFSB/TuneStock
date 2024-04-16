
//Nombre del paquete al que pertenece esta clase
namespace tunestock.core.entities;

public abstract class EntityBase{

    /*Esta clase permitirá construir objetos con esta clase "base"
    que nos proporciona los siguientes atributos base*/

    public int ID { get; set; }

    public bool IsDeleted { get; set; }

    public string CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; }

    public string UpdatedBy { get; set; }

    public DateTime UpdatedDate { get; set; }

}