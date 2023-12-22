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
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommandRequest , CreateCategoryCommandResponse>
    {
        private readonly IRepository<Category> repository;
        private readonly IMapper mapper;

        public CreateCategoryCommandHandler(IRepository<Category> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<CreateCategoryCommandResponse> Handle(CreateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            await repository.CreateAsync(new Category
            {
                Definition = request.Definition,
            });
            return new CreateCategoryCommandResponse() ;
        }
    }
}


