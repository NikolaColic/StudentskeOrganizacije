using System;
using System.Collections.Generic;
using System.Text;

namespace FonData.Helpers
{
    public static class Role
    {
        public const string Admin = "Admin";
        public const string User = "User";
        public const string AdministratorOrUser = Admin + "," + User;
    }
}
