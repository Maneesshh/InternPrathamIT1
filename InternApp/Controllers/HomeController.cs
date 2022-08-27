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
            //ViewBag.users = Context.Addresses.ToList();
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
        [HttpGet]
        public IActionResult FormData(int id)
        {
            Address a =Context.Addresses.Find(id);
            return View(a);
        }
        [HttpGet]
        public IActionResult UpdateUser(Address address)
        {
            var users = Context.Addresses.Find(address.Id);
            users.Name = address.Name;
            users.email = address.email;
            users.Password = address.Password;
            users.Cpassword = address.Cpassword;
            this.Context.SaveChanges();
            return RedirectToAction("About");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var data = Context.Addresses.Find(id);
                Context.Addresses.Remove(data);
                Context.SaveChanges();
                return RedirectToAction("Index");

            
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = Context.Addresses.Find(id);

            //Context.Addresses.Remove(data);
            //Context.SaveChanges();
            return RedirectToAction("Formdata");


        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}