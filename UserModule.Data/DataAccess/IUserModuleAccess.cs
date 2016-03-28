using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

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
