using System.Data;
using UserModule.DataModel;

namespace UserModule.DataAccess
{
    public interface IUserProfileAccess
    {
        DataRow GetUserProfileById(long userProfileId);

        DataTable GetAllUserProfiles();

        long AddUserProfile(string userName);

        bool UpdateUserProfile(UserProfileEntity userProfile);

        bool DeleteUserProfile(long userProfileId);

        DataRow GetUserProfileByName(string userName);

    }
}
