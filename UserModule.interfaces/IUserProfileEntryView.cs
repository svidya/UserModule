﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UserModule.Interfaces
{
    public interface IUserProfileEntryView
    {
        string UserProfileId { get; set; }   
        string UserProfileDomainName { get; set; }
        string UserProfileName { get; set; }
        string UserProfileAccount { get; set; }  
        bool isAdmin { get; set; }                
        string UserProfileMailAddress { get; set; }   

    }
}
