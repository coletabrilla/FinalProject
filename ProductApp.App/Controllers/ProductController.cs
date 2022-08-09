using AutoMapper;
using FinalProject.DataModel;
using Microsoft.AspNetCore.Mvc;
using ProductApp.App.Models;

namespace POSystem.App.Controllers
{
    public class ProductController : Controller
    {
        private readonly AppDbContext context;
        private readonly IMapper mapper;
        public ProductController(AppDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public IActionResult Index()
        {
            List<ProductVM> list = mapper.Map<List<ProductVM>>(context.Products.OrderBy(o => o.Stock).ToList());
            return View(list);
            //return View(context.Products.OrderBy(o => o.Stock).ToList());
        }

        public IActionResult Add()
        {
           // ProductVM model = new ProductVM();
            return View(new ProductVM());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Add(ProductVM model)
        {
            if (ModelState.IsValid == true) //okay na shaaaa
            {
                //codes to add new supplier
                await context.AddAsync(mapper.Map<Product>(model));
                //context.Set<Supplier>().Add(model); //this works too
                await context.SaveChangesAsync();

                return RedirectToAction("Index");


            }
            else
            {
                return View(model);
            }

            
            

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
            ProductVM product = mapper.Map<ProductVM>(await context.Products.FindAsync(id));

            return View(product);
        }
        

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult> Edit(ProductVM model)
        {
            if (ModelState.IsValid)
            {
                //update operation
                context.Set<Product>().Update(mapper.Map<Product>(model));
                //context.Update(model); //this works too
                await context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }


            
        }
    }
    

}
