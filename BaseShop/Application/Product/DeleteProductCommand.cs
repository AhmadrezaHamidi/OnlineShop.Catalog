using Application.Messaging;
using Domain.Abstractions;
using Domain.Shop;

namespace Application.Product;

public sealed record DeleteProductCommand(int Id) : ICommand;

internal sealed class DeleteProductCommandHandler : ICommandHandler<DeleteProductCommand>
{
    private readonly IRepository<Domain.Shop.Product> _productRepository;

    public DeleteProductCommandHandler(IRepository<Domain.Shop.Product> productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<Result> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetByIdAsync(request.Id);
        if (product is null)
            return Result.Failure(ProductError.ProductNotFound);

        await _productRepository.DeleteAsync(request.Id);
        return Result.Success();
    }
}

