using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using NamestoJsonMvc.Models;
using Newtonsoft.Json;

namespace NamestoJsonMvc.Controllers
{
    public class NamestoJsonController : Controller
    {
        public static IConfiguration Configuration { get; set; }
        // GET: NamestoJson
        public new ActionResult User()
        {
            return View();
        }
        public ActionResult Save(User user)
        {
            ResponseModel responseModel = null;
            try
            {
                var path = Path.GetTempPath() + "NamestoJson.txt";
                using (StreamWriter file = System.IO.File.CreateText(path))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(file, user);
                }
                responseModel = new ResponseModel { Message = "File Saved successfully at  " + path };
              
            }
            catch (Exception ex)
            {
                responseModel = new ResponseModel
                {
                    Message = "Failed to Save. Reason -->  " + ex.Message
                };
            }
            return View("Response", responseModel);
        }

    }
}