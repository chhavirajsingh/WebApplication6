using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication6.Models;
using WebApplication6.Models.ViewModel;

namespace WebApplication6.Controllers
{
    public class ProductsController : Controller
    {
        ApplicationDbContext dbContext = new ApplicationDbContext();
        // GET: Products
        public ActionResult Index()
        {
            //var products = dbContext.Products.ToList();
            var products = (from p in dbContext.Products
                            join
                            c in dbContext.Categories
                            on p.Category.Id equals c.Id

                            select new ProductListViewModel()
                            {
                              Id=p.Id,
                              Name=p.Name,
                              Quantity=p.Quantity,
                              Price=p.Price,
                              Description=p.Description,
                              Category=c.Name
                            });
            return View(products);
        }
        public ActionResult Create()
        {
            var cats = dbContext.Categories.ToList();
            ViewBag.cats = cats;
            return View();
        }
        [HttpPost]
        public ActionResult Create(ProductViewModel product)
        {
            var cat = dbContext.Categories.SingleOrDefault(e => e.Id == product.Category);
            var objProduct = new Products()
            {
                Name=product.Name,
                Quantity=product.Quantity,
                Description=product.Description,
                Price=product.Price,
                Category=cat
            };
            dbContext.Products.Add(objProduct);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var product = dbContext.Products.SingleOrDefault(e => e.Id == id);
            dbContext.Products.Remove(product);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }



        public ActionResult Edit(int id)
        {
            var product = dbContext.Products.SingleOrDefault(e => e.Id == id);
            return View(product);
        }
       
        [HttpPost]
        public ActionResult Edit(Products product)
        {
            dbContext.Entry(product).State=System.Data.Entity.EntityState.Modified;
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}