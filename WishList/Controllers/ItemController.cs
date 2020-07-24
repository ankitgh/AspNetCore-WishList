using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WishList.Data;
using WishList.Models;

namespace WishList.Controllers
{
    public class ItemController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ItemController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ItemController
        public IActionResult Index()
        {
            return View("Index", _context.Items.ToList());
        }

        // GET: ItemController/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View("Create");
        }

        // POST: ItemController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Item item)
        {
            _context.Items.Add(item);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


        // GET: ItemController/Delete/5
        public IActionResult Delete(int id)
        {
            Item item = _context.Items.FirstOrDefault(x => x.Id == id);
            _context.Items.Remove(item);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
