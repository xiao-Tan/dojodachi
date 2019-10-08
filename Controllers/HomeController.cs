using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dojodachi.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;

namespace Dojodachi.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            Pet dojodachi = new Pet();
            HttpContext.Session.SetObjectAsJson("Pet",dojodachi);
            return View(dojodachi);
        }

        [HttpGet("feed")]
        public IActionResult Feed()
        {
            Pet retrieve = HttpContext.Session.GetObjectFromJson<Pet>("Pet");
            int gainFullness = retrieve.Feed();
            HttpContext.Session.SetObjectAsJson("Pet",retrieve);
            ViewBag.info = $"You feed your Dojodachi!!! Meal -1, Fullness +{gainFullness}";
            return View("Index", retrieve);
        }

        [HttpGet("play")]
        public IActionResult Play()
        {
            Pet retrieve = HttpContext.Session.GetObjectFromJson<Pet>("Pet");
            int gainHappiness = retrieve.Play();
            HttpContext.Session.SetObjectAsJson("Pet",retrieve);
            ViewBag.info = $"You played with your Dojodachi!!! Energy -5, Happiness +{gainHappiness}";
            return View("Index", retrieve);
        }

        [HttpGet("work")]
        public IActionResult Work()
        {
            Pet retrieve = HttpContext.Session.GetObjectFromJson<Pet>("Pet");
            int gainMeal = retrieve.Work();
            HttpContext.Session.SetObjectAsJson("Pet",retrieve);
            ViewBag.info = $"Your Dojodachi worked !!! Energy -5, Meal +{gainMeal}";
            return View("Index", retrieve);
        }

        [HttpGet("sleep")]
        public IActionResult Sleep()
        {
            Pet retrieve = HttpContext.Session.GetObjectFromJson<Pet>("Pet");
            retrieve.Sleep();
            HttpContext.Session.SetObjectAsJson("Pet",retrieve);
            ViewBag.info = $"Your Dojodachi is sleeping !!! Energy +15, Fullness -5, Happiness -5";
            return View("Index", retrieve);
        }

        [HttpGet("restart")]
        public IActionResult Restart()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }

    public static class SessionExtensions
    {
        public static void SetObjectAsJson(this ISession session, string key, object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static T GetObjectFromJson<T>(this ISession session, string key)
        {
            string value = session.GetString(key);
            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }
    }
}
