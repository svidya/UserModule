using System.Data;

namespace UserModule.Data
{
    public interface IUserModuleAccess
    {
        DataRow GetUserProfileById(long userProfileId);

        DataTable GetAllUserProfiles();

        long AddUserProfile(string userName);

        bool UpdateUserProfile(UserProfileEntity userProfile);

        bool DeleteUserProfile(long userProfileId);

        DataRow GetUserProfileByName(string userName);
    }
}
