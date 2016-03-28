namespace UserModule.Data
{
    public static class Script
    {
        public static readonly string defaultPassword = "passw0rd";

        public static readonly string sqlAddUserProfile = "Insert into UserProfile(UserProfileName) Values(@userProfileName);Select scope_identity()";

        public static readonly string sqlUpdateUserProfile = "Update UserProfile SET UserProfileStatus = @status,UserProfileAccount = @profileAccount, " + 
                                                             "UserProfileName = @fullName, UserProfileDomainName = @domainName, UserProfileMailAddress = @email," +
                                                             "UserProfileUserLevelToUserAdmin = @isAdmin, UserProfileTimeStamp = @dateTime,UserProfileOperatorId =@operatorId,UserProfilePassword = @password where UserProfileId = @userProfileId ";

        public static readonly string sqlDeleteUserProfile = "Update UserProfile SET UserProfileStatus = @status where UserProfileId = @userProfileId";

        public static readonly string sqlUpdatePassword = "Update UserProfile SET UserProfilePassword = @password where UserProfileId = @userProfileId";

        public static readonly string sqlGetUserProfileByName = "Select * From UserProfile where UserProfileAccount = @profileAccount and UserProfileStatus = @status";
        public static readonly string sqlGetUserProfileById = "Select * From UserProfile where UserProfileId = @userprofileId and UserProfileStatus = @status";

        public static string sqlGetLocalSystem = "Select * from LocalSystem";

        public static string sqlGetUserLevelCategory = "Select UserLevelCategoryId,UserLevelCategoryName from UserLevelCategory where UserLevelCategoryName is not null";

        public static string sqlGetBranchCodes = "Select BranchCode From Branch";

        public static string sqlInsertUserAccess = "Insert into UserAccess(UserAccessStatus,UserAccessUserProfileId,UserAccessLocalSystemId,UserAccessUserLevelCategoryId) Values(@userAccessStatus,@userProfileId,@localSystemId,@userLevelId); Select scope_identity()";

        public static string sqlInsertLocalAccess = "Insert into LocalSystemBranch(LocalSystemBranchStatus,LocalSystemBranchUserProfileId,LocalSystemBranchLocalSystemId,localSystemBranchCode) Values(@userAccessStatus,@userProfileId,@localSystemId,@branchCode); Select scope_identity()";

    }
}
