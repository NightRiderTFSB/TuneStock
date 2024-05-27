//Importamos la entidad correspondiente

using tunestock.core.entities;

//Nombre del paquete al que pertenece la clase
namespace tunestock.api.dto;

public class UserPurchaseDto : DtoBase
{
    public UserPurchaseDto()
    {
    }

    public UserPurchaseDto(UserPurchase userPurchase)
    {
        ID = userPurchase.ID;
        PurchasedDate = userPurchase.PurchasedDate;
        SoundPrice = userPurchase.SoundPrice;
        PaymentStatus = userPurchase.PaymentStatus;
        PaymentMethod = userPurchase.PaymentMethod;
        UserID_FK = userPurchase.UserID_FK;
        SoundID_FK = userPurchase.SoundID_FK;
    }

    public DateTime PurchasedDate { get; set; }

    public double SoundPrice { get; set; }

    public bool PaymentStatus { get; set; }

    public string? PaymentMethod { get; set; }

    public int UserID_FK { get; set; }

    public int SoundID_FK { get; set; }
}