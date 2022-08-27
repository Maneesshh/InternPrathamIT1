using InternApp.Data;
using InternApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace InternApp.Controllers
{
    public class HomeController : Controller
    {
        private AppDBContext Context { get; }
        public HomeController(AppDBContext _context)
        {
            this.Context = _context;
        }
        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.users = Context.Addresses.ToList();
            return View(Context.Addresses.ToList());
        }
        [BindProperty]
        public Address Address { get; set; }
        [HttpPost]
        public IActionResult Index(Address address)
        {
            this.Context.Addresses.Add(address);
            this.Context.SaveChanges();
            //ViewBag.users = Context.Addresses.ToList();
            return View(Context.Addresses.ToList());
        }
        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
        

        [HttpPost]
        public IActionResult FormData(Address address)
        {
            this.Context.Addresses.Add(address);
            this.Context.SaveChanges();

            return View(address);
        }
        //public IActionResult FormData(string name, string email, string password,string cpassword)
        //{
        //    // ViewBag.Name = string.Format("Name="+name+"Email="+email+"Password="password);
        //        var viewModel = new Address()
        //        {
        //            Name = name,
        //            Email = email,
        //            Password = password,
        //            Cpassword = cpassword,
        //        };
        //        return View(viewModel);
        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}