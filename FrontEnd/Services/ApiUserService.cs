using Frontend.Models;
using FrontEnd.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace FrontEnd.Services
{
    public class ApiUserService
    {
        private readonly HttpClient _httpClient;
        private string _ApiURLPath = "http://localhost:5087/"; /* "http://mpiscicelli-001-site2.stempurl.com/"*/

        public ApiUserService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(_ApiURLPath);
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<LoginResponseDTO> AuthenticateUser(LoginRequestDTO userDetails)
        {
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync<LoginRequestDTO>($"api/Usuario/UserLogin", userDetails);
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsStringAsync();
            var APIResponse=JsonConvert.DeserializeObject<LoginResponseDTO>(contents);
            return APIResponse;

        }

        public async Task<Usuario> AddUser(LoginRequestDTO usuario)
        {
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync<LoginRequestDTO>($"api/Usuario/AddUser", usuario);
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsStringAsync();
            var APIResponse = JsonConvert.DeserializeObject<Usuario>(contents);
            return APIResponse;

        }


        //public bool CambiarClave(int idusuario, string nuevaclave, out string Mensaje)
        //{
           
        //    return objCapaDato.CambiarClave(idusuario, nuevaclave, out Mensaje);
        //}

        //public bool ReestablecerClave(long idusuario, string correo, out string Mensaje)
        //{
           
        //}
    }
}
