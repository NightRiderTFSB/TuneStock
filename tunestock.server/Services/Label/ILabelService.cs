using tunestock.api.dto;
using tunestock.core.http;

namespace tunestock.server.Services.Label;

public interface ILabelService
{
    Task<Response<List<LabelDto>>> GetAllAsync();
    Task<Response<LabelDto>> GeyByID(int id);
    Task<Response<LabelDto>> SaveAsync(LabelDto labelDto);
    Task<Response<LabelDto>> UpdateAsync(LabelDto labelDto);
    Task<Response<bool>> DeleteAsync(int id);
}