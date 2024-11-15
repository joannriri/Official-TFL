
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Net;
using TheFabricsLab.Areas.Identity.Data;
using TheFabricsLab.Models;

namespace TheFabricsLab.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly AppDbContext context;
        private readonly IWebHostEnvironment environment;

        public UserController(UserManager<AppUser> userManager, AppDbContext context, IWebHostEnvironment environment)
        {
            this.userManager = userManager;
            this.context = context;
            this.environment = environment;
        }

        //public async Task<IActionResult> UserDetails()
        //{
        //    var user = await userManager.GetUserAsync(User);
        //    if (user == null)
        //    {
        //        return NotFound(); // Handle the case where the user is not found
        //    }

        //    return View(user);
        //}

        public IActionResult Admin()
        {
            var products = context.Products.OrderByDescending(p => p.ProductID).ToList();
            return View(products);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ProductDto productDto)
        {
            if (productDto.ImageFile == null)
            {
                ModelState.AddModelError("ImageFile", "The image file is required");
            }
            if (!ModelState.IsValid)
            {
                return View(productDto);
            }

            //save image file
            string newFileName = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            newFileName += Path.GetExtension(productDto.ImageFile!.FileName);

            string imageFullPath = environment.WebRootPath + "/img/Catalog/" + newFileName;
            using (var stream = System.IO.File.Create(imageFullPath))
            {
                productDto.ImageFile.CopyTo(stream);
            }

            //save new product to database
            Product product = new Product()
            {
                ProductName = productDto.ProductName,
                CategoryID = productDto.CategoryID,
                ProductPrice = productDto.ProductPrice,
                Description = productDto.Description,
                ImageFile = newFileName,
                DiscountID = productDto.DiscountID,
                Stock = productDto.Stock,
                Quantity = productDto.Quantity,
                CreatedAt = DateTime.Now
            };

            context.Products.Add(product);
            context.SaveChanges();
            return RedirectToAction("Admin", "User");
        }

        ////scrap
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Create(ProductCategory category)
        //{
        //    if(ModelState.IsValid)
        //    {
        //        context.ProductCategories.Add(category);
        //        context.SaveChanges();
        //        return RedirectToAction("Admin");
        //    }
        //    return View(category);
        //}

        public IActionResult Edit(int id)
        {
            var product = context.Products.Find(id);
            if (product == null)
            {
                return RedirectToAction("Admin", "User");
            }

            //create productDto from product
            var productDto = new ProductDto()
            {
                ProductName = product.ProductName,
                CategoryID = product.CategoryID,
                ProductPrice = product.ProductPrice,
                Description = product.Description,
                DiscountID = product.DiscountID,
                Stock = product.Stock,
                Quantity = product.Quantity
            };

            ViewData["ProductID"] = product.ProductID;
            ViewData["ImageFileName"] = product.ImageFile;
            ViewData["CreatedAt"] = product.CreatedAt.ToString("MM/dd/yyyy");
            return View(productDto);
        }

        [HttpPost]
        public IActionResult Edit(int id, ProductDto productDto)
        {
            var product = context.Products.Find(id);
            if (product == null)
            {
                return RedirectToAction("Admin", "User");
            }
            if (!ModelState.IsValid)
            {
                ViewData["ProductID"] = product.ProductID;
                ViewData["ImageFileName"] = product.ImageFile;
                ViewData["CreatedAt"] = product.CreatedAt.ToString("MM/dd/yyyy");
                return View(productDto);
            }

            //update img if replaced by new img
            string newFileName = product.ImageFile;
            if (productDto.ImageFile != null)
            {
                newFileName = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                newFileName += Path.GetExtension(productDto.ImageFile.FileName);

                string imageFullPath = environment.WebRootPath + "/Catalog/" + newFileName;
                using (var stream = System.IO.File.Create(imageFullPath))
                {
                    productDto.ImageFile.CopyTo(stream);
                }

                //delete old img
                string oldImageFullPath = environment.WebRootPath + "/Catalog/" + product.ImageFile;
                System.IO.File.Delete(oldImageFullPath);
            }

            //update product in db
            product.ProductName = productDto.ProductName;
            product.CategoryID = productDto.CategoryID;
            product.ProductPrice = productDto.ProductPrice;
            product.Description = productDto.Description;
            product.DiscountID = productDto.DiscountID;
            product.ImageFile = newFileName;
            product.Stock = productDto.Stock;
            product.Quantity = productDto.Quantity;

            context.SaveChanges();
            return RedirectToAction("Admin", "User");

        }

        public IActionResult Delete(int id)
        {
            var product = context.Products.Find(id);
            if (product == null)
            {
                return RedirectToAction("Admin", "User");
            }

            string imageFullPath = environment.WebRootPath + "/img/Catalog/" + product.ImageFile;
            System.IO.File.Delete(imageFullPath);

            context.Products.Remove(product);
            context.SaveChanges(true);

            return RedirectToAction("Admin", "User");
        }

        // PRODUCT VARIANTS

        public IActionResult AdminVar()
        {
            var productVariants = context.ProductVariants.OrderByDescending(p => p.VariantID).ToList();
            return View(productVariants);
        }

        public IActionResult CreateVar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateVar(ProductVarDto productVarDto)
        {
            if (productVarDto.ImageFile == null)
            {
                ModelState.AddModelError("ImageFile", "The image file is required");
            }
            if (!ModelState.IsValid)
            {
                return View(productVarDto);
            }

            //save image file
            string newFileName = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            newFileName += Path.GetExtension(productVarDto.ImageFile!.FileName);

            string imageFullPath = environment.WebRootPath + "/img/Catalog/" + newFileName;
            using (var stream = System.IO.File.Create(imageFullPath))
            {
                productVarDto.ImageFile.CopyTo(stream);
            }

            //save new product variant to database
            ProductVariants productVar = new ProductVariants()
            {
                ProductID = productVarDto.ProductID,
                Color = productVarDto.Color,
                Price = productVarDto.Price,
                Stock = productVarDto.Stock,
                ImageFile = newFileName,
                CreatedAt = DateTime.Now
            };

            context.ProductVariants.Add(productVar);
            context.SaveChanges();
            return RedirectToAction("Admin", "User");
        }

        public IActionResult EditVar(int id)
        {
            var productVar = context.ProductVariants.Find(id);
            if (productVar == null)
            {
                return RedirectToAction("Admin", "User");
            }

            //create productVarDto from product
            var productVarDto = new ProductVarDto()
            {
                ProductID = productVar.ProductID,
                Color = productVar.Color,
                Price = productVar.Price,
                Stock = productVar.Stock,
            };

            ViewData["ProductID"] = productVar.ProductID;
            ViewData["ImageFileName"] = productVar.ImageFile;
            ViewData["CreatedAt"] = productVar.CreatedAt.ToString("MM/dd/yyyy");
            return View(productVarDto);
        }

        [HttpPost]
        public IActionResult EditVar(int id, ProductVarDto productVarDto)
        {
            var productVar = context.ProductVariants.Find(id);
            if (productVar == null)
            {
                return RedirectToAction("Admin", "User");
            }
            if (!ModelState.IsValid)
            {
                ViewData["ProductID"] = productVar.ProductID;
                ViewData["ImageFileName"] = productVar.ImageFile;
                ViewData["CreatedAt"] = productVar.CreatedAt.ToString("MM/dd/yyyy");
                return View(productVarDto);
            }

            //update img if replaced by new img
            string newFileName = productVar.ImageFile;
            if (productVarDto.ImageFile != null)
            {
                newFileName = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                newFileName += Path.GetExtension(productVarDto.ImageFile.FileName);

                string imageFullPath = environment.WebRootPath + "/Catalog/" + newFileName;
                using (var stream = System.IO.File.Create(imageFullPath))
                {
                    productVarDto.ImageFile.CopyTo(stream);
                }

                //delete old img
                string oldImageFullPath = environment.WebRootPath + "/Catalog/" + productVar.ImageFile;
                System.IO.File.Delete(oldImageFullPath);
            }

            //update product in db
            productVar.ProductID = productVarDto.ProductID;
            productVar.Color = productVarDto.Color;
            productVar.Price = productVarDto.Price;
            productVar.Stock = productVarDto.Stock;
            productVar.ImageFile = newFileName;

            context.SaveChanges();
            return RedirectToAction("Admin", "User");

        }

        public IActionResult DeleteVar(int id)
        {
            var productVar = context.ProductVariants.Find(id);
            if (productVar == null)
            {
                return RedirectToAction("Admin", "User");
            }

            string imageFullPath = environment.WebRootPath + "/Catalog/" + productVar.ImageFile;
            System.IO.File.Delete(imageFullPath);

            context.ProductVariants.Remove(productVar);
            context.SaveChanges(true);

            return RedirectToAction("Admin", "User");
        }
    }
}
