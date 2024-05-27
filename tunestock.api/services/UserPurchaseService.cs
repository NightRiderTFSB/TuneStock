//Imports de los paquetes correspondientes

using tunestock.api.dto;
using tunestock.api.repositories.interfaces;
using tunestock.api.services.interfaces;
using tunestock.core.entities;

//Nombre del paquete al que pertenece la clase
namespace tunestock.api.services;

public class UserPurchaseService : IUserPurchaseService
{
    private readonly IUserPurchaseRepository _userPurchaseRepository;

    public UserPurchaseService(IUserPurchaseRepository userPurchaseRepository)
    {
        _userPurchaseRepository = userPurchaseRepository;
    }

    public async Task<List<UserPurchaseDto>> GetAllAsync(int userID_FK)
    {
        try
        {
            var userPurchases = await _userPurchaseRepository.GetAllAsync(userID_FK);
            var userPurchaseDtos = userPurchases.Select(u => new UserPurchaseDto(u)).ToList();
            return userPurchaseDtos;
        }
        catch (Exception ex)
        {
            Console.WriteLine("HA OCURRIDO UN ERROR - UserPurchaseService (GetAllAsync)" + ex.StackTrace);
            return null;
        }
    }

    public async Task<UserPurchaseDto> GetByID(int ID)
    {
        try
        {
            var userPurchase = await _userPurchaseRepository.GetByID(ID);
            if (userPurchase == null) throw new Exception("User Purchase not found");

            var userPurchaseDto = new UserPurchaseDto(userPurchase);
            return userPurchaseDto;
        }
        catch (Exception ex)
        {
            Console.WriteLine("HA OCURRIDO UN ERROR - UserPurchaseService (GetByID)" + ex.StackTrace);
            return null;
        }
    }

    public async Task<UserPurchaseDto> SaveAsync(UserPurchaseDto userPurchaseDto)
    {
        try
        {
            var userPurchase = new UserPurchase
            {
                PurchasedDate = DateTime.Now,
                SoundPrice = userPurchaseDto.SoundPrice,
                PaymentStatus = userPurchaseDto.PaymentStatus,
                PaymentMethod = userPurchaseDto.PaymentMethod,
                UserID_FK = userPurchaseDto.UserID_FK,
                SoundID_FK = userPurchaseDto.SoundID_FK,
                CreatedBy = "Starryboy",
                CreatedDate = DateTime.Now,
                UpdatedBy = "Starryboy",
                UpdatedDate = DateTime.Now
            };

            userPurchase = await _userPurchaseRepository.SaveAsync(userPurchase);
            userPurchaseDto.ID = userPurchase.ID;

            return userPurchaseDto;
        }
        catch (Exception ex)
        {
            Console.WriteLine("HA OCURRIDO UN ERROR - UserPurchaseService (SaveAsync)" + ex.StackTrace);
            return null;
        }
    }

    public async Task<bool> UserPurchaseExists(int ID)
    {
        try
        {
            var userPurchase = await _userPurchaseRepository.GetByID(ID);
            return userPurchase != null;
        }
        catch (Exception ex)
        {
            Console.WriteLine("HA OCURRIDO UN ERROR - UserPurchaseService (UserPurchaseExists)" + ex.StackTrace);
            return false;
        }
    }

    public async Task<bool> IfExistsByUserID_FK(int userID_FK)
    {
        try
        {
            var userPurchase = await _userPurchaseRepository.IfExistsByUserID_FK(userID_FK);
            return userPurchase != null;
        }
        catch (Exception ex)
        {
            Console.WriteLine("HA OCURRIDO UN ERROR - UserPurchaseService (UserPurchaseExists)" + ex.StackTrace);
            return false;
        }
    }
}