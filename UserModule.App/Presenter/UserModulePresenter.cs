﻿using System;
using UserModule.Data;
using UserModule.interfaces;

namespace UserModule.App
{
    public class UserModulePresenter : IUserModulePresenter
    {
        
        private IUserProfileService userProfileService = UserProfileService.Instance;

        #region Methods
        public long RegisterUserProfile(string userName)
        {
            long userProfileId = userProfileService.RegisterUserProfile(userName);
            if(userProfileId > 0)
            {
                return userProfileId;
            }
            else
            {
                throw new Exception("Cannot insert");
            }
            
        }


        public bool UpdateUserData(string userProfileId, string userProfileDomainName, string userProfileName, string userProfileAccount, bool isAdmin, string userProfileMailAddress,long OperatorId)
        {
            UserProfileEntity userProfile = new UserProfileEntity();
            userProfile.UserProfileId = Convert.ToInt64(userProfileId);
            userProfile.UserProfileDomainName = userProfileDomainName;
            userProfile.UserProfileName = userProfileName;
            userProfile.UserProfileAccount = userProfileAccount;
            userProfile.IsAdmin = isAdmin;
            userProfile.UserProfileMailAddress = userProfileMailAddress;
            userProfile.OperatorId = OperatorId;

            bool isUpdated = userProfileService.UpdateUserProfile(userProfile);
            if(isUpdated)
            {
                return isUpdated;
            }
            else
            {
                throw new Exception("Cannot insert");
            }
            

        }

        public string GetOperatorName(long operatorId)
        {
            UserProfileEntity userEntity = new UserProfileEntity();
            userEntity = userProfileService.GetUserProfileById(operatorId);   
            return userEntity.UserProfileName;
        }

        public bool DeleteUserData(string userProfileId)
        {
            bool isDeleted = userProfileService.DeleteUserProfile(Convert.ToInt64(userProfileId));

            return isDeleted;
        }
        #endregion
    }
}
