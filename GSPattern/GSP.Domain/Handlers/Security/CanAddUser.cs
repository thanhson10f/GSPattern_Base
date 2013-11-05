using System.Collections.Generic;
using GSP.CommandProcessor.Command;
using GSP.Domain.Commands.Security;
using GSP.Core.Common;
using GSP.Model.Entities;
using GSP.Data.Repositories;
using GSP.Domain.Properties;

namespace GSP.Domain.Handlers.Security
{
    public class CanAddUser : IValidationHandler<UserRegisterCommand>
    {
        private readonly IUserRepository userRepository;
        public CanAddUser(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        public IEnumerable<ValidationResult> Validate(UserRegisterCommand command)
        {
            User isUserExists = null;
            isUserExists = userRepository.Get(c => c.Email == command.Email);

            if (isUserExists != null)
            {
                yield return new ValidationResult("EMail", Resources.UserExists);
            }
        }
    }
}
