using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVC_Crud.Models;

namespace MVC_Crud.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(Repository.AllCustomers);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Customers cust)
        {
            Repository.Create(cust);
            return RedirectToAction("Index");
        }

        public IActionResult Delete()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Delete(int custId)
        {
            Repository.Delete(custId);
            return RedirectToAction("Index");
        }

        public IActionResult Update(int custId)
        {
            Customers customer = Repository.AllCustomers.Where(e => e.custId == custId).FirstOrDefault();
            return View(customer);
        }
  
        [HttpPost]
        public IActionResult Update(Customers customer, int custId)
        {
            Repository.AllCustomers.Where(e => e.custId == custId).FirstOrDefault().custName = customer.custName;
            Repository.AllCustomers.Where(e => e.custId == custId).FirstOrDefault().panNo = customer.panNo;
            Repository.AllCustomers.Where(e => e.custId == custId).FirstOrDefault().creditBal = customer.creditBal;
            Repository.AllCustomers.Where(e => e.custId == custId).FirstOrDefault().city = customer.city;

            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        [Route("Error")]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
