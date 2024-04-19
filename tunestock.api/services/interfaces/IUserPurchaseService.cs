using tunestock.api.dto;

//Nombre del paquete al que pertenece la clase
namespace tunestock.api.services.interfaces;

public interface IUserPurchaseService {

    Task<bool> UserPurchaseExists(int ID);

    Task<List<UserPurchaseDto>> GetAllAsync();

    Task<UserPurchaseDto> SaveAsync(UserPurchaseDto userPurchase);

    Task<UserPurchaseDto> GetByID(int ID);
    
    
}