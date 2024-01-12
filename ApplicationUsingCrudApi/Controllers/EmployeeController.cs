using ApplicationUsingCrudApi.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace ApplicationUsingCrudApi.Controllers
{
    public class EmployeeController : Controller
    {
        private string url = "https://localhost:44347/api/Employees/";
        private HttpClient client = new HttpClient();

        [HttpGet]
        public IActionResult Index()
        {
            List<Employee> employees = new List<Employee>();
            HttpResponseMessage response = client.GetAsync(url).Result;
            if(response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<List<Employee>>(result);
                if(data != null)
                {
                    employees = data;
                }
            }
            return View(employees);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Create(Employee emp)
        {
            string data = JsonConvert.SerializeObject(emp);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(url, content).Result;
            if(response.IsSuccessStatusCode)
            {
                TempData["success_msg"] = "Employee Addedd Successfully!";
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Employee emp = new Employee();
            HttpResponseMessage response = client.GetAsync(url + id).Result;
            if(response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<Employee>(result);
                if (data != null)
                {
                    emp = data;
                }
            }
            return View(emp);
        }

        [HttpPost]
        public IActionResult Edit(Employee emp)
        {
            string data = JsonConvert.SerializeObject(emp);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PutAsync(url + emp.id, content).Result;
            if (response.IsSuccessStatusCode)
            {
                TempData["success_msg"] = "Employee Updated Successfully!";
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            Employee emp = new Employee();
            HttpResponseMessage response = client.GetAsync(url + id).Result;
            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<Employee>(result);
                if (data != null)
                {
                    emp = data;
                }
            }
            return View(emp);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Employee emp = new Employee();
            HttpResponseMessage response = client.GetAsync(url + id).Result;
            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<Employee>(result);
                if (data != null)
                {
                    emp = data;
                }
            }
            return View(emp);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteDone(int id)
        {       
            HttpResponseMessage response = client.DeleteAsync(url + id).Result;
            if (response.IsSuccessStatusCode)
            {
                TempData["success_msg"] = "Employee Deleted from Records Successfully!";
                return RedirectToAction("Index");
            }
            return View();
        }

    }
}
