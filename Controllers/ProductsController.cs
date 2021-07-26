using demo.Data;
using demo.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace demo.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ProductsController(ApplicationDbContext db, IWebHostEnvironment webHostEnvironment)
        {
            _db = db;
            _webHostEnvironment = webHostEnvironment;
        } 


        public IActionResult Index(string sortOrder, string SearchString)
        {
            IEnumerable<Product> objList = _db.Product;
            

            if (!String.IsNullOrEmpty(SearchString))
            {
                objList = objList.Where(s => s.ProductName.Contains(SearchString)).ToList();
            }

            ViewData["NameOrder"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";

            switch (sortOrder)
            {
                case "name_desc":
                    objList = objList.OrderByDescending(u => u.ProductName);
                    break;
                default:
                    objList = objList.OrderBy(u => u.ProductName);
                    break;
            }


            return View(objList);
        }
    }
}
