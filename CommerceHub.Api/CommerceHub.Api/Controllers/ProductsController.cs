using CommerceHub.Api.Data;
using CommerceHub.Api.DTOs.Products;
using CommerceHub.Api.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace CommerceHub.Api.Controllers;


[ApiController]
[Route("api/[controller]")]
public class ProductsController(ApplicationDbContext context,
    IWebHostEnvironment environment)
    : ControllerBase
{
    public async Task<ActionResult> Create(CreateProductRequestDto request)
    {
        if (!await context.ProductCategories
            .AnyAsync(x => x.Id == request.CategoryId))
        {
            return BadRequest("شناسه دسته بندی صحیح نمی باشد");
        }
        if (request.Images != null && request.Images.Any())
        {
            #region File Upload 

            var uploadFolder = Path.Combine(environment.WebRootPath, "Products");
            if (!Directory.Exists(uploadFolder))
            {
                Directory.CreateDirectory(uploadFolder);
            }

            var product = new Product()
            {
                CategoryId = request.CategoryId,
                Name = request.Name,
                Price = request.Price,
                IsAvailable = request.IsAvailable,
                Images = []
            };

            bool isFirst = true;
            foreach (var image in request.Images)
            {
                var fileName = $"{Guid.NewGuid()}{Path.GetExtension(image.FileName)}";
                var filePath = Path.Combine(uploadFolder, fileName);
                await using var stream = new FileStream(filePath, FileMode.Create);

                await image.CopyToAsync(stream);

                product.Images.Add(new ProductImage()
                {
                    Url = $"Products/{fileName}",
                    IsMain = isFirst

                });
                isFirst = false;
                context.Products.Add(product);
                await context.SaveChangesAsync();

                #endregion File Upload 
            }





        }
        return Ok("محصول با موفقیت اضافه شد");
    }















}





















}

