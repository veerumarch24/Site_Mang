﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SiteManagement
{
    public interface IConnService
    {
        SsConnection GetClientConnection(string environment);
    }
}