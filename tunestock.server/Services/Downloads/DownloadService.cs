using Newtonsoft.Json;
using tunestock.core.entities;
using tunestock.core.http;

namespace tunestock.server.Services.Downloads;

public class DownloadService : IDownloadService {
    private readonly string _baseURL = "https://localhost:7000/";
    private readonly string _endpoint = "api/UserDownload";
    
    public Task<bool> UserDownloadExists(int ID) {
        throw new NotImplementedException();
    }

    public async Task<List<UserDownload>> GetAllAsync(int userID_FK) {
        var url = $"{_baseURL}{_endpoint}?userID_FK={userID_FK}";
        var client = new HttpClient();
        var res = await client.GetAsync(url);
        var json = await res.Content.ReadAsStringAsync();
        
        var response = JsonConvert.DeserializeObject<Response<List<UserDownload>>>(json);

        return response.Data;
    }

    public async Task<UserDownload> SaveAsync(UserDownload userDownload) {
        var url = $"{_baseURL}{_endpoint}";
        var jsonRequest = JsonConvert.SerializeObject(userDownload);
        var content = new StringContent(jsonRequest, System.Text.Encoding.UTF8, "application/json");
        var client = new HttpClient();
        var res = await client.PostAsync(url, content);
        var json = await res.Content.ReadAsStringAsync();

        Console.WriteLine("JSON: " + json);
        
        var response = JsonConvert.DeserializeObject<Response<UserDownload>>(json);

        return response.Data;
    }

    public async Task<UserDownload> GetByID(int ID) {
        var url = $"{_baseURL}{_endpoint}/{ID}";
        var client = new HttpClient();
        var res = await client.GetAsync(url);
        var json = await res.Content.ReadAsStringAsync();
        var response = JsonConvert.DeserializeObject<Response<UserDownload>>(json);

        return response.Data;
    }

    public async Task<List<UserSoundStock>?> GetStock(int ID) {
        var url = $"{_baseURL}{_endpoint}/mystock/{ID}";
        var client = new HttpClient();
        var res = await client.GetAsync(url);
        var json = await res.Content.ReadAsStringAsync();
        
        Console.WriteLine($"JSON: {json}");
        
        var response = JsonConvert.DeserializeObject<Response<List<UserSoundStock>>>(json);

        return response.Data;
    }

    public Task<bool> IfExistsByUserID_FK(int userID_FK) {
        throw new NotImplementedException();
    }
}