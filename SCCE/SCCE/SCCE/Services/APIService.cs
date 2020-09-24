using Newtonsoft.Json;
using SCCE.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace SCCE.Services
{
    public class APIService
    {
        private readonly HttpClient _client = new HttpClient();
        private List<RegionalModel> _regionais;
        private List<LocalidadeModel> _localidades;
        private List<ProcessosModel> _processos;


        public async Task<List<RegionalModel>> GetRegionaisAsync()
        {
            try
            {
                string url = string.Format("http://coredata.sanesul.ms.gov.br/api/regionais");
                var response = await _client.GetAsync(url);

                if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    _regionais = new List<RegionalModel>();
                }
                else
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var regionais = JsonConvert.DeserializeObject<List<RegionalModel>>(content);
                    _regionais = new List<RegionalModel>(regionais);
                }
                return _regionais;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<LocalidadeModel>> GetLocalidadesAsync()
        {
            try
            {
                string url = string.Format("http://coredata.sanesul.ms.gov.br/api/localidades/");
                var response = await _client.GetAsync(url);

                if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    _localidades = new List<LocalidadeModel>();
                }
                else
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var localidades = JsonConvert.DeserializeObject<List<LocalidadeModel>>(content);
                    _localidades = new List<LocalidadeModel>(localidades);
                }
                return _localidades;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<ProcessosModel>> GetProcessosAsync(int _id)
        {
            try
            {
                string url = string.Format("http://scpo.sanesul.ms.gov.br/api/processos/"+_id+"/agua");
                var response = await _client.GetAsync(url);

                if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    _processos = new List<ProcessosModel>();
                }
                else
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var processos = JsonConvert.DeserializeObject<List<ProcessosModel>>(content);
                    _processos = new List<ProcessosModel>(processos);
                }
                return _processos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
