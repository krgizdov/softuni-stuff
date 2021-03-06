﻿using Microsoft.EntityFrameworkCore;
using SIS.HTTP;
using SIS.MvcFramework;
using System.Collections.Generic;

namespace SulsApp
{
    public class Startup : IMvcApplication
    {
        public void Configure(IList<Route> routeTable)
        {

        }

        public void ConfigureServices()
        {
            var db = new ApplicationDbContext();
            db.Database.Migrate();
        }
    }
}
