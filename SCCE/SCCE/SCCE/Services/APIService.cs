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
        private List<ObjetoFuncionalModel> _objetosFuncional;
        private List<ObjetoSerialModel> _objetosSerial;
        private List<DadosTecnicosModel> _dadosTecnicos;
        public int[] sites = { 15, 20, 25, 30, 35, 40, 45, 50, 55, 60, 65};

        public async Task<List<RegionalModel>> GetRegionaisAsync()
        {
            try
            {
                string url = string.Format("http://webservicedourados.sanesul.ms.gov.br/webservicedourados.asmx/ListRegionais?");
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
        public async Task<List<ObjetoFuncionalModel>> GetObjetosFuncionalAsync(int site)
        {
            try
            {
                string url = string.Format("http://webservicedourados.sanesul.ms.gov.br/webservicedourados.asmx/ListObjFuncionais?site=" + site);
                var response = await _client.GetAsync(url);

                if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    _objetosFuncional = new List<ObjetoFuncionalModel>();
                }
                else
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var localidades = JsonConvert.DeserializeObject<List<ObjetoFuncionalModel>>(content);
                    _objetosFuncional = new List<ObjetoFuncionalModel>(localidades);
                }
                return _objetosFuncional;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<ObjetoSerialModel>> GetObjetosSerialAsync()
        {
            try
            {
                _objetosSerial = new List<ObjetoSerialModel>();
                foreach (int i in sites)
                {
                    string url = string.Format("http://webservicedourados.sanesul.ms.gov.br/webservicedourados.asmx/ListObjSeriais?site=" + i);
                    var response = await _client.GetAsync(url);
                    if (response.StatusCode == HttpStatusCode.NotFound)
                    {
                        _objetosSerial = null;
                        break;
                    }
                    else
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        var obj = JsonConvert.DeserializeObject<List<ObjetoSerialModel>>(content);
                        _objetosSerial.AddRange(obj);
                    }

                }
                return _objetosSerial;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<DadosTecnicosModel>> GetDadosTecnicosAsync()
        {
            try
            {
                _dadosTecnicos = new List<DadosTecnicosModel>();
                foreach(int i in sites)
                {
                    string url = string.Format("http://webservicedourados.sanesul.ms.gov.br/webservicedourados.asmx/ListObjSeriaisDadosTecnicos?site=" + i);
                    var response = await _client.GetAsync(url);
                    if (response.StatusCode == HttpStatusCode.NotFound)
                    {
                        _dadosTecnicos = null;
                        break;
                    }
                    else
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        var obj = JsonConvert.DeserializeObject<List<DadosTecnicosModel>>(content);
                        _dadosTecnicos.AddRange(obj);
                    }

                }

                return _dadosTecnicos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
