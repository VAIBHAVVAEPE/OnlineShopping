using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShopping.Models;
using System;

namespace OnlineShopping.Controllers
{
    public class ProductController : Controller
    {
        ProductDAL context = new ProductDAL();
        public IActionResult List()
        {
            ViewBag.ProductList = context.GetAllProducts();
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(IFormCollection form)
        {
            Product p = new Product();
            p.Pname = form["Pname"];
            p.Pprice = Convert.ToInt32(form["Pprice"]);
            p.Pdescription = form["Pdescription"];
            int res = context.Save(p);
            if (res == 1)
                return RedirectToAction("List");
            return View();
        }
        public IActionResult Edit(int id)
        {
            Product prod = context.GetProductById(id);
            ViewBag.Pname = prod.Pname;
            ViewBag.Pprice = prod.Pprice;
            ViewBag.Pdescription = prod.Pdescription;
            ViewBag.PId = prod.PId;
            return View();
        }
        [HttpPost]
        public IActionResult Edit(IFormCollection form)
        {
            Product prod = new Product();
            prod.Pname = form["Pname"];
            prod.Pprice = Convert.ToInt32(form["Pprice"]);
            prod.Pdescription = form["Pdescription"];
            prod.PId = Convert.ToInt32(form["PId"]);
            int res = context.Update(prod);
            if (res == 1)
                return RedirectToAction("List");
            return View();
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Product prod = context.GetProductById(id);
            ViewBag.Pname = prod.Pname;
            ViewBag.Pprice = prod.Pprice;
            ViewBag.Pdescription = prod.Pdescription;
            ViewBag.PId = prod.PId;
            return View();
        }
        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteConfirm(int PId)
        {
            int res = context.Delete(PId);
            if (res == 1)
                return RedirectToAction("List");
            return View();
        }
    }
}
 