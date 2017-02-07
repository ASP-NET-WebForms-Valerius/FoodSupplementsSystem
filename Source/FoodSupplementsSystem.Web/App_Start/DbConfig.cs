using FoodSupplementsSystem.Data;
using FoodSupplementsSystem.Data.Migrations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FoodSupplementsSystem.Web.App_Start
{
    public class DbConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<FoodSupplementsSystemDbContext, Configuration>());
            FoodSupplementsSystemDbContext.Create().Database.Initialize(true);
        }
    }
}