using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adm.Application.Features.CQRS.Commands
{
    public class DeleteProductCommandRequest :IRequest <DeleteProductCommandResponse>
    {
        public int Id { get; set; }
        public DeleteProductCommandRequest(int id)
        {
            Id = id;

        }
    }
}
