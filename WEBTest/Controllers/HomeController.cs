using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WEBTest.Models;
using WEBTest.Repository;
using AutoRepairShop;

namespace WEBTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ILogicContainer _logic;

        public HomeController(ILogicContainer logic, ILogger<HomeController> logger)
        {
            _logic = logic;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var found = _logic.GetLogic();
            return View(found);
        }

        [HttpPost]
        public IActionResult AddService(AddServiceModel model)
        {

            if (ModelState.IsValid)
            {
                _logic.GetLogic().AddNewService(new Service(model.AddName, model.AddCount, model.AddPrice));
            }

            return RedirectToAction("Index");
        }


        [HttpPost]
        public IActionResult RemoveService(string removeName)
        {

            _logic.GetLogic().RemoveAllWithName(removeName);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult BuyService(string buyName, string buyCount)
        {

            _logic.GetLogic().BuyService(buyName, buyCount);

            return RedirectToAction("Index");
        }

        public IActionResult ImportDetails(string importName, string importCount)
        {


            _logic.GetLogic().ImportDetails(importName, importCount);

            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
