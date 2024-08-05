using Application.Messaging;
using Domain.Abstractions;
using Domain.Shop;

namespace Application.Product;

public sealed record GetProductByIdQuery(int ProductId) : IQuery<Domain.Shop.Product>;
internal sealed class GetProductByIdQueryHandler : IQueryHandler<GetProductByIdQuery, Domain.Shop.Product>
{
    private readonly IRepository<Domain.Shop.Product> _productRepository;

    public GetProductByIdQueryHandler(IRepository<Domain.Shop.Product> productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<Result<Domain.Shop.Product>> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetByIdAsync(request.ProductId);
        if (product is null)
            return Result.Failure<Domain.Shop.Product>(ProductError.ProductNotFound);
        
        return Result.Success(product);
    }
}
