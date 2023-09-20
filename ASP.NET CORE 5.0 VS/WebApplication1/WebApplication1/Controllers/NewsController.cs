using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    public class NewsController : Controller
    {
        //// GET: NewsController
        //public ActionResult Index()
        //{
        //    return View();
        //}

        //// GET: NewsController/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        //// GET: NewsController/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: NewsController/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: NewsController/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: NewsController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: NewsController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: NewsController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        public IActionResult Index()
        {
            return View();
        }
        public string StringOut(int id, Employee employee)
        {
            return ($"Controllers - NewsController - {id} - {employee.FirstName} {employee.LastName} ");
        }

        public IActionResult StringOut2(int id, Employee employee)
        {
            return Content($"Controllers - NewsController - {id} - {employee.FirstName} {employee.LastName} ");
        }
        
        public IActionResult JsonOut(int id, Employee employee)
        {
            var obj = new { Id = id, Employee = employee };
            return Json(obj);
        }

        public class Employee
        {

            public string FirstName { get; set; }
            public string LastName { get; set; }
        }
    }
}
