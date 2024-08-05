using Application.Messaging;
using Domain.Abstractions;
using Domain.Shop;

namespace Application.Product;


public sealed record UpdateProductCommand(int Id, string Name, string Description, decimal Price, int StockQuantity, int CategoryId, string ImageUrl) : ICommand<Domain.Shop.Product>;


internal sealed class UpdateProductCommandHandler : ICommandHandler<UpdateProductCommand, Domain.Shop.Product>
{
    private readonly IRepository<Domain.Shop.Product> _productRepository;

    public UpdateProductCommandHandler(IRepository<Domain.Shop.Product> productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<Result<Domain.Shop.Product>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetByIdAsync(request.Id);
        if (product is null)
        {
            return Result.Failure<Domain.Shop.Product>(ProductError.ProductNotFound);
        }

        product.Name = request.Name;
        product.Description = request.Description;
        product.Price = request.Price;
        product.StockQuantity = request.StockQuantity;
        product.CategoryId = request.CategoryId;
        product.ImageUrl = request.ImageUrl;

        await _productRepository.UpdateAsync(product);
        return Result.Success(product);
    }
}