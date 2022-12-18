using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;
using WebApplication5.Models;
using WebApplication5.Repositories.ScrapperLinkRepos;
using WebApplication5.Repositories.ScrapperRepos;

namespace WebApplication5.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IScrapperRepository _repo;
        private readonly IScrapperLinkRepository _linkRepo;

        public HomeController(ILogger<HomeController> logger, IScrapperRepository repo, IScrapperLinkRepository linkRepo)
        {
            _logger = logger;
            _repo = repo;
            _linkRepo = linkRepo;
        }
        public IActionResult Index()
        {
            return View();
        }

        [Route("GetAll")]
        public IActionResult GetAll()
        {
            var result = _repo.GetAll().OrderByDescending(x => x.Id);
            ViewBag.StatementCount = result.Count();
            return View(result);
        }

        [Route("GetApartments")]
        public IActionResult GetApartments()
        {
            var result = _repo.GetAll().Where(x => x.StatementType == 1).OrderByDescending(x => x.Id);
            ViewBag.StatementCount = result.Count();
            return View(result);
        }

        [Route("GetLends")]
        public IActionResult GetLends()
        {
            var result = _repo.GetAll().Where(x => x.StatementType == 2).OrderByDescending(x => x.Id);
            ViewBag.StatementCount = result.Count();
            return View(result);
        }

        [Route("Home/Create")]
        public IActionResult ScrapperJob()
        {
            _repo.ScrapperJob();
            var result = _repo.GetAll().OrderByDescending(x => x.Id);
            ViewBag.StatementCount = result.Count();
            return View("GetAll", result.OrderByDescending(x => x.Id));
        }


        public ActionResult AddLink()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddLink(ScrapperLinkModel model)
        {
            _linkRepo.AddLink(model);

            var result = _linkRepo.GetLinks();

            return View("GetLink", result);
        }

        public IActionResult GetLink()
        {
            var links = _linkRepo.GetLinks();

            return View(links);
        }

        public IActionResult DeleteLink(int id)
        {
            _linkRepo.DeleteLink(id);

            var result = _linkRepo.GetLinks();

            return View("GetLink", result);
        }
    }
}
