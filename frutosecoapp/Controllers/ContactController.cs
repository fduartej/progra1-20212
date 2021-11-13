using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using frutosecoapp.Models;
using frutosecoapp.Data;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Text;

namespace frutosecoapp.Controllers
{
    public class ContactController:Controller
    {
        private readonly ApplicationDbContext _context;
        private const string URL_API_SPOTIFY = "https://api.sendgrid.com/v3/mail/send";
        private string ACCESS_TOKEN ="";


        public ContactController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            
            return View(_context.DataContactos.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Contact objContacto)
        {
            _context.Add(objContacto);
            _context.SaveChanges();
            ViewData["Message"] = "El contacto ya esta registrado";
            // ENVIO DE CORREO
            ACCESS_TOKEN = System.Environment.GetEnvironmentVariables()["SENDGRID_KEY"].ToString();

            Console.WriteLine( " token :" + ACCESS_TOKEN);
            
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.BaseAddress = new Uri(URL_API_SPOTIFY);
             httpClient.DefaultRequestHeaders.Authorization = 
                new AuthenticationHeaderValue("Bearer", ACCESS_TOKEN);
  
            var jsonObject = new StringBuilder();
            jsonObject.Append("{");
            jsonObject.Append("'categories': [");
            jsonObject.Append("'demo' ");
            jsonObject.Append("],");
            jsonObject.Append("'from': {");
            jsonObject.Append("'email': 'fduartej@usmp.pe',"); 
            jsonObject.Append("'name': 'Frederick '");
            jsonObject.Append("},");
            jsonObject.Append("'personalizations': [");
            jsonObject.Append("{");
            jsonObject.Append("      'to': [");
            jsonObject.Append("        {");
            jsonObject.Append("'email': '"+objContacto.Email+"',");
            jsonObject.Append("'name': 'Fred D' ");
            jsonObject.Append("}");
            jsonObject.Append("],");
            jsonObject.Append("'subject': 'Hola' ");
            jsonObject.Append("}");
            jsonObject.Append("],");
            jsonObject.Append("'content': [");
            jsonObject.Append("{");
            jsonObject.Append("'type': 'text/plain',");
            jsonObject.Append("'value': 'Hola ahora ya uso sendgrid!' ");
            jsonObject.Append("}");
            jsonObject.Append("],  ");
            jsonObject.Append("}");

            
            var content = new StringContent(jsonObject.ToString(), Encoding.UTF8, "application/json");
            var result = await httpClient.PostAsync(URL_API_SPOTIFY, content);

            return View();
        }

        
        public IActionResult Edit(int id)
        {
            Contact objContacto = _context.DataContactos.Find(id);
            if(objContacto == null){
                return NotFound();
            }
            return View(objContacto);
        }

        [HttpPost]
        public IActionResult Edit(int id,[Bind("Id,Name,Email,Comment,Phone")] Contact objContacto)
        {
             _context.Update(objContacto);
             _context.SaveChanges();
              ViewData["Message"] = "El contacto ya esta actualizado";
             return View(objContacto);
        }

        public IActionResult Delete(int id)
        {
            Contact objContacto = _context.DataContactos.Find(id);
            _context.DataContactos.Remove(objContacto);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}