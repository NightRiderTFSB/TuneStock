using tunestock.api.dto;
using tunestock.core.http;
using Newtonsoft.Json;

namespace tunestock.server.Services.Sound;

public class SoundService : ISoundService
{
    
    private readonly string _baseURL = "https://localhost:7000/";
    private readonly string _endpoint = "api/Sound";    
    
    public async Task<Response<List<SoundDto>>> GetAllAsync()
    {
        var url = $"{_baseURL}{_endpoint}";
        var client = new HttpClient();
        var res = await client.GetAsync(url);
        var json = await res.Content.ReadAsStringAsync();

        var response = JsonConvert.DeserializeObject < Response<List<SoundDto>>>(json);

        return response;
    }

    public async Task<Response<SoundDto>> GeyByID(int id)
    {
        var url = $"{_baseURL}{_endpoint}/{id}";
        var client = new HttpClient();
        var res = await client.GetAsync(url);
        var json = await res.Content.ReadAsStringAsync();
        var response = JsonConvert.DeserializeObject<Response<SoundDto>>(json);

        return response;
    }

    public async Task<Response<SoundDto>> SaveAsync(SoundDto soundDto, int label)
    {
        var url = $"{_baseURL}{_endpoint}?labelId={label}";
        Console.WriteLine("URL: " + url);
        var jsonRequest = JsonConvert.SerializeObject(soundDto);
        var content = new StringContent(jsonRequest, System.Text.Encoding.UTF8, "application/json");
        var client = new HttpClient();
        var res = await client.PostAsync(url, content);
        var json = await res.Content.ReadAsStringAsync();

        Console.WriteLine("JSON Response: " + json); // Imprime el JSON
        
        var response = JsonConvert.DeserializeObject<Response<SoundDto>>(json);

        return response;
    }

    public async Task<Response<SoundDto>> UpdateAsync(SoundDto soundDto)
    {
        var url = $"{_baseURL}{_endpoint}/{soundDto.ID}";
        var jsonRequest = JsonConvert.SerializeObject(soundDto);
        var content = new StringContent(jsonRequest, System.Text.Encoding.UTF8, "application/json");
        var client = new HttpClient();
        var res = await client.PutAsync(url, content);
        var json = await res.Content.ReadAsStringAsync();   

        Console.WriteLine("JSON Response: " + json); // Imprime el JSON
        
        var response = JsonConvert.DeserializeObject<Response<SoundDto>>(json);

        return response;
    }

    public async Task<Response<bool>> DeleteAsync(int id)
    {
        var url = $"{_baseURL}{_endpoint}/{id}";
        var client = new HttpClient();
        var res = await client.DeleteAsync(url);
        var json = await res.Content.ReadAsStringAsync();

        var response = JsonConvert.DeserializeObject<Response<bool>>(json);

        return response;
    }

    public async Task<Response<List<SoundDto>>> GetByUser(int id) {
        var url = $"{_baseURL}{_endpoint}/byuser/{id}";
        var client = new HttpClient();
        var res = await client.GetAsync(url);
        var json = await res.Content.ReadAsStringAsync();

        var response = JsonConvert.DeserializeObject < Response<List<SoundDto>>>(json);

        return response;
    }
    
    public async Task<Response<List<SoundDto>>> GetBySoundIds(List<int> soundIds) {
        var url = $"{_baseURL}{_endpoint}/bysoundids";
        var client = new HttpClient();
        var jsonRequest = JsonConvert.SerializeObject(soundIds);
        var content = new StringContent(jsonRequest, System.Text.Encoding.UTF8, "application/json");
        var res = await client.PostAsync(url, content);
        var json = await res.Content.ReadAsStringAsync();
        var response = JsonConvert.DeserializeObject<Response<List<SoundDto>>>(json);
        return response;
    }
}