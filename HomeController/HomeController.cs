using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace RandomPasscode.Controllers
{
    
    public class HomeController: Controller{
        Random rnd = new Random();
        public const string Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        [HttpGet]
        [Route("")]
        public IActionResult Index(){
            string newPw = "";
            
            for(int i= 0; i < 14; i++){
                newPw += Alphabet[rnd.Next(Alphabet.Length)];
            }
            HttpContext.Session.SetString("Password", newPw);
            int count = HttpContext.Session.GetInt32("Count")?? 0;
            HttpContext.Session.SetInt32("Count", count+1);
            ViewBag.Password = HttpContext.Session.GetString("Password");
            ViewBag.Count = HttpContext.Session.GetInt32("Count");
            return View("Index");
        }


        [HttpGet]
        [Route("/generate")]
        public IActionResult Generate(){
            string newPw = "";
            
            for(int i= 0; i < 14; i++){
                newPw += Alphabet[rnd.Next(Alphabet.Length)];
            }
            HttpContext.Session.SetString("Password", newPw);
            int count = HttpContext.Session.GetInt32("Count")?? 0;
            HttpContext.Session.SetInt32("Count", count+1);
            ViewBag.Password = HttpContext.Session.GetString("Password");
            ViewBag.Count = HttpContext.Session.GetInt32("Count");

            var AnonObject = new {
                                Password = HttpContext.Session.GetString("Password"),
                                Count = HttpContext.Session.GetInt32("Count")
                            };
            return Json(AnonObject);
        }

        //When the request handled by form 

        // [HttpPost]
        // [Route("process")]
        // public IActionResult Process(){
        //     return RedirectToAction("Index");
        // }
    }
}
