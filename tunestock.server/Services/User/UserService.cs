using tunestock.api.dto;
using tunestock.core.http;
using Newtonsoft.Json;

namespace tunestock.server.Services.User;

public class UserService : IUserService
{
    
    private readonly string _baseURL = "https://localhost:7000/";
    private readonly string _endpoint = "api/User";
    
    public async Task<Response<List<UserDto>>> GetAllAsync()
    {
        var url = $"{_baseURL}{_endpoint}";
        var client = new HttpClient();
        var res = await client.GetAsync(url);
        var json = await res.Content.ReadAsStringAsync();

        var response = JsonConvert.DeserializeObject < Response<List<UserDto>>>(json);

        return response;
    }

    public async Task<Response<UserDto>> GeyByID(int id)
    {
        var url = $"{_baseURL}{_endpoint}/{id}";
        var client = new HttpClient();
        var res = await client.GetAsync(url);
        var json = await res.Content.ReadAsStringAsync();
        var response = JsonConvert.DeserializeObject<Response<UserDto>>(json);

        return response;
    }

    public async Task<Response<UserDto>> SaveAsync(UserDto userDto)
    {
        var url = $"{_baseURL}{_endpoint}";
        var jsonRequest = JsonConvert.SerializeObject(userDto);
        var content = new StringContent(jsonRequest, System.Text.Encoding.UTF8, "application/json");
        var client = new HttpClient();
        var res = await client.PostAsync(url, content);
        var json = await res.Content.ReadAsStringAsync();

        var response = JsonConvert.DeserializeObject<Response<UserDto>>(json);

        return response;
    }

    public async Task<Response<UserDto>> UpdateAsync(UserDto userDto)
    {
        var url = $"{_baseURL}{_endpoint}";
        var jsonRequest = JsonConvert.SerializeObject(userDto);
        var content = new StringContent(jsonRequest, System.Text.Encoding.UTF8, "application/json");
        var client = new HttpClient();
        var res = await client.PutAsync(url, content);
        var json = await res.Content.ReadAsStringAsync();   

        var response = JsonConvert.DeserializeObject<Response<UserDto>>(json);

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

    
    public async Task<Response<bool>> Login(UserDto userDto)
    {
        var url = $"{_baseURL}{_endpoint}/login";
        var jsonRequest = JsonConvert.SerializeObject(userDto);
        var content = new StringContent(jsonRequest, System.Text.Encoding.UTF8, "application/json");
        var client = new HttpClient();
        var res = await client.PostAsync(url, content);
        var json = await res.Content.ReadAsStringAsync();

        var response = JsonConvert.DeserializeObject<Response<bool>>(json);

        return response;
    }

    public async Task<Response<core.entities.User>> GetByEmail(UserDto userDto)
    {
        var url = $"{_baseURL}{_endpoint}/byemail/{userDto.Email}";
        var client = new HttpClient();
        var res = await client.GetAsync(url);
        var json = await res.Content.ReadAsStringAsync();

        var response = JsonConvert.DeserializeObject<Response<core.entities.User>>(json);

        return response;
    }
}