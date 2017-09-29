using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace FirebaseXamarinForms
{
    class RestService: IRestService
    {

        string urlapi = "http://192.168.0.8/MaxTrackAPI/api/";
        HttpClient client = new HttpClient();
        public async Task<List<Employees>> RefreshDataAsync()
        {
  
            client.BaseAddress = new Uri(urlapi);
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
            var response = client.GetAsync("OperacionCharts/ConsultaEmpleados").Result;
            List<Employees> Items=null;
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                Items = JsonConvert.DeserializeObject<List<Employees>>(content);
            }
            return Items;
        }
        async Task<List<Employees>> IRestService.ConsultaEmpleados()
        {
            try
            {

                client.BaseAddress = new Uri(urlapi);
                client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync("OperacionCharts/ConsultaEmpleados").Result;
                string content = await response.Content.ReadAsStringAsync();
                var list = JsonConvert.DeserializeObject<List<Employees>>(content).ToList();
                return list;
            }
            catch (Exception ex)
            {
                var t = ex.Message;
            }
            return null;
        }
    }
}
