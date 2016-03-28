using System;
using System.Data;
using UserModule.Data;
using UserModule.interfaces;

namespace UserModule.App
{
    public class LoginModulePresenter : ILoginModulePresenter
    {
        private IUserProfileService userProfileService = UserProfileService.Instance;
        public long Login(string username, string password)
        {
            DataRow dRow = userProfileService.GetUserProfileByName(username);

            var dbPassword = dRow["UserProfilePassword"].ToString();
            var dbOperatorId = Convert.ToInt64(dRow["UserProfileId"]);
            var isAdmin = dRow["UserProfileUserLevelToUserAdmin"].ToString();

            if (password.Equals(dbPassword) && isAdmin.Equals("Y"))
            {
                return dbOperatorId;
            }
            else
            {
                throw new Exception("Not admin");
            }
        }
    }
}
