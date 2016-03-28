using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UserModule.Interfaces
{
    public interface ILoginModulePresenter
    {
        long Login(string username, string password);
    }
}
