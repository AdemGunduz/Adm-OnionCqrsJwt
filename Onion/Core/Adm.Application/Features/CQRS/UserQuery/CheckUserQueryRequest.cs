using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adm.Application.Features.CQRS.UserQuery
{
    public class CheckUserQueryRequest :IRequest<CheckUserQueryResponse>
    {
        public string UserName { get; set; } = null;
        public string Password { get; set; } = null;
    }
}
