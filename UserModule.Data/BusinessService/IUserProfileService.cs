using System.Data;

namespace UserModule.Data
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
