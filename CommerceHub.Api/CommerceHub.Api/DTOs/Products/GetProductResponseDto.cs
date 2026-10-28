using CommerceHub.Api.Entities;

namespace CommerceHub.Api.DTOs.Products;

public class GetProductResponseDto
{
    public int Id { get; set; }
    public int CategoryId { get; set; }
    public string CategoryName { get; set; } = null!;
    public string Name { get; set; }
    public long Price { get; set; }
    public List<ProductImageResponseDto> Images { get; set; } = [];


}
