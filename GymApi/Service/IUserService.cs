using GymApi.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymApi.Service
{
    public interface IUserService
    {
        public bool IsValidUserInformation(LoginModel model);
        public string GetUserDetails();


    }
}
