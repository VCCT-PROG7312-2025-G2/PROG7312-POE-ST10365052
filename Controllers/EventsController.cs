using Microsoft.AspNetCore.Mvc;
using PROG7312.Models;

namespace PROG7312.Controllers
{
    public class EventsController : Controller
    {
        private static EventsManager eventManager = new EventsManager();
        private static bool demoEventsAdded = false;
        public EventsController()
        {
            if (!demoEventsAdded)
            {
                AddDemoEvents();
                demoEventsAdded = true;
            }
        }
        private void AddDemoEvents()
        {
            eventManager.AddEvent(new Events
            {
                Title = "Table Mountain Hike",
                Category = "Sports",
                Date = DateTime.Today.AddDays(4),
                Description = "Join a guided hike up Table Mountain for incredible city views."
            });
            eventManager.AddEvent(new Events
            {
                Title = "V&A Waterfront Market",
                Category = "Culinary",
                Date = DateTime.Today.AddDays(6),
                Description = "Explore local food, crafts, and music at the vibrant V&A Market."
            });
            eventManager.AddEvent(new Events
            {
                Title = "Kirstenbosch Summer Concert",
                Category = "Entertainment",
                Date = DateTime.Today.AddDays(8),
                Description = "Relax on the lawns and enjoy live music in the botanical gardens."
            });
            eventManager.AddEvent(new Events
            {
                Title = "Cape Town International Jazz Festival",
                Category = "Entertainment",
                Date = DateTime.Today.AddDays(12),
                Description = "Experience world-class jazz performances from international artists."
            });
            eventManager.AddEvent(new Events
            {
                Title = "Greenpoint Park Yoga",
                Category = "Health & Wellness",
                Date = DateTime.Today.AddDays(2),
                Description = "Start your morning with a free outdoor yoga session."
            });
            eventManager.AddEvent(new Events
            {
                Title = "Wine Tasting in Stellenbosch",
                Category = "Culinary",
                Date = DateTime.Today.AddDays(9),
                Description = "Sample award-winning wines and enjoy scenic vineyard views."
            });
            eventManager.AddEvent(new Events
            {
                Title = "Bo-Kaap Heritage Tour",
                Category = "Cultural",
                Date = DateTime.Today.AddDays(5),
                Description = "Discover the history, food, and colorful homes of Bo-Kaap."
            });
            eventManager.AddEvent(new Events
            {
                Title = "Sea Point Promenade Cycle",
                Category = "Outdoor",
                Date = DateTime.Today.AddDays(3),
                Description = "Take a scenic sunset cycle along the Sea Point Promenade."
            });
            eventManager.AddEvent(new Events
            {
                Title = "Cape Town Marathon",
                Category = "Sports",
                Date = DateTime.Today.AddDays(14),
                Description = "Join runners from around the world in this major city marathon."
            });
            eventManager.AddEvent(new Events
            {
                Title = "Clifton Beach Volleyball Tournament",
                Category = "Sports",
                Date = DateTime.Today.AddDays(6),
                Description = "Come and watch or take part in a fun day of beach volleyball."
            });
            eventManager.AddEvent(new Events
            {
                Title = "First Thursdays Cape Town",
                Category = "Cultural",
                Date = DateTime.Today.AddDays(1),
                Description = "Explore art galleries and restaurants in the city center after hours."
            });
            eventManager.AddEvent(new Events
            {
                Title = "Cape Point Nature Walk",
                Category = "Outdoor",
                Date = DateTime.Today.AddDays(7),
                Description = "Join a guided nature walk through the stunning Cape Point Reserve."
            });
            eventManager.AddEvent(new Events
            {
                Title = "Two Oceans Aquarium Night Tour",
                Category = "Family",
                Date = DateTime.Today.AddDays(9),
                Description = "Experience the aquarium after dark with a behind-the-scenes tour."
            });
            eventManager.AddEvent(new Events
            {
                Title = "Oranjezicht Farmers Market",
                Category = "Culinary",
                Date = DateTime.Today.AddDays(2),
                Description = "Shop for organic produce and artisanal food at this open-air market."
            });
            eventManager.AddEvent(new Events
            {
                Title = "Cape Town Comedy Night",
                Category = "Entertainment",
                Date = DateTime.Today.AddDays(5),
                Description = "Laugh out loud with Cape Town’s top local comedians."
            });


        }

        public IActionResult Index()
        {
            var allEvents = eventManager.EventsByDate.SelectMany(idx => idx.Value).ToList();
            ViewBag.Recommended = new List<Events>();
            ViewBag.Categories = eventManager.Categories.ToList();
            ViewBag.SelectedCategory = ""; 
            ViewBag.Search = "";
            return View("~/Views/Home/eventsView.cshtml", allEvents);
        }

        public IActionResult Search(string search, string category)
        {
            var results = eventManager.EventsByDate
                .SelectMany(idx => idx.Value)
                .Where(ev =>
                    (string.IsNullOrEmpty(search) || ev.Title.Contains(search, StringComparison.OrdinalIgnoreCase)) &&
                    (string.IsNullOrEmpty(category) || ev.Category == category))
                .ToList();

            eventManager.RegisterCategorySearch(category);
            ViewBag.Recommended = eventManager.RecommendEvents();
            ViewBag.Categories = eventManager.Categories.ToList();
            ViewBag.SelectedCategory = category ?? "";
            ViewBag.Search = search ?? "";             
            return View("~/Views/Home/eventsView.cshtml", results);
        }




    }
}
