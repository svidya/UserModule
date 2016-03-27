using System.Data;
using UserModule.DataModel;

namespace UserModule.BusinessService
{
    public interface IUserProfileService
    {
        DataRow GetUserProfileById(long userProfileId);

        DataRow GetUserProfileByName(string userName);

        DataTable GetAllUserProfiles();

        long RegisterUserProfile(string userName);

        bool UpdateUserProfile(UserProfileEntity userProfile);

        bool DeleteUserProfile(long userProfileId);
    }
}
