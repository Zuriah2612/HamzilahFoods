﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HamzilahFoods.Data
{
    public class HamzilahFoodsContext : IdentityDbContext<ApplicationUser>
    {
        public HamzilahFoodsContext (DbContextOptions<HamzilahFoodsContext> options)
            : base(options)
        {
        }

        public DbSet<HamzilahFoods.Data.Menu> Menu { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
