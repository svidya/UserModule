using System.Data;

namespace UserModule.Data
{
    public class UserProfileService : IUserProfileService
    {

        private IUserProfileAccess userProfileAccess;

        public UserProfileService()
        {
            this.userProfileAccess = new UserProfileAccess();
        }

        public bool DeleteUserProfile(long userProfileId)
        {
            return userProfileAccess.DeleteUserProfile(userProfileId);
        }

        public DataTable GetAllUserProfiles()
        {
            return userProfileAccess.GetAllUserProfiles();
        }

        public DataRow GetUserProfileById(long userProfileId)
        {
            return userProfileAccess.GetUserProfileById(userProfileId);
        }

        public DataRow GetUserProfileByName(string userName)
        {
            return userProfileAccess.GetUserProfileByName(userName);
        }

        public long RegisterUserProfile(string userName)
        {
            return userProfileAccess.AddUserProfile(userName);    
        }
  

        public bool UpdateUserProfile(UserProfileEntity userProfile)
        {
            return userProfileAccess.UpdateUserProfile(userProfile);
        }
    }
}
