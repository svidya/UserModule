﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

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
