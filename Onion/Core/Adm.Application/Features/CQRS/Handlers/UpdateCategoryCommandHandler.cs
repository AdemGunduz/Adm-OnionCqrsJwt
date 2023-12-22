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
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommandRequest, UpdateCategoryCommandResponse>
    {
        private readonly IRepository<Category> repository;
        private readonly IMapper mapper;

        public UpdateCategoryCommandHandler(IRepository<Category> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<UpdateCategoryCommandResponse> Handle(UpdateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            var data = await this.repository.GetByIdAsync(request.Id);
            if (data != null)
            {
                data.Definition = request.Definition;
                await this.repository.UpdateAsync(data);
            }
            return new UpdateCategoryCommandResponse();
        }
    }
}
