using CandidatesManager.Common;
using CandidatesManager.Data;
using CandidatesManager.Models;
using CandidatesManager.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesManager.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            this._context = context;
        }

        public IActionResult Index(string sortOrder)
        {
            var candidates = this._context.Candidates
                .Select(c => new CandidateHomePageViewModel
                {
                    Id = c.Id,
                    FirstName = NameParser.ParseCandidateName(c.Name)[0],
                    MiddleInitial = NameParser.GetMiddleInitial(NameParser.ParseCandidateName(c.Name)[1]),
                    LastName = NameParser.ParseCandidateName(c.Name)[2],
                    Number = c.Number,
                    Birthdate = c.Birthdate.Date.ToString("dd.MM.yyyy"),
                    Score = c.Score,
                    Department = c.Department.ToString(),
                    Education = c.Education,
                    Code = c.Code
                });

            ViewData["NumberSortParam"] = String.IsNullOrEmpty(sortOrder) ? "numberDesc" : "";
            ViewData["ScoreSortParam"] = sortOrder == "Score" ? "scoreDesc" : "Score";
            
            switch (sortOrder)
            {
                case "numberDesc":
                    {
                        candidates = candidates.OrderByDescending(c => c.Number);
                        break;
                    }

                case "scoreDesc":
                    {
                        candidates = candidates.OrderByDescending(c => c.Score);
                        break;
                    }

                case "Score":
                    {
                        candidates = candidates.OrderBy(c => c.Score);
                        break;
                    }

                default:
                    {
                        candidates = candidates.OrderBy(c => c.Number);
                        break;
                    }
            }
            

            return View(candidates);
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
