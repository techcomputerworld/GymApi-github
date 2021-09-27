using GymApi.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymApi.Service
{
    public class UserService
    {
        private string UserName = "Jestream";
        private string Password = "";
        public bool IsValidUserInformation(LoginModel model)
        {
            if (model.UserName.Equals(UserName) && model.Password.Equals(Password)) return true;
            else return false;
        }
        public string GetUserDetails()
        {
            
            return UserName;
        }
    }
}
