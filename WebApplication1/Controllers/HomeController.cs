using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult TextFiles()
        {
            ViewBag.Message = "TextFiles";
            string[] files = Directory.GetFiles(Server.MapPath("~/TextFiles"));
            FileList Files = new FileList();


            foreach (var file in files)
            {
                
                var fn = Path.GetFileNameWithoutExtension(file);
                Match match = Regex.Match(fn, @"(\d+)");
                var number = int.Parse(match.Groups[1].Value);
                var f = new Model.File {
                    Text = file,
                    RelativePath = "/TextFiles/" + fn,
                    FileName = fn,
                    Url = "./TextFile/" + fn,
                    Number = number
            };
                Files.Add(f);
            }

            return View(Files);
        }

        public ActionResult TextFile(string name)
        {

            var files = Directory.GetFiles(Server.MapPath("~/TextFiles"), String.Format("*{0}.txt", name));
            var file = files[0];
            var f = new Model.File
            {
                Content = System.IO.File.ReadAllText(file),
                FileName = Path.GetFileName(file)
            };
            return View(f);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}