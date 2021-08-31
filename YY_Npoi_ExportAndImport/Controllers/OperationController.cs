using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YY_NpoiExportAndImport.Controllers
{
    public class OperationController : Controller
    {
        // GET: OperationController
        public ActionResult Index()
        {
            return View();
        }

        // GET: OperationController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: OperationController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OperationController/Create
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

        // GET: OperationController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: OperationController/Edit/5
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

        // GET: OperationController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: OperationController/Delete/5
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
