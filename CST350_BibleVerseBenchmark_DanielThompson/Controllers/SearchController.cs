using CST350_BibleVerseBenchmark_DanielThompson.Models;
using CST350_BibleVerseBenchmark_DanielThompson.Services;
using Microsoft.AspNetCore.Mvc;

namespace CST350_BibleVerseBenchmark_DanielThompson.Controllers
{
    public class SearchController : Controller
    {
        BibleVerseDAO bibleVerseService = new BibleVerseDAO(); // Instance of service

        public IActionResult Index(string searchTerm, int option)
        {
            List<BibleModel> searchResults = new List<BibleModel>();

            searchResults = bibleVerseService.Search(searchTerm, option);

            return View("SearchResults", searchResults);
        }
    }
}
