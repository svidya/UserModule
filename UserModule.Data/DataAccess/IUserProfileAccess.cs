using System.Collections.Generic;
using System.Data;

namespace UserModule.Data
{
    public interface IUserProfileAccess
    {
        DataTable GetLocalSystem();

        DataTable GetBranchCodes();

        DataTable GetUserLevels();
        bool SaveChanges(long systemId, List<string> branchCodes, long comboBoxSelectedValue, long userProfileId);
    }
}
