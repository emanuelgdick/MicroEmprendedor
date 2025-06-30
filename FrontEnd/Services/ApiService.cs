using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Web.Mvc;
using Frontend.Models;
using FrontEnd.Models;
using FrontEnd.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using static FrontEnd.Controllers.ConsultaController;
namespace FrontEnd.Services
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;
        private string _ApiURLPath = "http://localhost:5087/";

        public ApiService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(_ApiURLPath);
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
         
        }

        //LOCALIDAD
        #region
        public async Task<List<Localidad>> GetAllLocalidades(string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.GetAsync($"api/Localidad?");
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsStringAsync();
            var APIResponse = JsonConvert.DeserializeObject<List<Localidad>>(contents);
            return APIResponse;
        }

        public async Task<Localidad> AddLocalidad(Localidad localidad, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync<Localidad>($"api/Localidad/AddLocalidad", localidad);
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsStringAsync();
            var APIResponse = JsonConvert.DeserializeObject<Localidad>(contents);
            return APIResponse;
        }

        public async Task<Localidad> GetLocalidadById(int id, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.GetAsync($"api/Localidad/GetLocalidadById?id={id}");
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsStringAsync();
            var APIResponse = JsonConvert.DeserializeObject<Localidad>(contents);
            return APIResponse;
        }

        public async Task UpdateLocalidad(int id, Localidad localidad, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync<Localidad>($"api/Localidad/UpdateLocalidad?id={id}", localidad);
            response.EnsureSuccessStatusCode();

        }

        public async Task DeleteLocalidad(int id, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.PutAsync($"api/Localidad/DeleteLocalidad?id={id}", null);
            response.EnsureSuccessStatusCode();
        }

        #endregion

        //DIAGNOSTICO
        #region
        public async Task<List<Diagnostico>> GetAllDiagnosticos(string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.GetAsync($"api/Diagnostico?");
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsStringAsync();
            var APIResponse = JsonConvert.DeserializeObject<List<Diagnostico>>(contents);
            return APIResponse;
        }

        public async Task<Diagnostico> AddDiagnostico(Diagnostico diagnostico, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync<Diagnostico>($"api/Diagnostico/AddDiagnostico", diagnostico);
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsStringAsync();
            var APIResponse = JsonConvert.DeserializeObject<Diagnostico>(contents);
            return APIResponse;
        }

        public async Task<Diagnostico> GetDiagnosticoById(int id, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.GetAsync($"api/Diagnostico/GetDiagnosticoById?id={id}");
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsStringAsync();
            var APIResponse = JsonConvert.DeserializeObject<Diagnostico>(contents);
            return APIResponse;
        }

        public async Task UpdateDiagnostico(int id, Diagnostico diagnostico, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync<Diagnostico>($"api/Diagnostico/UpdateDiagnostico?id={id}", diagnostico);
            response.EnsureSuccessStatusCode();

        }

        public async Task DeleteDiagnostico(int id, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.PutAsync($"api/Diagnostico/DeleteDiagnostico?id={id}", null);
            response.EnsureSuccessStatusCode();
        }

        #endregion

        //MEDICO
        #region
        public async Task<List<Medico>> GetAllMedicos(string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.GetAsync($"api/Medico?");
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsStringAsync();
            var APIResponse = JsonConvert.DeserializeObject<List<Medico>>(contents);
            return APIResponse;
        }

        public async Task<List<Medico>> GetMedicosConAgenda(string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.GetAsync($"api/Medico/GetMedicosConAgenda?");
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsStringAsync();
            var APIResponse = JsonConvert.DeserializeObject<List<Medico>>(contents);
            return APIResponse;
        }

        public async Task<Medico> AddMedico(Medico medico, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync<Medico>($"api/Medico/AddMedico", medico);
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsStringAsync();
            var APIResponse = JsonConvert.DeserializeObject<Medico>(contents);
            return APIResponse;
        }

        public async Task<Medico> GetMedicoById(int id, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.GetAsync($"api/Medico/GetMedicoById?id={id}");
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsStringAsync();
            var APIResponse = JsonConvert.DeserializeObject<Medico>(contents);
            return APIResponse;
        }

        public async Task UpdateMedico(int id, Medico medico, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync<Medico>($"api/Medico/UpdateMedico?id={id}", medico);
            response.EnsureSuccessStatusCode();

        }

        public async Task DeleteMedico(int id, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.PutAsync($"api/Medico/DeleteMedico?id={id}", null);
            response.EnsureSuccessStatusCode();
        }

        #endregion

        //MUTUAL
        #region
        public async Task<List<Mutual>> GetAllMutuales(string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.GetAsync($"api/Mutual?");
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsStringAsync();
            var APIResponse = JsonConvert.DeserializeObject<List<Mutual>>(contents);
            return APIResponse;
        }

        public async Task<Mutual> AddMutual(Mutual mutual, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync<Mutual>($"api/Mutual/AddMutual", mutual);
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsStringAsync();
            var APIResponse = JsonConvert.DeserializeObject<Mutual>(contents);
            return APIResponse;
        }

        public async Task<Mutual> GetMutualById(int id, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.GetAsync($"api/Mutual/GetMutualById?id={id}");
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsStringAsync();
            var APIResponse = JsonConvert.DeserializeObject<Mutual>(contents);
            return APIResponse;
        }

        public async Task UpdateMutual(int id, Mutual mutual, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync<Mutual>($"api/Mutual/UpdateMutual?id={id}", mutual);
            response.EnsureSuccessStatusCode();

        }

        public async Task DeleteMutual(int id, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.PutAsync($"api/Mutual/DeleteMutual?id={id}", null);
            response.EnsureSuccessStatusCode();
        }

        #endregion

        //PROFESION
        #region
        public async Task<List<Profesion>> GetAllProfesiones(string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.GetAsync($"api/Profesion?");
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsStringAsync();
            var APIResponse = JsonConvert.DeserializeObject<List<Profesion>>(contents);
            return APIResponse;
        }

        public async Task<Profesion> AddProfesion(Profesion profesion, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync<Profesion>($"api/Profesion/AddProfesion", profesion);
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsStringAsync();
            var APIResponse = JsonConvert.DeserializeObject<Profesion>(contents);
            return APIResponse;
        }

        public async Task<Profesion> GetProfesionById(int id, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.GetAsync($"api/Profesion/GetProfesionById?id={id}");
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsStringAsync();
            var APIResponse = JsonConvert.DeserializeObject<Profesion>(contents);
            return APIResponse;
        }

        public async Task UpdateProfesion(int id, Profesion profesion, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync<Profesion>($"api/Profesion/UpdateProfesion?id={id}", profesion);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteProfesion(int id, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.PutAsync($"api/Profesion/DeleteProfesion?id={id}", null);
            response.EnsureSuccessStatusCode();
        }

        #endregion

        //PACIENTES
        #region
        public async Task<List<Paciente>> GetAllPacientes(string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.GetAsync($"api/Paciente?");
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsStringAsync();
            //ILogger<ApiService> logger
            //_logger = logger;

            var APIResponse = JsonConvert.DeserializeObject<List<Paciente>>(contents);
            return APIResponse;
        }

        public async Task<List<Paciente>> GetPacientesFiltrados(int localidad, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.GetAsync($"api/Paciente/GetPacientesFiltrados?localidad={localidad}");
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsStringAsync();
            var APIResponse = JsonConvert.DeserializeObject<List<Paciente>>(contents);
            return APIResponse;
        }

        public async Task<Paciente> AddPaciente(Paciente Paciente, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync<Paciente>($"api/Paciente/AddPaciente", Paciente);
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsStringAsync();
            var APIResponse = JsonConvert.DeserializeObject<Paciente>(contents);
            return APIResponse;
        }

        public async Task<Paciente> GetPacienteById(int id, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.GetAsync($"api/Paciente/GetPacienteById?id={id}");
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsStringAsync();
            var APIResponse = JsonConvert.DeserializeObject<Paciente>(contents);
            return APIResponse;
        }

        public async Task UpdatePaciente(int id, Paciente paciente, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync<Paciente>($"api/Paciente/UpdatePaciente?id={id}", paciente);
            response.EnsureSuccessStatusCode();

        }

        public async Task DeletePaciente(int id, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.PutAsync($"api/Paciente/DeletePaciente?id={id}", null);
            response.EnsureSuccessStatusCode();

        }

        #endregion

        //TIPO DE DOCUMENTO
        #region
        public async Task<List<TipoDocumento>> GetAllTipoDocumentos(string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.GetAsync($"api/TipoDocumento?");
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsStringAsync();
            var APIResponse = JsonConvert.DeserializeObject<List<TipoDocumento>>(contents);
            return APIResponse;
        }

        public async Task<TipoDocumento> AddTipoDocumento(TipoDocumento tipoDocumento, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync<TipoDocumento>($"api/TipoDocumento/AddTipoDocumento", tipoDocumento);
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsStringAsync();
            var APIResponse = JsonConvert.DeserializeObject<TipoDocumento>(contents);
            return APIResponse;
        }

        public async Task<TipoDocumento> GetTipoDocumentoById(int id, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.GetAsync($"api/TipoDocumento/GetTipoDocumentoById?id={id}");
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsStringAsync();
            var APIResponse = JsonConvert.DeserializeObject<TipoDocumento>(contents);
            return APIResponse;
        }

        public async Task UpdateTipoDocumento(int id, TipoDocumento tipoDocumento, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync<TipoDocumento>($"api/TipoDocumento/UpdateTipoDocumento?id={id}", tipoDocumento);
            response.EnsureSuccessStatusCode();

        }

        public async Task DeleteTipoDocumento(int id, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.PutAsync($"api/TipoDocumento/DeleteTipoDocumento?id={id}", null);
            response.EnsureSuccessStatusCode();

        }

        #endregion

        //EVENTS
        #region

        public async Task<List<Consulta>> GetAllConsulta(string token, string start, string end)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.GetAsync($"api/Consulta?start={start}&end={end}");
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsStringAsync();
            var APIResponse = JsonConvert.DeserializeObject<List<Consulta>>(contents);
            return APIResponse;
        }

        public async Task<List<Consulta>> GetAllConsultaByMedico(string token, string start, string end, int idMedico)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.GetAsync($"api/Consulta/GetEventsByMedico?start={start}&end={end}&idMedico={idMedico}");
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsStringAsync();
            var APIResponse = JsonConvert.DeserializeObject<List<Consulta>>(contents);
            return APIResponse;
        }

        public async Task<List<Consulta>> GetEventsByFecha(string token)
        {
            string start =DateTime.Now.ToString();
            DateTime end = DateTime.Now;
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.GetAsync($"api/Consulta/GetEventsByFecha?start={start}");
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsStringAsync();
            var APIResponse = JsonConvert.DeserializeObject<List<Consulta>>(contents);
            return APIResponse;
        }

        public async Task<Consulta> AddConsulta(Consulta C, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync<Consulta>($"api/Consulta/PostEvent", C);
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsStringAsync();
            var APIResponse = JsonConvert.DeserializeObject<Consulta>(contents);
            return APIResponse;
        }

        public async Task<Consulta> MoveConsulta(int id, string token, Consulta C)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.PutAsJsonAsync<Consulta>($"api/Consulta/{id}/move",C);
                                                                                       
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsStringAsync();
            var APIResponse = JsonConvert.DeserializeObject<Consulta>(contents);
            return APIResponse;
        }


        public async Task<Consulta> ChangeColor( string token, Consulta p)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.PutAsJsonAsync<Consulta>($"api/Consulta/{p.Id}/color", p);

            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsStringAsync();
            var APIResponse = JsonConvert.DeserializeObject<Consulta>(contents);
            return APIResponse;
        }

        public async Task<Consulta> GetEventById(int id, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.GetAsync($"api/Consulta/GetEventById?id={id}");
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsStringAsync();
            var APIResponse = JsonConvert.DeserializeObject<Consulta>(contents);
            return APIResponse;
        }

        public async Task UpdateConsulta(int id, Consulta c, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.PutAsJsonAsync<Consulta>($"api/Consulta/{c.Id}/UpdateConsulta", c);
            response.EnsureSuccessStatusCode();

        }

        public async Task DeleteEvent(int id, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            //HttpResponseMessage response = await _httpClient.DeleteAsync($"api/Consulta/DeleteEvent/{id}");
            HttpResponseMessage response = await _httpClient.PutAsync($"api/Consulta/DeleteEvent?id={id}", null);
            response.EnsureSuccessStatusCode();

        }

        #endregion

        //TOTALES
        public async Task<Models.DTOs.TotalesDTO> GetTotales(int id,string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.GetAsync($"api/Home?id={id}");
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsStringAsync();
            var APIResponse = JsonConvert.DeserializeObject<TotalesDTO>(contents);
            return APIResponse;
        }

    }
}
