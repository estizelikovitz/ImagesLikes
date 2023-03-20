using _4_06hwWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using _4_06hmwk;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace _4_06hwWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration _configuration;
        private IWebHostEnvironment _environment;

        public HomeController(IConfiguration configuration, IWebHostEnvironment environment)
        {
            _configuration = configuration;
            _environment = environment;

        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetAll()
        {
            var connectionString = _configuration.GetConnectionString("ConStr");
            var repo = new ImagesRepository(connectionString);

            List<Image> images = repo.GetAll();
            
            return Json(images);

        }
        public ActionResult Upload()
        {
            return View();
        }

        //[HttpPost]
        //public ActionResult Upload(Image image)
        //{
        //    var connectionString = _configuration.GetConnectionString("ConStr");
        //    var repo = new ImagesRepository(connectionString);
        //    repo.Add(image);
        //    return Redirect("/home/index");
        //}
        [HttpPost]
        public ActionResult Upload(string title, IFormFile imageFile)
        {
            Image image = new();
            image.Title = title;
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(imageFile.FileName)}";
            string fullPath = Path.Combine(_environment.WebRootPath, "uploads", fileName);
            using var stream = new FileStream(fullPath, FileMode.CreateNew);
            imageFile.CopyTo(stream);
            image.ImageSource = fileName;
            var connectionString = _configuration.GetConnectionString("ConStr");
            var repo = new ImagesRepository(connectionString);
            image.DateCreated = DateTime.Now.Date;
            repo.Add(image);
            return Redirect("/");
        }
        [HttpPost]
        public void Likes(int id)

        {

            var cookie = Request.Cookies["was-here"];
            if (cookie != null)
            {
                return;
            }
            var connectionString = _configuration.GetConnectionString("ConStr");
            var repo = new ImagesRepository(connectionString);
            Image img=repo.GetById(id);
            img.Likes++;
            repo.Update(img);
            Response.Cookies.Append("was-here", id.ToString());

        }
        public string GetLikes(int id)
        {
            var connectionString = _configuration.GetConnectionString("ConStr");
            var repo = new ImagesRepository(connectionString);
            return repo.GetById(id).Likes.ToString();
        }

        public IActionResult ViewImage(int id)
        {
            var connectionString = _configuration.GetConnectionString("ConStr");
            var repo = new ImagesRepository(connectionString);
            Image img=repo.GetById(id);
            return View(img);
        }

    }
}
