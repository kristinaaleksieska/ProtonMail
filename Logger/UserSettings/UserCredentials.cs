using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.UserSettings
{
    public static class UserCredentials
    {
        //Depending on the users and their levels of accesses, can be added here
        //and depending on the testing scope, the different accesses can be tested 
        public static User KristinaTestUser => new User() { UserName = "kristinaalle@protonmail.com", Password  = "Test123"};
    }
}
