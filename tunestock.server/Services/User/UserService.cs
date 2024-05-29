using tunestock.api.dto;
using tunestock.core.http;
using Newtonsoft.Json;
using System.Text;
using tunestock.api.services.interfaces;


namespace tunestock.server.Services.User
{
    public class UserService : IUserService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseURL = "https://localhost:7000/";
        private readonly string _endpoint = "api/User";

        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Response<List<UserDto>>> GetAllAsync()
        {
            var url = $"{_baseURL}{_endpoint}";
            var res = await _httpClient.GetAsync(url);
            var json = await res.Content.ReadAsStringAsync();

            var response = JsonConvert.DeserializeObject<Response<List<UserDto>>>(json);

            return response;
        }

        public async Task<Response<UserDto>> GeyByID(int id)
        {
            var url = $"{_baseURL}{_endpoint}/{id}";
            var res = await _httpClient.GetAsync(url);
            var json = await res.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<Response<UserDto>>(json);

            return response;
        }

        public async Task<Response<UserDto>> SaveAsync(UserDto userDto)
        {
            var url = $"{_baseURL}{_endpoint}";
            var jsonRequest = JsonConvert.SerializeObject(userDto);
            var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
            var res = await _httpClient.PostAsync(url, content);
            var json = await res.Content.ReadAsStringAsync();

            var response = JsonConvert.DeserializeObject<Response<UserDto>>(json);

            return response;
        }

        public async Task<Response<UserDto>> UpdateAsync(UserDto userDto)
        {
            var url = $"{_baseURL}{_endpoint}";
            var jsonRequest = JsonConvert.SerializeObject(userDto);
            var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
            var res = await _httpClient.PutAsync(url, content);
            var json = await res.Content.ReadAsStringAsync();

            var response = JsonConvert.DeserializeObject<Response<UserDto>>(json);

            return response;
        }

        public async Task<Response<bool>> DeleteAsync(int id)
        {
            var url = $"{_baseURL}{_endpoint}/{id}";
            var res = await _httpClient.DeleteAsync(url);
            var json = await res.Content.ReadAsStringAsync();

            var response = JsonConvert.DeserializeObject<Response<bool>>(json);

            return response;
        }

        public async Task<Response<bool>> Login(UserDto userDto)
        {
            var url = $"{_baseURL}{_endpoint}/login";
            var jsonRequest = JsonConvert.SerializeObject(userDto);
            var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
            var res = await _httpClient.PostAsync(url, content);
            var json = await res.Content.ReadAsStringAsync();

            var response = JsonConvert.DeserializeObject<Response<bool>>(json);

            return response;
        }

        public async Task<Response<core.entities.User>> GetByEmail(UserDto userDto)
        {
            var url = $"{_baseURL}{_endpoint}/byemail/{userDto.Email}";
            var res = await _httpClient.GetAsync(url);
            var json = await res.Content.ReadAsStringAsync();

            var response = JsonConvert.DeserializeObject<Response<core.entities.User>>(json);

            return response;
        }
    }
}
