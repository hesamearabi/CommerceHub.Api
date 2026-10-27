using CommerceHub.Api.Data;
using CommerceHub.Api.DTOs.Products;
using CommerceHub.Api.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CommerceHub.Api.Controllers;


[ApiController]
[Route("api/[controller]")]
public class ProductsController(ApplicationDbContext context,
    IWebHostEnvironment environment)
    : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult> Create(CreateProductRequestDto request)
    {
        if (!await context.ProductCategories
            .AnyAsync(x => x.Id == request.CategoryId))
        {
            return BadRequest("نام دسته بندی صحیح نمی باشد");
        }

        var product = new Product
        {
            CategoryId = request.CategoryId,
            Name = request.Name,
            Price = request.Price

        };
        context.Products.Add(product);
        await context.SaveChangesAsync();

        return Ok();
    }




}
