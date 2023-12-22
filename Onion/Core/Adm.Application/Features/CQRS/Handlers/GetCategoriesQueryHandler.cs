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
    public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQueryRequest, GetCategoriesQueryResponse>
    {
        private readonly IRepository<Category> repository;
        private readonly IMapper mapper;

        public GetCategoriesQueryHandler(IRepository<Category> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<GetCategoriesQueryResponse> Handle(GetCategoriesQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await this.repository.GetAllAsync();
            return new GetCategoriesQueryResponse { Categories = data };
        }
    }
}
