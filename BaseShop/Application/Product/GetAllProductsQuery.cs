using Application.Messaging;
using Domain.Abstractions;

namespace Application.Product;


public sealed record GetAllProductsQuery : IQuery<IEnumerable<Domain.Shop.Product>>;

internal sealed class GetAllProductsQueryHandler : IQueryHandler<GetAllProductsQuery, IEnumerable<Domain.Shop.Product>>
{
    private readonly IRepository<Domain.Shop.Product> _productRepository;

    public GetAllProductsQueryHandler(IRepository<Domain.Shop.Product> productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<Result<IEnumerable<Domain.Shop.Product>>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        var products = await _productRepository.GetAllAsync();
        return Result.Success(products);
    }
}