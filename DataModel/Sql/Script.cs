namespace UserModule.Sql
{
    public static class Script
    {
        public static readonly string sqlAddUserProfile = "Insert into UserProfile(UserProfileName) Values(@userProfileName);Select scope_identity()";

        public static readonly string sqlUpdateUserProfile = "Update UserProfile SET UserProfileStatus = @status,UserProfileAccount = @profileAccount, " + 
                                                             "UserProfileName = @userName, UserProfileDomainName = @domainName, UserProfileMailAddress = @email," + 
                                                             "UserProfileUserLevelToUserAdmin = @isAdmin, UserProfileTimeStamp = @dateTime where UserProfileId = @userProfileId ";

        public static readonly string sqlDeleteUserProfile = "Update UserProfile SET UserProfileStatus = @status where UserProfileId = @userProfileId";

        public static readonly string sqlUpdatePassword = "Update UserProfile SET UserProfilePassword = @password where UserProfileId = @userProfileId";

        public static readonly string sqlGetUserProfileByName = "Select * From UserProfile where UserProfileAccount = @profileAccount";

        public static string sqlGetLocalSystem = "Select * from LocalSystem";

        public static string sqlGetUserLevelCategory = "Select UserLevelCategoryName from UserLevelCategory where UserLevelCategoryLocalSystemId = @localSystemId and UserLevelCategoryName is not null";
    }
}
