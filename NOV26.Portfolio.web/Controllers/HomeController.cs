using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NOV26.Portfolio.web.Data;
using NOV26.Portfolio.web.Migrations;
using NOV26.Portfolio.web.Models;
using System.Diagnostics;

namespace NOV26.Portfolio.web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        Data.NOV26PortfoliowebContext _context;

        public HomeController(ILogger<HomeController> logger, Data.NOV26PortfoliowebContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            /* HARDCODE METHOD FOR RESUME
             
            HomeViewModel model = new HomeViewModel()
            {
                FullName = "Umesh Shrestha",
                Address = "Chabahil, Kathmandu",
                ZipCode = "44600",
                Email = "umeshshresthanp@gmail.com",
                Phone = "+977-9851172217",
                Title = "ASP.NET Developer",
                DOB = new DateTime(1991, 06, 05),
                Summary = "I am Nepal based ASP.NET Developer.",
                CompletedProjects = 25,
                Country = "Nepal"
            };
            */

            /* DYNAMIC METHOD FOR PersonalInformation (GET LSIT FROM DATABSE) */
            HomeViewModel model = new HomeViewModel();
            var personalInfo = _context.PersonalInformationModel.FirstOrDefault();
            model.FullName = personalInfo.FullName;
            model.Address = personalInfo.Address;
            model.ZipCode = personalInfo.ZipCode;
            model.Email = personalInfo.Email;
            model.Phone = personalInfo.Phone;
            model.Title = personalInfo.Title;
            model.DOB = personalInfo.DOB;
            model.Summary   = personalInfo.Summary;
            model.CompletedProjects = personalInfo.CompletedProjects;
            model.Country= personalInfo.Country;
            model.UserPhotoUrl = personalInfo.UserPhotoUrl;


            /* DYNAMIC METHOD FOR RESUME (GET LSIT FROM DATABSE) */
            model.Resumes = _context.ResumeModel.ToList();
            return View(model);

            /* HARDCODE METHOD FOR RESUME
             * 
             model.Resumes = new List<ResumeModel>();
             model.Resumes.Add(new ResumeModel()
             {
                 StartYear = 2012,
                 EndYear = 2014,
                 InstitutionName = "TRIBHUVAN UNIVERSITY",
                 Title = "Masters in Business Administration (MBA)",
                 Description = "A small river named Duden flows by their place and supplies it with the necessary regelialia. It is a paradisematic country, in which roasted parts of sentences fly into your mouth.",

             });
             model.Resumes.Add(new ResumeModel()
             {
                 StartYear = 2021,
                 EndYear = 2023,
                 InstitutionName = "Tribhuwan University",
                 Title = "Bachelor in Business Administration (BBA)",
                 Description = "A small river named Duden flows by their place and supplies it with the necessary regelialia. It is a paradisematic country, in which roasted parts of sentences fly into your mouth.",

             });
             model.Resumes.Add(new ResumeModel()
             {
                 StartYear = 2008,
                 EndYear = 2010,
                 InstitutionName = "HIGHER SECONDARY EDUCATION BOARD",
                 Title = "+2 (HSEB)",
                 Description = "A small river named Duden flows by their place and supplies it with the necessary regelialia. It is a paradisematic country, in which roasted parts of sentences fly into your mouth.",

             });
             model.Resumes.Add(new ResumeModel()
             {
                 StartYear = 2014,
                 EndYear = 2016,
                 InstitutionName = "CAMBRIDGE UNIVERSITY",
                 Title = "Wordpress Developer",
                 Description = "A small river named Duden flows by their place and supplies it with the necessary regelialia. It is a paradisematic country, in which roasted parts of sentences fly into your mouth.",

             });
             model.Resumes.Add(new ResumeModel()
             {
                 StartYear = 2012,
                 EndYear = 2014,
                 InstitutionName = "POKHARA UNIVERSITY",
                 Title = "Diploma in Computer",
                 Description = "A small river named Duden flows by their place and supplies it with the necessary regelialia. It is a paradisematic country, in which roasted parts of sentences fly into your mouth.",

             });
             model.Resumes.Add(new ResumeModel()
             {
                 StartYear = 2012,
                 EndYear = 2014,
                 InstitutionName = "OXFORD UNIVERSITY",
                 Title = "UI/UX Designer",
                 Description = "A small river named Duden flows by their place and supplies it with the necessary regelialia. It is a paradisematic country, in which roasted parts of sentences fly into your mouth.",

             });
             return View(model);
         */
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
