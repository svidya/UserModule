using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace UserModule.interfaces
{
    public interface IUserAccessPresenter
    {
        DataTable GetLocalSystem();

        DataTable GetBranchCodes();

        DataTable GetUserLevels();
    }
}
