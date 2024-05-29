using tunestock.api.dto;

namespace tunestock.server.Services.Purchases;

public interface IPurschaseService {
    
    //Todas las compras de un usuario
    Task<List<UserPurchaseDto>> GetAllAsync(int userID_FK);

    //Guardar la compra de un usuario
    Task<UserPurchaseDto> SaveAsync(UserPurchaseDto userPurchase);

    //Obtener una compra por ID
    Task<UserPurchaseDto> GetByID(int ID);
    
}