using Adm.Application.Interfaces;
using Adm.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adm.Application.Features.CQRS.UserQuery
{
    public class CheckUserQueryHandler : IRequestHandler<CheckUserQueryRequest, CheckUserQueryResponse>
    {
        private readonly IRepository<AppUser> userRepository;
        private readonly IRepository<AppRole> roleRepository;

        public CheckUserQueryHandler(IRepository<AppUser> userRepository, IRepository<AppRole> roleRepository)
        {
            this.userRepository = userRepository;
            this.roleRepository = roleRepository;
        }

        public async Task<CheckUserQueryResponse> Handle(CheckUserQueryRequest request, CancellationToken cancellationToken)
        {
             var row = new CheckUserQueryResponse();
            var  user  = await this.userRepository.GetByFilterAsync(x=>x.Username == request.UserName && x.Password == request.Password);
            if (user == null) 
            {
                row.IsExist= false; 
            }
            else
            {
                row.IsExist= true;
                row.Username = request.UserName;
                row.Role= (await  this.roleRepository.GetByFilterAsync(x =>x.Id == user.AppRoleId))?.Definition;
                row.Id = user.Id; 

            }
            return row;
        }
    }
}
