using MediatR;
using PerfumeStore.Application.Common.Models;

namespace PerfumeStore.Application.Features.Products.Queries.GetAllProducts;

public record GetAllProductsQuery(
    int Page = 1,
    int PageSize = 10,
    string? Search = null,
    string SortBy = "name",
    bool Asc = true
) : IRequest<PaginatedList<GetAllProductsDto>>;