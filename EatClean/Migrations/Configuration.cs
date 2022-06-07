
﻿using EatClean.Data;
using EatClean.Entity;
using System.Data.Entity.Migrations;

namespace EatClean.Migrations

{
    using EatClean.Entity;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EatClean.Data.DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(EatClean.Data.DataContext context)
        {
        }
    }
}
