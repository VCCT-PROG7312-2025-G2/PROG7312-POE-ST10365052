using Microsoft.AspNetCore.Mvc;
using PROG7312.Models;
using System;

namespace PROG7312.Controllers
{
    public class IssuesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        // Used for runtime storage so that it is stored in compliance with part 1 requirements
        private static LinkedList<Issues> issues = new LinkedList<Issues>();
        private static Queue<Issues> issuesQueue = new Queue<Issues>();


        [HttpPost]
        public IActionResult SubmitIssue(string location, string category, string description, List<IFormFile> files)
        {
            var issue = new Issues
            {
                Location = location,
                Category = category,
                Description = description,
                Files = files
            };

            issues.AddLast(issue);        // Add to linked list
            issuesQueue.Enqueue(issue);
            issuesQueue.Enqueue(issue);// Add to queue
            //This will be expanded on in further functionality

            TempData["SuccessMessage"] = "Your issue has been successfully submitted!";
            return RedirectToAction("Index", "Home");
        }

    }
}


