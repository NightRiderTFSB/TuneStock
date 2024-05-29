using Newtonsoft.Json;
using tunestock.api.dto;
using tunestock.core.http;

namespace tunestock.server.Services.Purchases;

public class PurchaseService : IPurschaseService {
    
    private readonly string _baseURL = "https://localhost:7000/";
    private readonly string _endpoint = "api/UserPurchase";
    
    public async Task<List<UserPurchaseDto>> GetAllAsync(int userID_FK) {
        var url = $"{_baseURL}{_endpoint}?userID_FK={userID_FK}";
        var client = new HttpClient();
        var res = await client.GetAsync(url);
        var json = await res.Content.ReadAsStringAsync();
        
        Console.WriteLine("JSON: " + json);
        
        var response = JsonConvert.DeserializeObject<Response<List<UserPurchaseDto>>>(json);

        return response.Data;
    }

    public async Task<UserPurchaseDto> SaveAsync(UserPurchaseDto userPurchase) {
        var url = $"{_baseURL}{_endpoint}";
        var jsonRequest = JsonConvert.SerializeObject(userPurchase);
        var content = new StringContent(jsonRequest, System.Text.Encoding.UTF8, "application/json");
        var client = new HttpClient();
        var res = await client.PostAsync(url, content);
        var json = await res.Content.ReadAsStringAsync();

        Console.WriteLine("JSON: " + json);
        
        
        var response = JsonConvert.DeserializeObject<Response<UserPurchaseDto>>(json);

        return response.Data;
    }

    public async Task<UserPurchaseDto> GetByID(int ID) {
        var url = $"{_baseURL}{_endpoint}/{ID}";
        var client = new HttpClient();
        var res = await client.GetAsync(url);
        var json = await res.Content.ReadAsStringAsync();
        var response = JsonConvert.DeserializeObject<Response<UserPurchaseDto>>(json);

        return response.Data;
    }
}