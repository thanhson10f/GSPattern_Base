using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GSP.CommandProcessor.Command;
using GSP.Domain.Commands.Security;
using GSP.Data.Repositories;
using GSP.Core.Common;
using GSP.Model.Entities;
using GSP.Domain.Properties;

namespace GSP.Domain.Handlers.Security
{
    public class CanChangePassword : IValidationHandler<ChangePasswordCommand>
    {
        private readonly IUserRepository userRepository;
        public CanChangePassword(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        public IEnumerable<ValidationResult> Validate(ChangePasswordCommand command)
        {
            User user = userRepository.GetById(command.UserId);
            var encoded = Md5Encrypt.Md5EncryptPassword(command.OldPassword);

            if (!user.PasswordHash.Equals(encoded))
            {
                yield return new ValidationResult("OldPassword", Resources.Password);
            }
        }
    }
}
