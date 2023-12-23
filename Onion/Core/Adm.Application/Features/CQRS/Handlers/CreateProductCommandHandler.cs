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
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest, CreateProductCommandResponse>
    {
        private readonly IRepository<Product> repository;
        private readonly IMapper mapper;

        public CreateProductCommandHandler(IRepository<Product> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<CreateProductCommandResponse> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
            await repository.CreateAsync(new Product
            {
                CategoryId = request.CategoryId,
                Name = request.Name,
                Price = request.Price,
                Stock = request.Stock,
            });
            return new CreateProductCommandResponse();

        }
    }
}
