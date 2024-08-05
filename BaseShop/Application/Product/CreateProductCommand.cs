using Application.Messaging;
using Domain.Abstractions;

namespace Application.Product;

public sealed record CreateProductCommand(string Name, string Description, decimal Price, int StockQuantity, int CategoryId, string ImageUrl) : ICommand<Domain.Shop.Product>;


     internal sealed class CreateProductCommandHandler : ICommandHandler<CreateProductCommand, Domain.Shop.Product>
    {
        private readonly IRepository<Domain.Shop.Product> _productRepository;

        public CreateProductCommandHandler(IRepository<Domain.Shop.Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Result< Domain.Shop.Product>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Domain.Shop.Product
            {
                Name = request.Name,
                Description = request.Description,
                Price = request.Price,
                StockQuantity = request.StockQuantity,
                CategoryId = request.CategoryId,
                ImageUrl = request.ImageUrl
            };

            await _productRepository.AddAsync(product);
            return Result.Success(product);
        }
    }
