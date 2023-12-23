using Adm.Application.Features.CQRS.Quaries;
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
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQueryRequest, GetProductsQueryResponse>
    {
        private readonly IRepository<Product> repository;

        private readonly IMapper mapper;

        public GetProductsQueryHandler(IRepository<Product> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<GetProductsQueryResponse> Handle(GetProductsQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await this.repository.GetAllAsync();
            return new GetProductsQueryResponse { Products = data };
        }
    }
}
