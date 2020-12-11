using EvidencijaUtrka.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvidencijaUtrka.DAL
{
    public class EvidencijaUtrkaDBcontext : IdentityDbContext
    {
        public EvidencijaUtrkaDBcontext(DbContextOptions<EvidencijaUtrkaDBcontext> options)
            :base(options)
        {
        }

        public DbSet<Utrka> Utrke { get; set; }
        public DbSet<UtrkaRezultat> UtrkaRezultati { get; set; }
    }
}
