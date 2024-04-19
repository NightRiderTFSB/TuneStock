//Importamos la entidad correspondiente
using tunestock.core.entities;

//Nombre del paquete al que pertenece la clase
namespace tunestock.api.repositories.interfaces;

public interface IUserPurchaseRepository{

    //Método asíncrono para guardar user purchase
    Task<UserPurchase> SaveAsync(UserPurchase userPurchase);

    //Método asíncrono para retornar todas las user purchases
    Task<List<UserPurchase>> GetAllAsync();

    //Método asíncrono para retornar una user purchase por ID
    Task<UserPurchase> GetByID(int ID);

}