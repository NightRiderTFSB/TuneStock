using tunestock.api.dto;

//Nombre del paquete al que pertenece la clase
namespace tunestock.api.services.interfaces;

public interface IUserPurchaseService
{
    Task<bool> UserPurchaseExists(int ID);

    Task<List<UserPurchaseDto>> GetAllAsync(int userID_FK);

    Task<UserPurchaseDto> SaveAsync(UserPurchaseDto userPurchase);

    Task<UserPurchaseDto> GetByID(int ID);

    Task<bool> IfExistsByUserID_FK(int userID_FK);
}