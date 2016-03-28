using System.Data;
using System.Windows.Forms;

namespace UserModule.interfaces
{
    public interface IUserAccessPresenter
    {
        DataTable GetLocalSystem();

        DataTable GetBranchCodes();

        DataTable GetUserLevels();
   
        bool SaveChanges(DataGridViewRowCollection collection,long userProfileId);
    }
}
