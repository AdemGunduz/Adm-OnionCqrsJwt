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
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommandRequest, DeleteProductCommandResponse>
    {
        private readonly IRepository<Product> repository;
        private readonly IMapper mapper;

        public DeleteProductCommandHandler(IRepository<Product> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<DeleteProductCommandResponse> Handle(DeleteProductCommandRequest request, CancellationToken cancellationToken)
        {
            var deletedEntity = await this.repository.GetByIdAsync(request.Id);
            if (deletedEntity != null)
            {
                await this.repository.RemoveAsync(deletedEntity);
            }
            return new DeleteProductCommandResponse();
        }
    }
}
