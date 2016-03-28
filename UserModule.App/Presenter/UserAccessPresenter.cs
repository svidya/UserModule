using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Windows.Forms;
using UserModule.Data;
using UserModule.Interfaces;

namespace UserModule.App
{
    public class UserAccessPresenter : IUserAccessPresenter
    {
        private IUserAccessService userAccessService = UserAccessService.Instance;

        #region Methods
        public DataTable GetBranchCodes()
        {  
            return userAccessService.GetBranchCodes();
        }

        public DataTable GetLocalSystem()
        {
            Thread.Sleep(10000);
            return userAccessService.GetLocalSystem();
        }

        public DataTable GetUserLevels()
        {
            return userAccessService.GetUserLevels();
        }
           
        public bool SaveChanges(DataGridViewRowCollection collection,long userProfileId)
        {
            long systemId = 0;
            List<string> branchCodes = new List<string>();
            long comboBoxSelectedValue = 0;
            int columnindex =0;
            bool saveChanges = false;

            foreach(DataGridViewRow row in collection)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    var cellType = cell.GetType();

                    if (cellType.Name.Equals("DataGridViewTextBoxCell") && cell.ColumnIndex != 1)
                    {
                        systemId = Convert.ToInt64(cell.Value);
                    }
                    else if (cellType.Name.Equals("DataGridViewCheckBoxCell"))
                    {
                        if (Convert.ToBoolean(cell.FormattedValue))
                        {
                            columnindex = cell.ColumnIndex;

                            var code = row.DataGridView.Columns[columnindex].HeaderText;     
                            branchCodes.Add(code);
                        }
                    }
                    else if (cellType.Name.Equals("DataGridViewComboBoxCell"))
                    {
                        if(cell.Selected)
                        {
                            comboBoxSelectedValue = Convert.ToInt64(cell.Value);
                        }  
                    } 
                }

                saveChanges = userAccessService.SaveChanges(systemId, branchCodes, comboBoxSelectedValue, userProfileId);
                branchCodes = new List<string>();
                comboBoxSelectedValue = 0;
            }     
                
            return saveChanges;
        }

        #endregion
    }
}
