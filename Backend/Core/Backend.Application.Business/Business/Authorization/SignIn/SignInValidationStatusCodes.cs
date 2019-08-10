using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Application.Business.Business.Authorization.SignIn
{
    public enum SignInValidationStatusCodes
    {
        WrongUsernameOrPassword = -1,
        InactiveUser = -2
    }
}
