using EShop.Application.Repositories;
using EShop.Application.Repositories.ProductRepository;
using EShop.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Application.Features.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest, UpdateProductCommandResponse>
    {
        private readonly IProductWriteRepository writeRepository;
        private readonly IProductReadRepository readRepository;

        public UpdateProductCommandHandler(IProductWriteRepository writeRepository, IProductReadRepository readRepository)
        {
            this.writeRepository = writeRepository;
            this.readRepository = readRepository;
        }
        public async Task<UpdateProductCommandResponse> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
        {

            var product = await readRepository.GetAsync(request.ProductId);

            product.Name = request.Name;
            product.Description = request.Desc;
            product.Price = request.Price;
            product.Stock = request.Stock;

            writeRepository.Update(product);
            await writeRepository.SaveChangesAsync();

            return new();
        }
    }
}
