//Importamos el decorador para establecer la tabla SQL objetivo
using System.ComponentModel.DataAnnotations.Schema;

//Nombre del paquete al que pertenece la clase
namespace tunestock.core.entities;

[Table("UserPurchases")]
public class UserPurchase : EntityBase {

    public string PurchasedDate { get; set; }

    public double SoundPrice { get; set; }

    public bool PaymentStatus { get; set; }

    public string PaymentMethod { get; set; }

    public int UserID_FK { get; set; }

    public int SoundID_FK { get; set; }

}