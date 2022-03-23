using DALProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BALProject
{
    public static class BALServices
    {
        public static List<User> GetALLUsers(int userId)
        {
            //Roles[] roles = DALDBServices.GetallRoles4UserId(userid);
            //if (roles.conatinas == role.MANAGER userId == 7)
            if (userId == 7)
            {
                return DALDBServices.GetALLUsers();
            }
            return null;
        }

        public static List<User> DeleteUser(int userid)
        {
            return DALDBServices.DeleteUser(userid);
        }
    }
}
