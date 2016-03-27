using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UserModule.interfaces
{
    public interface ILoginModulePresenter
    {
        long Login(string username, string password);
    }
}
