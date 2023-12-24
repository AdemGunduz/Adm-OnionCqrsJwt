using Adm.Application.Features.CQRS.Commands;
using Adm.Application.Interfaces;
using Adm.Domain.Entities;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adm.Application.Features.CQRS.Handlers
{
    public class UpdateProductCommadHandler : IRequestHandler<UpdateProductCommandRequest, UpdateProductCommandResponses>
    {
        private readonly IRepository<Product> repository;
        private readonly IMapper mapper;

        public UpdateProductCommadHandler(IRepository<Product> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<UpdateProductCommandResponses> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
        {

            var updatedProduct = await this.repository.GetByIdAsync(request.Id);
            if (updatedProduct != null)
            {
                updatedProduct.CategoryId = request.CategoryId;
                updatedProduct.Name = request.Name;
                updatedProduct.Stock = request.Stock;
                updatedProduct.Price = request.Price;
                await this.repository.SaveChangesAsync();
            }
            return new UpdateProductCommandResponses();
        }
    }
}
