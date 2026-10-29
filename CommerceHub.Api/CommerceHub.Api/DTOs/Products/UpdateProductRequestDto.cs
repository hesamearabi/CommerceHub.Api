namespace CommerceHub.Api.DTOs.Products;

public class UpdateProductRequestDto
{
    public int Id { get; set; }
    public int CategoryId { get; set; }
    public string Name { get; set; } = null!;
    public string CategoryName { get; set; } = null!;
    public long Price { get; set; }
    public bool IsAvailable { get; set; }
    public List<IFormFile> Images { get; set; } = null!;
    public List<int> RemovedImagesIds { get; set; } = null!;

}
