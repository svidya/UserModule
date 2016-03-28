using System;
using System.Data;
using UserModule.Data;
using UserModule.Interfaces;

namespace UserModule.App
{
    public class LoginModulePresenter : ILoginModulePresenter
    {
        private IUserProfileService userProfileService = UserProfileService.Instance;

        #region Methods
        public long Login(string username, string password)
        {
            DataRow dRow = userProfileService.GetUserProfileByName(username);

            try
            {

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
            catch
            {
                throw new Exception("User does not exist");
            }
        }
        #endregion
    }
}
