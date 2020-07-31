using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySqlX.XDevAPI;

namespace CosmeticDashboard.Controllers
{
    public class DashboardController : Controller
    {
        // GET: DashboardController
        [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true, Duration = 0)]
        [HttpGet]
        public ActionResult Index()
        {
            if(HttpContext.Session.GetInt32("USER_LOGIN_KEY") != null)
            {
                
                return View("_LayoutDashboard");
            }
            else
            {
                return RedirectToAction("Login", "Hidden");
            }
            
        }
        [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true, Duration = 0)]
        [HttpGet]
        public ActionResult Korea_Local()
        {
            return PartialView("Factory");
            
            
            
        }
        [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true, Duration = 0)]
        [HttpGet]
        public ActionResult Europe()
        {
            return PartialView();
            
            
        }
        [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true, Duration = 0)]
        [HttpGet]
        public ActionResult America()
        {
            return PartialView();
        }
        [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true, Duration = 0)]
        [HttpGet]
        public ActionResult Asia()
        {
            return PartialView();
            
        }


        // GET: DashboardController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DashboardController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DashboardController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DashboardController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DashboardController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DashboardController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DashboardController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
