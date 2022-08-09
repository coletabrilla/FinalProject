using FinalProject.DataModel;
using Microsoft.AspNetCore.Mvc;

namespace POSystem.App.Controllers
{
    public class ProductController : Controller
    {
        private readonly AppDbContext context;
        public ProductController(AppDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            return View(context.Products.OrderBy(o => o.Stock).ToList());
        }

        public IActionResult Add()
        {
            return View(new Product());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Add(Product model)
        {
            //codes to add new supplier
            await context.AddAsync(model);
            //context.Set<Supplier>().Add(model); //this works too
            await context.SaveChangesAsync();
            return RedirectToAction("Index");

        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Delete(int id)
        {
            //EF operation
            var product = await context.Products.FindAsync(id);
            context.Set<Product>().Remove(product);
            await context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task <IActionResult> Edit(int? id)
        {
            if (id == null) return RedirectToAction("Index");
            var product = await context.Products.FindAsync(id);
            return View(product);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult> Edit(Product model)
        {
            //update operation
            context.Set<Product>().Update(model);
            //context.Update(model); //this works too
            await context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
    

}
