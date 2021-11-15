using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CandidatesManager.Data;
using CandidatesManager.Models;
using CandidatesManager.ViewModels;
using System.Globalization;
using CandidatesManager.Enumerables;
using CandidatesManager.Common;

namespace CandidatesManager.Controllers
{
    public class CandidatesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CandidatesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Candidates
        public async Task<IActionResult> Index()
        {
            return View(await _context.Candidates.ToListAsync());
        }

        // GET: Candidates/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidate = await _context.Candidates
                .FirstOrDefaultAsync(m => m.Id == id);
            if (candidate == null)
            {
                return NotFound();
            }

            return View(candidate);
        }

        // GET: Candidates/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Candidates/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Education,Score,Code")] Candidate candidate)
        {
            /*int lastId = GetLastCandidateId();
            candidate.Code = GenerateCandidateCode(lastId, (int)candidate.Department, candidate.Birthdate);*/

            candidate.Number = GetNumber(candidate.Code);
            candidate.Birthdate = GetDateTime(candidate.Code);
            candidate.Department = GetDepartment(candidate.Code);

            if (ModelState.IsValid)
            {
                _context.Add(candidate);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }

            return View(candidate);
        }

        // GET: Candidates/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidate = await _context.Candidates.FindAsync(id);
            if (candidate == null)
            {
                return NotFound();
            }
            return View(candidate);
        }

        // POST: Candidates/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Education,Score,Code")] Candidate candidate)
        {
            candidate.Number = GetNumber(candidate.Code);
            candidate.Birthdate = GetDateTime(candidate.Code);
            candidate.Department = GetDepartment(candidate.Code);

            if (id != candidate.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(candidate);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CandidateExists(candidate.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index", "Home");
            }
            return View(candidate);
        }

        // GET: Candidates/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidate = await _context.Candidates
                .FirstOrDefaultAsync(m => m.Id == id);
            if (candidate == null)
            {
                return NotFound();
            }

            return View(candidate);
        }

        // POST: Candidates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var candidate = await _context.Candidates.FindAsync(id);
            _context.Candidates.Remove(candidate);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }

        private bool CandidateExists(int id)
        {
            return _context.Candidates.Any(e => e.Id == id);
        }

        public IActionResult CandidatesCK()
        {
            var candidatesCK = this._context.Candidates
                .Where(c => c.Department == Department.CK && c.Birthdate.Year > 1990)
                .Select(c => new CandidateCKViewModel
                {
                    FirstName = NameParser.ParseCandidateName(c.Name)[0],
                    MiddleInitial = NameParser.GetMiddleInitial(NameParser.ParseCandidateName(c.Name)[1]),
                    LastName = NameParser.ParseCandidateName(c.Name)[2],
                    Number = c.Number,
                    Birthdate = c.Birthdate.Date.ToString("dd.MM.yyyy"),
                    Score = c.Score,
                    Department = c.Department.ToString(),
                    Education = c.Education,
                    Code = c.Code
                })
                .ToList();

            SortCandidates(candidatesCK, candidatesCK.Count);

            return this.View(candidatesCK);
        }

        private static int GetNumber(string code)
        {
            string numberFromCode = code.Substring(0, 3);
            string number = "";

            if (numberFromCode[0] != '0')
            {
                number = "100";
            }

            else if (numberFromCode[0] == '0' && numberFromCode[1] != '0')
            {
                number = numberFromCode[1].ToString() + numberFromCode[2];
            }

            else if (numberFromCode[0] == '0' && numberFromCode[1] == '0')
            {
                number = numberFromCode[2].ToString();
            }

            return Convert.ToInt32(number);
        }

        private static DateTime GetDateTime(string code)
        {
            string day = code.Substring(4, 2);
            string month = code.Substring(6, 2);
            string year = code.Substring(8, 2);

            string date = year + "/" + month + "/" + day;

            DateTime parsedDate = DateTime.ParseExact(date, "yy/MM/dd", CultureInfo.InvariantCulture);

            return parsedDate;
        }

        private static Department GetDepartment(string code)
        {
            int departmenCode = Convert.ToInt32(code.Substring(3, 1));
            Department department = (Department)departmenCode;

            return department;
        }

        /// <summary>
        /// The sorting algorithm is based on Selection Sort but it was modified according to
        /// the needs of this project requirments
        /// </summary>
        /// <param name="candidates"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        private static List<CandidateCKViewModel> SortCandidates(List<CandidateCKViewModel> candidates, int n)
        {
            for (int i = 0; i < n - 1; i++)
            {

                //Find the minimum education in the unsorted array or
                //the maximum score
                int minIndexEducation = i;
                int maxIndexScore = i;
                string minEducation = candidates[i].Education;
                int maxScore = candidates[i].Score;

                for (int j = i + 1; j < n; j++)
                {

                    //String.CompareTo() method returns 0 if string elements are the same and
                    //returns -1 if the current element preceeds the one that is being compared to.
                    
                    //if elements are the same, check the score
                    if (candidates[j].Education.CompareTo(minEducation) == 0)
                    {
                        //if score of the next element (candidates[j].Score) is bigger that 
                        //the current element's score (maxScore), assign  the next element as the biggest
                        if (candidates[j].Score > maxScore)
                        {
                            maxScore = candidates[j].Score;
                            maxIndexScore = j;
                        }
                    }

                    // if the next element (candidates[j].Education) preceeds the current one (minEducation) 
                    //make the next element (candidates[j].Education) the smallest
                    else if (candidates[j].Education.CompareTo(minEducation) < 0)
                    {
                        minEducation = candidates[j].Education;
                        minIndexEducation = j;
                    }
                }

                //if there was a change in the education (a smaller element was found),
                //check for change in the score and if there is NO change in the score
                //make the element with smaller education first
                if (minIndexEducation != i && maxIndexScore == i)
                {
                    CandidateCKViewModel temp = candidates[minIndexEducation];
                    candidates[minIndexEducation] = candidates[i];
                    candidates[i] = temp;
                }

                //if there was NO change in the education (a smaller element was NOT found),
                //check for change in the score and if there is a change in the score
                //make the element with bigger score first
                else if (minIndexEducation == i && maxIndexScore != i)
                {
                    CandidateCKViewModel temp = candidates[maxIndexScore];
                    candidates[maxIndexScore] = candidates[i];
                    candidates[i] = temp;
                }
            }

            return candidates;
        }
    }
}
