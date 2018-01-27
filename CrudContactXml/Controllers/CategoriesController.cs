using CrudContactXml.Models;
using CrudContactXml.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CrudContactXml.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly NotatnikService _notatnikService;

        public CategoriesController(NotatnikService notatnikService)
        {
            this._notatnikService = notatnikService;
        }

        [HttpGet]
        public IActionResult Index(int page = 1, int pageSize = 10, string SearchString = "", string sortOrder = "")
        {
            ViewData["SortParm"] = sortOrder;

            var qry = (IEnumerable<Category>)this._notatnikService.Contacts();
            qry = this._notatnikService.Search(qry, SearchString);
            qry = this._notatnikService.Filter(qry, sortOrder);

            return View(Paging.Paging<Category>.PagingList(qry.AsQueryable(), pageSize, page));
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create([FromForm] Category category)
        {
            if (ModelState.IsValid)
            {
                this._notatnikService.Save(category);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            this._notatnikService.Delete(id);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            return View(this._notatnikService.GetCategory(id));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(this._notatnikService.GetCategory(id));
        }

        [HttpPost]
        public IActionResult Edit(int id, [FromForm] Category category)
        {
            if (ModelState.IsValid)
            {
                this._notatnikService.Update(id, category);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}