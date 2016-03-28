using System.Collections.Generic;
using System.Data;

namespace UserModule.Data
{
    public interface IUserAccessService
    {
        DataTable GetLocalSystem();
        DataTable GetUserLevels();
        DataTable GetBranchCodes();
        bool SaveChanges(long systemId, List<string> branchCodes, long comboBoxSelectedValue,long userProfileId);
    }
}
