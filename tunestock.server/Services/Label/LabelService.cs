using tunestock.api.dto;
using tunestock.core.http;
using Newtonsoft.Json;

namespace tunestock.server.Services.Label;

public class LabelService: ILabelService
{
    
    private readonly string _baseURL = "https://localhost:7000/";
    private readonly string _endpoint = "api/Label";
    
    public async Task<Response<List<LabelDto>>> GetAllAsync()
    {
        var url = $"{_baseURL}{_endpoint}";
        var client = new HttpClient();
        var res = await client.GetAsync(url);
        var json = await res.Content.ReadAsStringAsync();

        var response = JsonConvert.DeserializeObject < Response<List<LabelDto>>>(json);

        return response;
    }

    public async Task<Response<LabelDto>> GeyByID(int id)
    {
        var url = $"{_baseURL}{_endpoint}/{id}";
        var client = new HttpClient();
        var res = await client.GetAsync(url);
        var json = await res.Content.ReadAsStringAsync();
        var response = JsonConvert.DeserializeObject<Response<LabelDto>>(json);

        return response;
    }

    public async Task<Response<LabelDto>> SaveAsync(LabelDto labelDto)
    {
        var url = $"{_baseURL}{_endpoint}";
        var jsonRequest = JsonConvert.SerializeObject(labelDto);
        var content = new StringContent(jsonRequest, System.Text.Encoding.UTF8, "application/json");
        var client = new HttpClient();
        var res = await client.PostAsync(url, content);
        var json = await res.Content.ReadAsStringAsync();

        var response = JsonConvert.DeserializeObject<Response<LabelDto>>(json);

        return response;
    }

    public async Task<Response<LabelDto>> UpdateAsync(LabelDto labelDto)
    {
        var url = $"{_baseURL}{_endpoint}";
        var jsonRequest = JsonConvert.SerializeObject(labelDto);
        var content = new StringContent(jsonRequest, System.Text.Encoding.UTF8, "application/json");
        var client = new HttpClient();
        var res = await client.PutAsync(url, content);
        var json = await res.Content.ReadAsStringAsync();   

        var response = JsonConvert.DeserializeObject<Response<LabelDto>>(json);

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
}