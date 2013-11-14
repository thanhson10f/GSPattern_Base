using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GSP.CommandProcessor.Command;
using GSP.Data.Repositories;
using GSP.Data.Infrastructure;
using GSP.Domain.Commands.Security;
using GSP.Model.Entities;

namespace GSP.Domain.Handlers.Security
{
    public class UserRegisterHandler : ICommandHandler<UserRegisterCommand>
    {
        private readonly IUserRepository userRepository;
        private readonly IUnitOfWork unitOfWork;
        public UserRegisterHandler(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            this.userRepository = userRepository;
            this.unitOfWork = unitOfWork;
        }
        public ICommandResult Execute(UserRegisterCommand command)
        {
            var user = new User
            {
                FirstName = command.FirstName,
                LastName = command.LastName,
                Email = command.Email,
                Password = command.Password,
                RoleId = command.RoleId,
                DateCreated = DateTime.Now,
                LastLoginTime = DateTime.Now,
                Status = command.Status
            };
            userRepository.Add(user);
            unitOfWork.Commit();
            return new CommandResult(true);
        }
    }
}
