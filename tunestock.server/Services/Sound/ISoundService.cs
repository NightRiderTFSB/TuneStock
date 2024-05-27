using tunestock.api.dto;
using tunestock.core.http;

namespace tunestock.server.Services.Sound;

public interface ISoundService
{
    Task<Response<List<SoundDto>>> GetAllAsync();
    Task<Response<SoundDto>> GeyByID(int id);
    Task<Response<SoundDto>> SaveAsync(SoundDto soundDto, int label);
    Task<Response<SoundDto>> UpdateAsync(SoundDto soundDto);
    Task<Response<bool>> DeleteAsync(int id);
    Task<Response<List<SoundDto>>> GetByUser(int id);
}