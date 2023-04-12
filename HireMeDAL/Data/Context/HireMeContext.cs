using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireMeDAL
{
    public class HireMeContext:IdentityDbContext<SystemUser>
    {
        public HireMeContext(DbContextOptions<HireMeContext> options) : base(options)
        {

        }

        
    }
}
