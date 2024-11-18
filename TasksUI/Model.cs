using Microsoft.AspNetCore.Mvc;
using TasksUI.Pages;
using Newtonsoft.Json;

namespace TasksUI
{
    public class Model
    {
        private readonly ILogger<Model> _logger;

        public Model(ILogger<Model> logger)
        {
            _logger = logger; 
        }

        public async Task<JsonResult> OnGetIncidentsAsync()
        {
            List<TaskModel> incidents = new List<TaskModel>();
            using (var httpClient = new HttpClient())
            {
                using (HttpResponseMessage response = await httpClient.GetAsync("https://localhost:44393/api/Task"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    incidents = JsonConvert.DeserializeObject<List<TaskModel>>(apiResponse);
                }
            }
            return new JsonResult(incidents);
        }
    }
}
