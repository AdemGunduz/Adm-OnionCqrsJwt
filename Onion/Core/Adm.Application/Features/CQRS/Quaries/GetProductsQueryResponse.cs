using Adm.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adm.Application.Features.CQRS.Quaries
{
    public class GetProductsQueryResponse :IRequest<GetProductsQueryRequest>
    {
        public List<Product> Products { get; set; }
    }
}
