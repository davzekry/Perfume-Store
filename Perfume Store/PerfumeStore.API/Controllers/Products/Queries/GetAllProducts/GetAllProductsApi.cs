using Microsoft.AspNetCore.Mvc;
using PerfumeStore.Application.Common.Models;
using PerfumeStore.Application.Features.Products.Queries.GetAllProducts;

public sealed partial class ProductsController
{
    [HttpGet]
    public async Task<ActionResult<ApiResponse<List<GetAllProductsDto>>>> GetAll(
        [FromQuery] GetAllProductsQuery query, CancellationToken ct)
    {
        var result = await _sender.Send(query, ct);
        return OkPaged(result, $"Found {result.TotalCount} product(s).");
    }
}