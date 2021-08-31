using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using YY_Model;

namespace YY_NpoiExportAndImport.Controllers
{
    public class SwaggerApiController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        
        [HttpGet]
        public  string   QueryHouseCentersByOwnerMember(string searchTerm)
        {
            string address = "http://121.199.5.186:8081/api/";
            HttpClientHandler handler = new HttpClientHandler();
            HttpClient httpClient = new HttpClient(handler);

            httpClient.BaseAddress = new Uri(address);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            string action = "Json/";
            string msg = "";
            StringContent content
                    = new StringContent (searchTerm, UnicodeEncoding.UTF8, "application/json");
            //var company =RepositoryFactory.EntityRepositoryService.Companies.GetFirst(1);
            HttpResponseMessage respose = httpClient.PostAsync(action, content).Result;
            if (respose.IsSuccessStatusCode)
            {
                var result = respose.Content.ReadAsStringAsync();//ReadAsAsync<List<UserInfo>>().Result;
                //var result = respose.Content.ReadAsAsync<List<UserInfo>>().Result;
            }
            else
            {
                msg = respose.StatusCode.ToString();
            }

            return msg;
        }
        
    }
}
