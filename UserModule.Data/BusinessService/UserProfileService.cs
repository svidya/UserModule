using System;
using System.Data;

namespace UserModule.Data
{
    public sealed class UserProfileService : IUserProfileService
    {
        #region Singleton Pattern

        private static IUserProfileService _instance;
        private static object _lockbject = new object();


        public static IUserProfileService Instance
        {
            get {

                lock(_lockbject)
                {
                    if (_instance == null)
                    {
                        _instance = new UserProfileService();
                    }
                }

                return _instance;
            }
        }


        private IUserProfileAccess userProfileAccess;
        private IUserModuleAccess userModuleAccess;

        private UserProfileService()
        {
            this.userProfileAccess = new UserProfileAccess();
            this.userModuleAccess = new UserModuleAccess();

        }
        #endregion

        #region Methods
        public bool DeleteUserProfile(long userProfileId)
        {
            return userModuleAccess.DeleteUserProfile(userProfileId);
        }

        public DataTable GetAllUserProfiles()
        {
            return userModuleAccess.GetAllUserProfiles();
        }
       
        public DataRow GetUserProfileByName(string userName)
        {
            return userModuleAccess.GetUserProfileByName(userName);
        }

        public long RegisterUserProfile(string userName)
        {
            return userModuleAccess.AddUserProfile(userName);    
        }
  

        public bool UpdateUserProfile(UserProfileEntity userProfile)
        {
            return userModuleAccess.UpdateUserProfile(userProfile);
        }

        public UserProfileEntity GetUserProfileById(long userProfileId)
        {
            UserProfileEntity userProfile = new UserProfileEntity();
            DataRow dataRow = userModuleAccess.GetUserProfileById(userProfileId);

            userProfile.UserProfileId = Convert.ToInt64(dataRow["UserProfileId"]);
            userProfile.UserProfileStatus = Convert.ToInt32(dataRow["UserProfileStatus"]);
            userProfile.UserProfileAccount = dataRow["UserProfileAccount"].ToString();
            userProfile.UserProfileDomainName = dataRow["UserProfileDomainName"].ToString();
            userProfile.UserProfileName = dataRow["UserProfileName"].ToString();  
            userProfile.UserProfileMailAddress = dataRow["UserProfileMailAddress"].ToString();
            userProfile.IsAdmin = dataRow["UserProfileUserLevelToUserAdmin"].ToString().Equals("Y")? true :false;
            userProfile.OperatorId = Convert.ToInt64(dataRow["UserProfileOperatorId"]); 
            userProfile.Password = dataRow["UserProfilePassword"].ToString();
            userProfile.UserProfileTimeStamp = Convert.ToDateTime(dataRow["UserProfileTimeStamp"]);

            return userProfile;
            
        }  
        #endregion
    }
}
