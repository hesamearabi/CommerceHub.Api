using System.ComponentModel.DataAnnotations;

namespace CommerceHub.Api.DTOs.Products;

public class CreateProductRequestDto
{
    public int CategoryId { get; set; }
    [Required(ErrorMessage = "نام الزامی می باشد")]

    public string Name { get; set; } = null!;

    [Range(1, long.MaxValue, ErrorMessage = "قیمت محصول الزامی می باشد")]
    public long Price { get; set; }

    public bool IsAvailable { get; set; }



}
