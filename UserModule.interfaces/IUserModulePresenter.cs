namespace UserModule.Interfaces
{
    public interface IUserModulePresenter
    {
        bool UpdateUserData(string userProfileId, string userProfileDomainName, string userProfileName, string userProfileAccount, bool isAdmin, string userProfileMailAddress, long operatorId);
        long RegisterUserProfile(string userName);
        string GetOperatorName(long operatorId);  
        bool DeleteUserData(string userProfileId);

    }
}
