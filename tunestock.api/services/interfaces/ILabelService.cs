//Importación del DTO correspondiente
using tunestock.api.dto;

//Nombre del paquete al que pertenece la clase
namespace tunestock.api.services.interfaces;

public interface ILabelService {

    Task<bool> LabelExists(int ID);

    Task<List<LabelDto>> GetAllAsync();

    Task<LabelDto> SaveAsync(LabelDto label);

    Task<LabelDto> GetByID(int ID);

    Task<LabelDto> UpdateAsync(LabelDto label);

    Task<bool> DeleteAsync(int ID);

}