using CommerceHub.Api.Entities;
using System.ComponentModel.DataAnnotations;

namespace CommerceHub.Api.DTOs.Products;

public class GetProductByIdResponseDto
{
    public int Id { get; set; }
    public int CategoryId { get; set; }
    public string CategoryName { get; set; } = null!;
    public string Name { get; set; } = null!;
    public long Price { get; set; }

    public List<ProductImageResponseDto> Images { get; set; } = [];

}




