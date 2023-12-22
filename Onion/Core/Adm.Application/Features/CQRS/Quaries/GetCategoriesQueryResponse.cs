using Adm.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adm.Application.Features.CQRS.Quaries
{
    public class GetCategoriesQueryResponse : IRequest<GetCategoriesQueryRequest>
    {
        public List<Category> Categories { get; set; }
    }
}
