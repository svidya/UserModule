using System.Data;

namespace UserModule.Data
{
    public interface IUserProfileAccess
    {
        DataTable GetLocalSystem();

        DataTable GetBranchCodes();

        DataTable GetUserLevels();

    }
}
